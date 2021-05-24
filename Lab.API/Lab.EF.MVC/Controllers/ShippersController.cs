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
        private ShippersLogic logic = new ShippersLogic();
        public ActionResult Index(int? value)
        {
            try
            {
                List<ShippersView> shippersViews = new List<ShippersView>();
                if (value == null)
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
            catch (Exception ex)
            {
                return RedirectToAction("index", "Error", new { mssg = ex.Message });
            }
        }
        public ActionResult InsertUpdate(int? id)
        {
            ShippersView shipper = new ShippersView();
            try
            {
                if (id != null)
                {
                    var shipperLogic = logic.GetOne((int)id);
                    if (shipperLogic != null)
                    {
                        shipper.CompanyName = shipperLogic.CompanyName;
                        shipper.Phone = shipperLogic.Phone;
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("index", "Error", new { mssg = ex.Message });
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
            catch (Exception ex)
            {
                return RedirectToAction("index", "Error", new { mssg = ex.Message });
            }
        }

        [HttpGet]
        public bool Delete(int id)
        {
            try
            {
                logic.Delete(id);
                return true;
            }
            catch
            {
                Response.StatusCode = 422;
                return false;
            }
        }
    }
}