using AzureCalc.Models;
using Microsoft.AspNetCore.Mvc;

namespace AzureCalc.Controllers
{
   
    public class AzureController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.InstanceSize = AzureService.InstancePrices.Keys.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Index(AzureService service)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.InstanceSize = AzureService.InstancePrices.Keys.ToList();
                return View(service);            
            }

            //Confirmation of TempData

            TempData["InstanceSize"] = service.InstanceSize;
            TempData["NumInstances"] = service.NumInstances;
            TempData["YearlyCost"] = service.CalculateYearlyCost().ToString();

            return RedirectToAction("Confirmation")
                ;

        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
