﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MoveInn.BAL.Interfaces;
using MoveInn.BAL.Models;
using MoveInn.BAL.Services;
using MoveInn.DAL.Interfaces;

namespace MoveInn.UI.Controllers
{
    [RoutePrefix("api/eventcategory")]
    public class EventCategoryController : ApiController
    {
        public IEventCategoryService Service;

        public EventCategoryController()
        {
            Service = new EventCategoryService();
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
        public HttpResponseMessage Add(EventCategory Model)
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
        public HttpResponseMessage Update(EventCategory Model)
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
        public HttpResponseMessage Delete(EventCategory Model)
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