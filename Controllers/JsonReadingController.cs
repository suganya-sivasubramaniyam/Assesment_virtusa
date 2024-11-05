using Microsoft.AspNetCore.Mvc;
using project1.Models;
using project1.Services;

namespace project1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JsonReadingController : ControllerBase
    {
        private readonly ITest _test;
        
        public JsonReadingController(ITest test)
        {
            _test = test;
        }
       // [Microsoft.AspNetCore.Mvc.HttpGet("read-Json")]
        [HttpGet("read-Json")]
        public async Task<IActionResult> ReadJson()
        {
            _test.Run();            
            return Ok();
        }
        //[HttpGet("string-test")]
        //public async Task<IActionResult> StringTest()
        //{
        //    _test.Run();
        //    return Ok();
        //}


    }
}
