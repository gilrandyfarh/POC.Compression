using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddResponseCompression(opts =>
{
    opts.Providers.Add<BrotliCompressionProvider>();
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/json", "text/json" });
    opts.EnableForHttps = true;
});

builder.Services.Configure<BrotliCompressionProviderOptions>(opts =>
{
    opts.Level = System.IO.Compression.CompressionLevel.Fastest;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseResponseCompression();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

