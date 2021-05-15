using Lab.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.EF.MVC.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(string mssg)
        {
            ExceptionsView ex = new ExceptionsView
            {
                Message = mssg
            };
            return View(ex);
        }
    }
}