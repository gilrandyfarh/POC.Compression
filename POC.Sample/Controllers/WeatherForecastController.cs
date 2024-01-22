using Microsoft.AspNetCore.Mvc;
using BenchmarkDotNet.Attributes;

namespace POC.Sample.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    public static IEnumerable<WeatherForecast> GenerateResponse()
    {
        return Enumerable.Range(1, 2000).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            LongText = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Quam lacus suspendisse faucibus interdum posuere lorem ipsum dolor sit. Vivamus at augue eget arcu dictum varius duis at. Tempus egestas sed sed risus. Tincidunt id aliquet risus feugiat in ante. A arcu cursus vitae congue mauris rhoncus aenean. Pretium vulputate sapien nec sagittis aliquam malesuada bibendum. Lorem sed risus ultricies tristique nulla. Aliquam sem et tortor consequat id porta nibh venenatis cras. Nibh venenatis cras sed felis. Neque ornare aenean euismod elementum nisi quis eleifend quam. Fermentum dui faucibus in ornare quam viverra orci sagittis. Ipsum consequat nisl vel pretium lectus quam. Est ultricies integer quis auctor elit sed vulputate. Neque convallis a cras semper auctor neque vitae tempus. Pulvinar pellentesque habitant morbi tristique senectus et netus. Massa enim nec dui nunc mattis enim ut tellus elementum. Mattis nunc sed blandit libero volutpat sed. In egestas erat imperdiet sed euismod nisi.\n\nPellentesque habitant morbi tristique senectus et netus et malesuada fames. Laoreet non curabitur gravida arcu ac tortor. Bibendum est ultricies integer quis auctor elit sed. Diam volutpat commodo sed egestas egestas. Libero nunc consequat interdum varius sit amet mattis vulputate. Nulla facilisi nullam vehicula ipsum a arcu. At varius vel pharetra vel turpis nunc eget lorem dolor. Nulla facilisi etiam dignissim diam quis enim lobortis scelerisque fermentum. Nascetur ridiculus mus mauris vitae ultricies leo. Libero enim sed faucibus turpis. Turpis egestas integer eget aliquet nibh. Scelerisque varius morbi enim nunc faucibus. Molestie ac feugiat sed lectus vestibulum mattis ullamcorper velit sed. Lectus vestibulum mattis ullamcorper velit sed. Convallis aenean et tortor at risus. Ullamcorper malesuada proin libero nunc consequat. Vitae elementum curabitur vitae nunc. Vulputate eu scelerisque felis imperdiet proin fermentum leo.\n\nQuam pellentesque nec nam aliquam sem et tortor consequat id. Pretium vulputate sapien nec sagittis aliquam malesuada bibendum arcu. Amet mattis vulputate enim nulla aliquet porttitor lacus luctus accumsan. Fames ac turpis egestas sed tempus. Ullamcorper eget nulla facilisi etiam dignissim diam quis enim lobortis. Arcu odio ut sem nulla pharetra. Amet est placerat in egestas erat imperdiet. Facilisis sed odio morbi quis commodo odio aenean. Nec feugiat nisl pretium fusce. Odio facilisis mauris sit amet massa. Quam adipiscing vitae proin sagittis nisl rhoncus mattis rhoncus. Ultricies integer quis auctor elit sed. Sollicitudin tempor id eu nisl nunc mi ipsum faucibus vitae. Congue quisque egestas diam in arcu. Quis vel eros donec ac. Diam volutpat commodo sed egestas egestas fringilla phasellus. Venenatis cras sed felis eget velit aliquet. Volutpat blandit aliquam etiam erat velit scelerisque. Tincidunt dui ut ornare lectus sit amet est placerat.\n\nElit scelerisque mauris pellentesque pulvinar pellentesque habitant morbi tristique. Ultrices in iaculis nunc sed augue lacus. Nisi est sit amet facilisis magna etiam tempor. Id interdum velit laoreet id donec ultrices tincidunt arcu. Tincidunt dui ut ornare lectus sit amet. Ullamcorper malesuada proin libero nunc. Adipiscing elit pellentesque habitant morbi tristique senectus et netus et. Tempor orci dapibus ultrices in iaculis nunc sed augue. Donec et odio pellentesque diam volutpat. Nunc mattis enim ut tellus elementum sagittis vitae et. Iaculis eu non diam phasellus. Suspendisse faucibus interdum posuere lorem. Magna eget est lorem ipsum dolor sit amet. Vitae sapien pellentesque habitant morbi tristique senectus et netus. Egestas erat imperdiet sed euismod nisi porta lorem mollis. Laoreet suspendisse interdum consectetur libero id faucibus nisl tincidunt. Viverra orci sagittis eu volutpat odio facilisis mauris.\n\nElit eget gravida cum sociis natoque penatibus et. Turpis nunc eget lorem dolor sed. Sit amet cursus sit amet dictum sit. Sit amet mattis vulputate enim nulla. Faucibus in ornare quam viverra orci. Lacinia at quis risus sed vulputate odio ut. Lobortis elementum nibh tellus molestie nunc non blandit. Nibh venenatis cras sed felis eget. Velit euismod in pellentesque massa. Eget aliquet nibh praesent tristique magna sit amet purus. Amet cursus sit amet dictum sit. Turpis egestas maecenas pharetra convallis posuere morbi leo urna molestie. A scelerisque purus semper eget duis at tellus.\n\nTincidunt vitae semper quis lectus nulla at volutpat. Pharetra massa massa ultricies mi. Nisi porta lorem mollis aliquam ut porttitor leo. Convallis aenean et tortor at risus. Aliquet eget sit amet tellus cras adipiscing enim. Ut tellus elementum sagittis vitae et. Nunc sed id semper risus. Nisl rhoncus mattis rhoncus urna. Hac habitasse platea dictumst quisque sagittis purus sit amet volutpat. Ut faucibus pulvinar elementum integer enim neque volutpat ac tincidunt. Faucibus turpis in eu mi bibendum neque egestas. Pharetra magna ac placerat vestibulum lectus mauris ultrices eros. Pellentesque nec nam aliquam sem et tortor consequat. Senectus et netus et malesuada fames ac turpis egestas sed. Aliquet bibendum enim facilisis gravida neque. Sed risus ultricies tristique nulla aliquet. Ipsum dolor sit amet consectetur."
        })
        .ToArray();
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return GenerateResponse();
    }
}

