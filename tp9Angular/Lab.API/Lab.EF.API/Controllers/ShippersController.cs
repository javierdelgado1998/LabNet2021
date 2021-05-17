using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Lab.EF.API.Controllers
{
    //[EnableCors(origins: "http://localhost:4200/", headers:"*", methods:"*")]
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
                return Request.CreateResponse(HttpStatusCode.OK, shippersLogic.GetAll());
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
                return Ok(shippersLogic.GetOne(id));
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] Shippers shippers)
        {
            try
            {
                shippersLogic.Add(shippers);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put([FromBody] Shippers shippers)
        {
            try
            {
                shippersLogic.Update(shippers);
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