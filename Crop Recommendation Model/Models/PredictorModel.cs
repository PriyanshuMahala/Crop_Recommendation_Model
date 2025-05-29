namespace Crop_Recommendation_Model.Models
{
    public class PredictorModel
    {
        public float Nitrogen { get; set; }
        public float Phosphorus { get; set; }
        public float Potassium { get; set; }
        public float Temperature { get; set; }
        public float Humidity { get; set; }
        public float Ph { get; set; }
        public float Rainfall { get; set; }
    }
}