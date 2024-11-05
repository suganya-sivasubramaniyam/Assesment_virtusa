using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project1.Services;

namespace project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringTestController : ControllerBase
    {
        private readonly StringTests _test;
        public StringTestController(StringTests test)
        {
            _test = test;
        }




        [HttpGet("string-test")]
        public async Task<IActionResult> StringTest()
        {
            _test.Run();
            return Ok();
        }

    }
}
