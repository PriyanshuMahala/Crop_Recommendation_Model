using Crop_Recommendation_Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace Crop_Recommendation_Model.Controllers;

public class PredictorController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(PredictorModel model)
    {
        // Set a breakpoint on the next line to inspect 'model'
        // You can also check ModelState.IsValid here if you add validation
        return RedirectToAction("Result", model);
    }

    public IActionResult Result(PredictorModel model)
    {
        var data = new Predictor.ModelInput
        {
            N = model.Nitrogen,
            P = model.Phosphorus,
            K = model.Potassium,
            Temperature = model.Temperature,
            Humidity = model.Humidity,
            Ph = model.Ph,
            Rainfall = model.Rainfall
        };

        ViewData["Prediction"] = Predictor.Predict(data).PredictedLabel;

        return View(model);
    }
}