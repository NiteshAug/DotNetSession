using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class HomeController : Controller
    {
        private List<string> _users = new List<string>();
        [HttpGet]
        public IEnumerable<string> Get(string value)
        {
            _users.Add(value);

            return _users;
        }
    }
}
