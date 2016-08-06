using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using BroadMind.Business.Interfaces;
using BroadMind.Common.Domain;
using BroadMind.RESTFul.WebAPIServices.DataTranslate;
using BroadMind.RESTFul.WebAPIServices.Enumerate;
using BroadMind.RESTFul.WebAPIServices.Models;

namespace BroadMind.RESTFul.WebAPIServices.Controllers
{
    /// <summary>
    ///     TelephoneController
    /// </summary>
    [EnableCors("*", "*", "*")]
    public class TelephoneController : ApiController
    {
        private readonly ITelephoneService _telephoneService;

        /// <summary>
        ///     TelephoneController
        /// </summary>
        /// <param name="telephoneService"></param>
        public TelephoneController(ITelephoneService telephoneService)
        {
            _telephoneService = telephoneService;
        }

        /// <summary>
        ///     TelephoneController
        /// </summary>
        public TelephoneController()
        {
        }

        // GET: api/TelephoneModel
        /// <summary>
        ///     GetTelephones
        /// </summary>
        /// <returns>IEnumerable&lt;TelephoneModel&gt;</returns>
        [HttpGet]
        [Route("v1/Telephone/GetTelephones", Name = "GetTelephones")]
        public IEnumerable<TelephoneModel> GetTelephones()
        {
            var telephones = _telephoneService.GetAll();
            var phoneModels = new List<TelephoneModel>();
            foreach (var telephone in telephones)
            {
                var phoneModel = new TelephoneModel
                {
                    TelephoneId = telephone.TelephoneId,
                    AreaCode = telephone.AreaCode,
                    Prefix = telephone.Prefix,
                    LineNumber = telephone.LineNumber,
                    Extension = telephone.Extension,
                    CreatedDate = telephone.CreatedDate,
                    ModifiedBy = telephone.ModifiedBy,
                    ModifiedDate = telephone.ModifiedDate,
                    TelephoneNumber = telephone.TelephoneNumber,
                    StudentId = telephone.StudentId,
                    PhoneType = (PhoneType) telephone.PhoneType,
                    StudentModel = TransferStudentData.ConvertStudentToModel(telephone.Student)
                };
                phoneModels.Add(phoneModel);
            }
            return phoneModels;
        }

        // GET: api/TelephoneModel/5
        /// <summary>
        ///     GetTelephone
        /// </summary>
        /// <param name="telephoneId"></param>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        [Route("v1/Telephone/GetTelephone/{telephoneId}", Name = "GetTelephone")]
        public IHttpActionResult GetTelephone(int telephoneId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Telephone, TelephoneModel>());
            var mapper = config.CreateMapper();

            var telephone = _telephoneService.GetById(telephoneId);
            var transformedTelephone = mapper.Map<Telephone, TelephoneModel>(telephone);
            if (transformedTelephone == null)
            {
                return BadRequest("No Telephones found");
            }
            return Ok(transformedTelephone);
        }

        // POST: api/TelephoneModel
        /// <summary>
        ///     PostTelephone
        /// </summary>
        /// <param name="telephoneModel"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        [Route("v1/Telephone/PostTelephone", Name = "PostTelephone")]
        public HttpResponseMessage PostTelephone(TelephoneModel telephoneModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TelephoneModel, Telephone>());
            var mapper = config.CreateMapper();
            var transformedTelephone = mapper.Map<TelephoneModel, Telephone>(telephoneModel);
            _telephoneService.Add(transformedTelephone);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetTelephone", new {transformedTelephone.TelephoneId}));
            return response;
        }

        // PUT: api/TelephoneModel/5
        /// <summary>
        ///     PutTelephone
        /// </summary>
        /// <param name="telephoneId"></param>
        /// <param name="telephoneModel"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPut]
        [Route("v1/Telephone/PutTelephone/{userId}", Name = "PutTelephone")]
        public HttpResponseMessage PutTelephone(int telephoneId, TelephoneModel telephoneModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<TelephoneModel, Telephone>());
            var mapper = config.CreateMapper();
            var transformedTelephone = mapper.Map<TelephoneModel, Telephone>(telephoneModel);
            transformedTelephone.TelephoneId = telephoneId;
            _telephoneService.Update(transformedTelephone);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetTelephone", new {transformedTelephone.TelephoneId}));
            return response;
        }

        // DELETE: api/TelephoneModel/5
        /// <summary>
        ///     DeleteTelephone
        /// </summary>
        /// <param name="telephoneId"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpDelete]
        [Route("v1/Telephone/DeleteTelephone/{telephoneId}", Name = "DeleteTelephone")]
        public HttpResponseMessage DeleteTelephone(int telephoneId)
        {
            var telephone = _telephoneService.GetById(telephoneId);
            _telephoneService.Delete(telephone);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }
    }
}