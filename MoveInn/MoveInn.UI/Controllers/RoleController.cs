using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MoveInn.BAL.Interfaces;
using MoveInn.BAL.Models;
using MoveInn.BAL.Services;

namespace MoveInn.UI.Controllers
{
    [RoutePrefix("api/role")]
    public class RoleController : ApiController
    {
        public IRoleService Service;

        public RoleController()
        {
            Service = new RoleService();
        }

        [Route("")]
        public HttpResponseMessage Get()
        {
            try
            {
                var result = Service.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("{id:int}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var result = Service.FindByID(id);
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("Add")]
        public HttpResponseMessage Add(Role Model)
        {
            try
            {
                Service.Create(Model);
                return Request.CreateResponse(HttpStatusCode.OK, Model);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("Update")]
        public HttpResponseMessage Update(Role Model)
        {
            try
            {
                Service.Create(Model);
                return Request.CreateResponse(HttpStatusCode.OK, Model);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("Delete")]
        public HttpResponseMessage Delete(Role Model)
        {
            try
            {
                Service.Delete(Model);
                return Request.CreateResponse(HttpStatusCode.InternalServerError, Model);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}