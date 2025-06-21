using Crop_Recommendation_Model.Models;
using Newtonsoft.Json;

namespace Crop_Recommendation_Model.Services
{
    public class PredictorService
    {
        public List<Crop>? DeserealiszedData;
        public PredictorService(string filePath)
        {
            Console.WriteLine($"Filepath {filePath}");
            try
            {
                string data = System.IO.File.ReadAllText(filePath);
                DeserealiszedData = JsonConvert.DeserializeObject<List<Crop>>(data) ?? new List<Crop>();
                Console.WriteLine($"Parsed {DeserealiszedData.Count} crops.");
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load crops: " + ex.Message);
                DeserealiszedData = new List<Crop>();
            }

        }
    }
}
