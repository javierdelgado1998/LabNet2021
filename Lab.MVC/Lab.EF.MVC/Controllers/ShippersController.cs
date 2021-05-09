using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.EF.MVC.Controllers
{
    public class ShippersController : Controller
    {
        ShippersLogic logic = new ShippersLogic();
        public ActionResult Index(int? value)
        {
            List<ShippersView> shippersViews = new List<ShippersView>();
            if(value == null)
            {
                List<Shippers> shippers = logic.GetAll();
                shippersViews = shippers.Select(s => new ShippersView
                {
                    Id = s.ShipperID,
                    CompanyName = s.CompanyName,
                    Phone = s.Phone,
                }).ToList();
                return View(shippersViews);
            }
            else
            {
                List<Shippers> shippers = logic.SelecTop((int)value);
                shippersViews = shippers.Select(s => new ShippersView
                {
                    Id = s.ShipperID,
                    CompanyName = s.CompanyName,
                    Phone = s.Phone,
                }).ToList();
                return View(shippersViews);
            }
        }
        public ActionResult InsertUpdate(int? id)
        {
            ShippersView shipper = new ShippersView();
            foreach (var s in logic.GetAll())
            {
                if(s.ShipperID == id)
                {
                    shipper.CompanyName = s.CompanyName;
                    shipper.Phone = s.Phone;
                    break;
                }
            }
            return View(shipper);
        }
        [HttpPost]
        public ActionResult InsertUpdate(ShippersView shipperView)
        {
            try
            {
                Shippers shipperEntitie = new Shippers
                {
                    ShipperID = shipperView.Id,
                    CompanyName = shipperView.CompanyName,
                    Phone = shipperView.Phone
                };
                if (shipperView.Id == 0)
                {
                    logic.Add(shipperEntitie);
                    return RedirectToAction("index");
                }
                else
                {
                    logic.Update(shipperEntitie);
                    return RedirectToAction("index");
                }
            }
            catch(Exception ex)
            {
                return RedirectToAction("index", "Error", new { mssg = ex.Message });
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                logic.Delete(id);
                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                return RedirectToAction("index", "Error", new { mssg = ex.Message });
            }
        }
    }
}