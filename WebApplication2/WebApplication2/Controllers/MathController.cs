using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication2.Interface;
using WebApplication2.Service;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MathController : ControllerBase
    {
        public IMath _math;

        public MathController(IMath math)
        {
            _math = math;
        }

        [HttpGet("add")]
        public ActionResult<IEnumerable<int>> Add(int x, int y)
        {
            //int result = _math.Add(x, y);
            return Ok(_math.Add(x, y));
        }

        [HttpGet("divide")]
        public ActionResult<IEnumerable<int>> Divide(int x, int y)
        {
            return Ok(_math.Divide(x, y));
        }

        [HttpGet("multiply")]
        public ActionResult<IEnumerable<int>> Multiply(int x, int y)
        {
            return Ok(_math.Multiply(x, y));
        }

        [HttpGet("substract")]
        public ActionResult<IEnumerable<int>> Substract(int x, int y)
        {
            return Ok(_math.Substract(x, y));
        }
    }
}
