using Microsoft.AspNetCore.Mvc;

namespace TestAppSettings.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IConfiguration _configuration;
    
    public WeatherForecastController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpGet(Name = "Test")]
    public string Get()
    {
        var arr = _configuration
            .GetSection("Serilog")
            .AsEnumerable()
            .Where(x => x.Value != null)
            .Select(x => $"{x.Key}: {x.Value}");

        var response = string.Join("\n", arr);
        
        return response;
    }
}