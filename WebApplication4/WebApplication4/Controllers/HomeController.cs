using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication4.ActionFilters;
using WebApplication4.Interface;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class HomeController : ControllerBase
    {
        private ICustomer _customer;

        public HomeController(ICustomer customer)
        {
            _customer = customer;
        }

        [HttpGet]
        [ServiceFilter(typeof(ActionFilterImpl))]
        public IActionResult getName(string name)
        {
            var result = _customer.printName(name);            
            return Ok(result);
        }
    }
}
