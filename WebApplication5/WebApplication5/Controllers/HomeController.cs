using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication5.Interface;
using Microsoft.Extensions.Configuration;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class HomeController : Controller
    {
        private ICustomer _customer;
        private ILogger _logger;
        private readonly IConfiguration _configuration;

        public HomeController(ICustomer customer, ILoggerFactory loggerFactory, IConfiguration config)
        {
            _customer = customer;
            _logger = loggerFactory.CreateLogger<HomeController>();
            _configuration = config;
        }

        [HttpGet]
        public IActionResult getName(string name)
        {
            var result = _customer.printName(name);
            var defaultLogLevel = _configuration["Logging:LogLevel:WebApplication5.Controllers.HomeController"];
            _logger.LogInformation("This is Information Log Level");
            _logger.LogDebug("This is Debug Log Level");
            _logger.LogWarning("This is Warning Log Level");
            _logger.LogError("This is Error Log Level");
            return Ok(defaultLogLevel);
        }
    }
}
