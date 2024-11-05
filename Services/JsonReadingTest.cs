

using project1.Models;
using System.Text.Json;

namespace project1.Services
{
    public class JsonReadingTest :ITest
    {
        public string Name { get { return "Json Reading Test"; } }

        public void Run()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "MyTestResources", "SamplePoints.json");

           
            byte[] jsonData;
            using (var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                jsonData = new byte[fileStream.Length];
                 fileStream.ReadAsync(jsonData, 0, (int)fileStream.Length);
            }
            
            PrintOverview(jsonData);

        }

        private void PrintOverview(byte[] data)
        {
            var measurements = JsonSerializer.Deserialize<List<Measurement>>(data);
            var parameters = new Dictionary<string, (double Min, double Avg, double Max)>();
            var propertise = typeof(Measurement).GetProperties();
            foreach (var prop in propertise)
            {
                var values = measurements.Select(m => (double)prop.GetValue(m)).ToList();
                double min = values.Min();
                double avg = values.Average();
                double max = values.Max();

                parameters[prop.Name] = (min,avg, max);

            }

            Console.WriteLine("Parameter  Min  Avg  Max ");
            foreach (var item in parameters)
            {
                Console.WriteLine($"{item.Key,-12}  {item.Value.Min,-5}  {item.Value.Avg,-5:F2}  {item.Value.Max,-5}");
            }
        }
    }
}
