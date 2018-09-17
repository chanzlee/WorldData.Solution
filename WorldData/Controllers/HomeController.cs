using Microsoft.AspNetCore.Mvc;
using WorldData.Models;
namespace WorldData.Controllers
{
    public class HomeController : Controller
    {
      [HttpGet("/")]
      public ActionResult Index()
      {
        Country randomCountry = Country.GetRandomCountry();
        return View(randomCountry);
      }
    }
}
