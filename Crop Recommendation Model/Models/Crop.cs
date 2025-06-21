
namespace Crop_Recommendation_Model.Models
{
    public class Crop
    {
        public string? Name { get; set; }
        public string? Hinglish { get; set; }
        public string? SoilType { get; set; }
        public List<String> States { get; set; }
        public string? Season { get; set; }
    }
}
