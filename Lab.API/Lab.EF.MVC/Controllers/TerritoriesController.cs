using Lab.EF.Logic;
using Lab.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.EF.MVC.Controllers
{
    public class TerritoriesController : Controller
    {
        private TerritoriesLogic logic = new TerritoriesLogic();
        public ActionResult Index()
        {
            try
            {
                List<TerritoriesJoinInfo> territories = logic.JoinRegions();
                List<TerritoriesView> territoriesViews = territories.Select(t => new TerritoriesView
                {
                    id = t.id,
                    descripcion = t.descripcion,
                    region = t.region
                }).ToList();
                return View(territoriesViews);
            }
            catch (Exception ex)
            {
                return RedirectToAction("index", "Error", new { mssg = ex.Message });
            }
        }
    }
}