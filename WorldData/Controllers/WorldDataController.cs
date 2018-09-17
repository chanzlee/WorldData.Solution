using Microsoft.AspNetCore.Mvc;
using WorldData.Models;
using System;
using System.Collections.Generic;

namespace WorldData.Controllers
{
    public class WorldDataController : Controller
    {
      [HttpGet("/worlddata")]
      public ActionResult Index()
      {
        return View();
      }

      [HttpGet("/worlddata/city")]
      public ActionResult ListCity()
      {
       List<City> cities = City.GetAll();
       return View(cities);
      }

      [HttpGet("/worlddata/country")]
      public ActionResult ListCountry()
      {
        List<Country> countries = Country.GetAll();
        return View(countries);
      }

      [HttpPost("/worlddata/country")]
      public ActionResult FilterCountry()
      {
        string filterOption = Request.Form["filterOption"];
        string filterValue = Request.Form["filterValue"];

        List <Country> filteredCountries = Country.GetFilteredList(filterOption, filterValue);
        return View("ListCountry", filteredCountries);
      }

      [HttpPost("/worlddata/city")]
      public ActionResult FilterCity()
      {
        string filterOption = Request.Form["filterOption"];
        string orderOption = Request.Form["orderOption"];

        if (filterOption == "countryCode")
        {
          string filterValue = Request.Form["filterValue"];
          List<City> filteredCities = City.GetFilteredCity(filterOption, filterValue, orderOption);
          return View("ListCity", filteredCities);
        }
        else
        {
          int filterValue = 0;
          bool filterValueResult = int.TryParse(Request.Form["filterValue"], out filterValue);
          if (filterValueResult == false)
          {
            return View("ListCity", new List <City>{});
          }
          else
          {
            List <City> filteredCities = City.GetFilteredCity(filterOption, filterValue, orderOption);
            return View("ListCity", filteredCities);
          }
        }

      }
    }
}
