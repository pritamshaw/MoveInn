using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MoveInn.BAL.Interfaces;
using MoveInn.BAL.Models;
using MoveInn.BAL.Services;
using MoveInn.DAL.Interfaces;
using FluentValidation.Mvc;

namespace MoveInn.UI.Controllers
{
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {
        public IUserService Service;

        public UserController()
        {
            Service = new UserService();
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

        [Route("GetPagedData")]
        [HttpPost]
        public HttpResponseMessage GetPagedData(HttpRequestMessage request)
        {
            try
            {
                var queryStrings = request.GetQueryNameValuePairs();
                if (queryStrings == null)
                    return null;

                var result = Service.GetAll();
                var returObject = new
                {
                    current = 1,
                    rowCount = 10,
                    rows = result,
                    total = result.Count()
                };
                return Request.CreateResponse(HttpStatusCode.OK, returObject);
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
        public HttpResponseMessage Add(User Model)
        {
            try
            {
                if (Model != null)
                    Model.ID = Guid.NewGuid();

                if (!ModelState.IsValid)
                {
                    // validation failed; throw HttpResponseException
                    throw new HttpResponseException(
                        new HttpResponseMessage
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            ReasonPhrase = "Validation failed."
                        });
                }

                Service.Create(Model);
                return Request.CreateResponse(HttpStatusCode.OK, Model);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("Update")]
        public HttpResponseMessage Update(User Model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    // validation failed; throw HttpResponseException
                    throw new HttpResponseException(
                        new HttpResponseMessage
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            ReasonPhrase = "Validation failed."
                        });
                }
                Service.Update(Model);
                return Request.CreateResponse(HttpStatusCode.OK, Model);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("Delete")]
        public HttpResponseMessage Delete(User Model)
        {
            try
            {
                Service.Delete(Model);
                return Request.CreateResponse(HttpStatusCode.OK, Model);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}