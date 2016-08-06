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
using BroadMind.Common.Domain.Admin;
using BroadMind.RESTFul.WebAPIServices.Models.Admin;

namespace BroadMind.RESTFul.WebAPIServices.Controllers
{
    /// <summary>
    ///     MajorController
    /// </summary>
    [EnableCors("*", "*", "*")]
    public class MajorController : ApiController
    {
        private readonly IMajorService _majorService;

        /// <summary>
        ///     MajorController
        /// </summary>
        public MajorController()
        {
        }

        /// <summary>
        ///     MajorController
        /// </summary>
        /// <param name="majorService"></param>
        public MajorController(IMajorService majorService)
        {
            _majorService = majorService;
        }


        // GET: api/MajorModel
        /// <summary>
        ///     Get
        /// </summary>
        /// <returns>IEnumerable&lt;MajorModel&gt;</returns>
        [HttpGet]
        [Route("v1/Major/GetMajors", Name = "GetMajors")]
        public IEnumerable<MajorModel> GetMajors()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Major, MajorModel>());
            var mapper = config.CreateMapper();

            var majors = _majorService.GetAll();
            var majorListModels = mapper.Map<IEnumerable<Major>, List<MajorModel>>(majors);
            return majorListModels;
        }

        // GET: api/MajorModel/5
        /// <summary>
        ///     Get
        /// </summary>
        /// <param name="majorId"></param>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        [Route("v1/Major/GetMajor/{majorId}", Name = "GetMajor")]
        public IHttpActionResult GetMajor(int majorId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Major, MajorModel>());
            var mapper = config.CreateMapper();

            var major = _majorService.GetById(majorId);
            var transformedMajor = mapper.Map<Major, MajorModel>(major);
            if (transformedMajor == null)
            {
                return BadRequest("No Majors found");
            }
            return Ok(transformedMajor);
        }

        // POST: api/MajorModel
        /// <summary>
        ///     Post
        /// </summary>
        /// <param name="majorModel"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        [Route("v1/Major/PostMajor", Name = "PostMajor")]
        public HttpResponseMessage PostMajor(MajorModel majorModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MajorModel, Major>());
            var mapper = config.CreateMapper();
            var transformedMajor = mapper.Map<MajorModel, Major>(majorModel);
            _majorService.Add(transformedMajor);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetMajor", new {transformedMajor.MajorId}));
            return response;
        }

        // PUT: api/MajorModel/5
        /// <summary>
        ///     Put
        /// </summary>
        /// <param name="majorId"></param>
        /// <param name="majorModel"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPut]
        [Route("v1/Major/PutMajor/{majorId}", Name = "PutMajor")]
        public HttpResponseMessage PutMajor(int majorId, MajorModel majorModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<MajorModel, Major>());
            var mapper = config.CreateMapper();
            var transformedMajor = mapper.Map<MajorModel, Major>(majorModel);
            transformedMajor.MajorId = majorId;
            _majorService.Update(transformedMajor);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetMajor", new {transformedMajor.MajorId}));
            return response;
        }

        // DELETE: api/MajorModel/5
        /// <summary>
        ///     DeleteMajor
        /// </summary>
        /// <param name="majorId"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpDelete]
        [Route("v1/Major/DeleteMajor/{majorId}", Name = "DeleteMajor")]
        public HttpResponseMessage DeleteMajor(int majorId)
        {
            var major = _majorService.GetById(majorId);
            _majorService.Delete(major);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }
    }
}