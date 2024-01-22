using System.IO.Compression;

namespace POC.Sample.Middle;

public class ConditionalResponseCompressionMiddleware
{
    private readonly RequestDelegate _next;

    public ConditionalResponseCompressionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var originalBodyStream = context.Response.Body;

        using var memoryStream = new MemoryStream();
        context.Response.Body = memoryStream;

        await _next(context);

        if (ShouldCompress(context.Response.ContentLength))
        {
            memoryStream.Seek(0, SeekOrigin.Begin);

            using (var compressedStream = new MemoryStream())
            {
                using (var compressionStream = new BrotliStream(compressedStream, CompressionLevel.Fastest))
                {
                    await memoryStream.CopyToAsync(compressionStream);
                }

                context.Response.Headers.Add("Content-Encoding", "br");
                context.Response.Headers.Remove("Content-Length");
                context.Response.ContentLength = compressedStream.Length;

                compressedStream.Seek(0, SeekOrigin.Begin);
                await compressedStream.CopyToAsync(originalBodyStream);
            }
        }
        else
        {
            memoryStream.Seek(0, SeekOrigin.Begin);
            await memoryStream.CopyToAsync(originalBodyStream);
        }
    }

    private static bool ShouldCompress(long? contentLength)
    {
        // Adjust the threshold based on your requirements
        return contentLength.HasValue && contentLength.Value > 1000;
    }
}