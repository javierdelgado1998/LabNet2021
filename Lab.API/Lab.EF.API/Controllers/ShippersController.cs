using Lab.EF.API.Models;
using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab.EF.API.Controllers
{
    public class ShippersController : ApiController
    {
        private ShippersLogic shippersLogic;
        public ShippersController()
        {
            shippersLogic = new ShippersLogic();
        }
        [HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                List<ShipperAPIView> shippersViews = new List<ShipperAPIView>();
                List<Shippers> shippers = shippersLogic.GetAll();
                shippersViews = shippers.Select(s => new ShipperAPIView
                {
                    Id = s.ShipperID,
                    CompanyName = s.CompanyName,
                    Phone = s.Phone,
                }).ToList();
                return Request.CreateResponse(HttpStatusCode.OK, shippersViews);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var shipperView = new ShipperAPIView();
                var shipper = shippersLogic.GetOne(id);
                if (shipper != null)
                {
                    shipperView.Id = shipper.ShipperID;
                    shipperView.CompanyName = shipper.CompanyName;
                    shipperView.Phone = shipper.Phone;
                    return Ok(shipperView);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] ShipperAPIView shipperView)
        {
            try
            {
                var shipper = new Shippers();
                shipper.CompanyName = shipperView.CompanyName;
                shipper.Phone = shipperView.Phone;
                shippersLogic.Add(shipper);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody] ShipperAPIView shipperView)
        {
            try
            {
                var shipper = new Shippers();
                shipper.ShipperID = shipperView.Id;
                shipper.CompanyName = shipperView.CompanyName;
                shipper.Phone = shipperView.Phone;
                shippersLogic.Update(shipper);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                shippersLogic.Delete(id);
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            catch (NotFoundException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex.Message);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}