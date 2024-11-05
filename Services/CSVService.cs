using CsvHelper.TypeConversion;
using CsvHelper;
using project1.Models;
using System.Globalization;
using System.IO;
using CsvHelper.Configuration;
using System.Reflection.PortableExecutable;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace project1.Services
{

    public class CSVService : ICSVService
    {
       

        public  List<CsvModels> LoadData<CsvModels>(Stream file)
        {
           var config = new CsvConfiguration(CultureInfo.InvariantCulture)
           {
               HasHeaderRecord= true,
               MissingFieldFound = null,
               BadDataFound= null,
           };

            using (var reader = new StreamReader(file)) 
            using (var csv = new CsvReader(reader, config))
            {
                var records = csv.GetRecords<CsvModels>().ToList();
                return records;
            }

            
        }

        public void ExportToJson(List<CsvModels> records,string directory)
        {

            Directory.CreateDirectory(directory);

            int fileIndex = 1;
            for (int i = 0; i < records.Count; i+=97)
            {
                var batch = records.Skip(1).Take(97).ToList();
                var output = new
                {
                    count = batch.Count,
                    items = batch
                };
                string json = JsonSerializer.Serialize(output,new JsonSerializerOptions { WriteIndented = true});
                string fileName = $"items_{fileIndex:D4}.json";
                string filePath = Path.Combine(directory, fileName);

                File.WriteAllText(filePath, json);
                 fileIndex++;
                 
            }

        }

    }
}

