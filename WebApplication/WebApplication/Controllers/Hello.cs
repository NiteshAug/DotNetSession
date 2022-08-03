using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Hello : ControllerBase
    {
        [HttpGet]
        public IActionResult hello()
        {
            string result = "Hello World";
            return Ok(result);
        }
    }
}
