using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using project1.Models;
using project1.Services;

namespace project1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CsvImporterController : ControllerBase
    {

        private readonly ICSVService _csvService;

        public CsvImporterController(ICSVService csvService)
        {
            _csvService = csvService;
        }

        [HttpPost("read-csv")]
        public async Task<IActionResult> GetEmployeeCSV([FromForm] IFormFileCollection file, string directory)
        {
            List<CsvModels> data = _csvService.LoadData<CsvModels>(file[0].OpenReadStream());
            _csvService.ExportToJson(data, directory);
            return Ok(data);
        }
       
    }
}
