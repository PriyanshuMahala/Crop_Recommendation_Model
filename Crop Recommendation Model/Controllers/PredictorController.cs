using Crop_Recommendation_Model.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Crop_Recommendation_Model.Services;

namespace Crop_Recommendation_Model.Controllers;

public class PredictorController : Controller
{
    private readonly PredictorService _predictorService;

    public PredictorController(PredictorService predictorService)
    {
        _predictorService = predictorService;
    }

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
        foreach (Crop crop in _predictorService.DeserealiszedData)
        {
            if (ViewData["Prediction"].ToString() == crop.Name.ToLower())
            {

                ViewData["CROP_NAME"] = crop.Name;
                ViewData["CROP_HINGLISH"] = crop.Hinglish;
                ViewData["CROP_SEASON"] = crop.Season;
                ViewData["CROP_soiltype"] = crop.SoilType;
                ViewData["CROP_STATES"] = crop.States;

                break;
            }
        }

        return View(model);
    }

}