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
        public IHttpActionResult Get()
        {
            return Json(shippersLogic.GetAll());
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Json(shippersLogic.GetOne(id));
        }

        [HttpPost]
        public void Post([FromBody] Shippers shippers)
        {
            shippersLogic.Add(shippers);
        }

        [HttpPut]
        public void Put([FromBody] Shippers shippers)
        {
            shippersLogic.Update(shippers);
        }

        [HttpDelete]
        public void Delete(int id)
        {
            shippersLogic.Delete(id);
        }
    }
}