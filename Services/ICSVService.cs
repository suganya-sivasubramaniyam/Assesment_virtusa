using project1.Models;

namespace project1.Services
{
    public interface ICSVService
    {
        
        void ExportToJson(List<CsvModels> records, string directory);
        List<CsvModels> LoadData<CsvModels>(Stream file);
    }
}
