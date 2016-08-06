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
using BroadMind.RESTFul.WebAPIServices.Models;

namespace BroadMind.RESTFul.WebAPIServices.Controllers
{
    /// <summary>
    ///     EnrollmentController
    /// </summary>
    [EnableCors("*", "*", "*")]
    public class EnrollmentController : ApiController
    {
        private readonly IEnrollmentService _enrollmentService;

        /// <summary>
        ///     EnrollmentController
        /// </summary>
        public EnrollmentController()
        {
        }

        /// <summary>
        ///     EnrollmentController
        /// </summary>
        /// <param name="enrollmentService"></param>
        public EnrollmentController(IEnrollmentService enrollmentService)
        {
            _enrollmentService = enrollmentService;
        }

        // GET: api/EnrollmentModel
        /// <summary>
        ///     GetEnrollments
        /// </summary>
        /// <returns>IEnumerable&lt;EnrollmentModel&gt;</returns>
        [HttpGet]
        [Route("v1/Enrollment/GetEnrollments", Name = "GetEnrollments")]
        public IEnumerable<EnrollmentModel> GetEnrollments()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Enrollment, EnrollmentModel>());
            var mapper = config.CreateMapper();

            var enrollments = _enrollmentService.GetAll();
            var enrollmentListModels = mapper.Map<IEnumerable<Enrollment>, List<EnrollmentModel>>(enrollments);
            return enrollmentListModels;
        }

        // GET: api/EnrollmentModel/5
        /// <summary>
        ///     Get
        /// </summary>
        /// <param name="enrollmentId"></param>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        [Route("v1/Enrollment/GetEnrollment/{enrollmentId}", Name = "GetEnrollment")]
        public IHttpActionResult GetEnrollment(int enrollmentId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Enrollment, EnrollmentModel>());
            var mapper = config.CreateMapper();

            var enrollment = _enrollmentService.GetById(enrollmentId);
            var transformedEnrollment = mapper.Map<Enrollment, EnrollmentModel>(enrollment);
            if (transformedEnrollment == null)
            {
                return BadRequest("No Enrollments found");
            }
            return Ok(transformedEnrollment);
        }

        // POST: api/EnrollmentModel
        /// <summary>
        ///     PostEnrollment
        /// </summary>
        /// <param name="enrollmentModel"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        [Route("v1/Enrollment/PostEnrollment", Name = "PostEnrollment")]
        public HttpResponseMessage PostEnrollment(EnrollmentModel enrollmentModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EnrollmentModel, Enrollment>());
            var mapper = config.CreateMapper();
            var transformedEnrollment = mapper.Map<EnrollmentModel, Enrollment>(enrollmentModel);
            _enrollmentService.Add(transformedEnrollment);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetEnrollment", new {transformedEnrollment.EnrollmentId}));
            return response;
        }

        // PUT: api/EnrollmentModel/5
        /// <summary>
        ///     PutEnrollment
        /// </summary>
        /// <param name="enrollmentId"></param>
        /// <param name="enrollmentModel"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPut]
        [Route("v1/Enrollment/PutEnrollment/{enrollmentId}", Name = "PutEnrollment")]
        public HttpResponseMessage PutEnrollment(int enrollmentId, EnrollmentModel enrollmentModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<EnrollmentModel, Enrollment>());
            var mapper = config.CreateMapper();
            var transformedEnrollment = mapper.Map<EnrollmentModel, Enrollment>(enrollmentModel);
            transformedEnrollment.EnrollmentId = enrollmentId;
            _enrollmentService.Update(transformedEnrollment);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetEnrollment", new {transformedEnrollment.EnrollmentId}));
            return response;
        }

        // DELETE: api/EnrollmentModel/5
        /// <summary>
        ///     DeleteEnrollment
        /// </summary>
        /// <param name="enrollmentId"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpDelete]
        [Route("v1/Enrollment/DeleteEnrollment/{enrollmentId}", Name = "DeleteEnrollment")]
        public HttpResponseMessage DeleteEnrollment(int enrollmentId)
        {
            var enrollment = _enrollmentService.GetById(enrollmentId);
            _enrollmentService.Delete(enrollment);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }
    }
}