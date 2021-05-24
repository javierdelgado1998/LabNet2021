using Lab.EF.Logic;
using Lab.EF.Logic.Models;
using Lab.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.EF.MVC.Controllers
{
    public class CountriesController : Controller
    {
        private CountriesLogic logic;
        public CountriesController()
        {
            logic = new CountriesLogic(new ApiClientRest());
        }
        public ActionResult Index()
        {
            try
            {
                var countries = logic.GetCountries();
                var countriesViews = from c in countries
                                     select new CountriesView
                                     {
                                         Name = c.Name,
                                         Capital = c.Capital,
                                         Flag = c.Flag,
                                         SubRegion = c.SubRegion,
                                         Region = c.Region,
                                         languages = c.languages,
                                         NativeName = c.NativeName,
                                         Population = c.Population
                                     };
                return View(countriesViews.ToList());
            }
            catch (Exception ex)
            {
                return RedirectToAction("index", "Error", new { mssg = ex.Message });
            }
        }
    }
}