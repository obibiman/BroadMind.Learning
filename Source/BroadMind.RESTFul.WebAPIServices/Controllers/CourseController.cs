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
using BroadMind.RESTFul.WebAPIServices.DataTranslate;
using BroadMind.RESTFul.WebAPIServices.Models.Admin;

namespace BroadMind.RESTFul.WebAPIServices.Controllers
{
    /// <summary>
    ///     CourseController
    /// </summary>
    [EnableCors("*", "*", "*")]
    public class CourseController : ApiController
    {
        private readonly ICourseService _courseService;

        /// <summary>
        ///     CourseController
        /// </summary>
        public CourseController()
        {
        }

        /// <summary>
        ///     CourseController
        /// </summary>
        /// <param name="courseService"></param>
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        // GET: api/CourseModel
        /// <summary>
        ///     Get
        /// </summary>
        /// <returns>IEnumerable&lt;CourseModel&gt;</returns>
        [HttpGet]
        [Route("v1/Course/GetCourses", Name = "GetCourses")]
        public IEnumerable<CourseModel> GetCourses()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Course, CourseModel>());
            var mapper = config.CreateMapper();

            var courses = _courseService.GetAll();

            //var courseListModels = mapper.Map<IEnumerable<Course>, List<CourseModel>>(courses);
            var courseListModels = (List<CourseModel>) TransferCourseData.ConvertCourseToModels(courses);
            return courseListModels;
        }

        // GET: api/CourseModel/5
        /// <summary>
        ///     Get
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        [Route("v1/Course/GetCourse/{courseId}", Name = "GetCourse")]
        public IHttpActionResult GetCourse(int courseId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Course, CourseModel>());
            var mapper = config.CreateMapper();

            var course = _courseService.GetById(courseId);
            var transformedCourse = mapper.Map<Course, CourseModel>(course);
            if (transformedCourse == null)
            {
                return BadRequest("No Course found");
            }
            return Ok(transformedCourse);
        }

        // POST: api/CourseModel
        /// <summary>
        ///     Post
        /// </summary>
        /// <param name="courseModel"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        [Route("v1/Course/PostCourse", Name = "PostCourse")]
        public HttpResponseMessage PostCourse(CourseModel courseModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CourseModel, Course>());
            var mapper = config.CreateMapper();
            var transformedCourse = mapper.Map<CourseModel, Course>(courseModel);
            _courseService.Add(transformedCourse);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetCourse", new {transformedCourse.CourseId}));
            return response;
        }

        // POST: api/CourseModel
        /// <summary>
        ///     PostCourses
        /// </summary>
        /// <param name="courseModels"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        [Route("v1/Course/PostCourses", Name = "PostCourses")]
        public HttpResponseMessage PostCourses(IEnumerable<CourseModel> courseModels)
        {
            var courses = TransferCourseData.ConvertCourseModels(courseModels);
            _courseService.AddRange(courses);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }


        // PUT: api/CourseModel/5
        /// <summary>
        ///     Put
        /// </summary>
        /// <param name="courseId"></param>
        /// <param name="courseModel"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPut]
        [Route("v1/Course/PutCourse/{courseId}", Name = "PutCourse")]
        public HttpResponseMessage PutCourse(int courseId, CourseModel courseModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<CourseModel, Course>());
            var mapper = config.CreateMapper();
            var transformedCourse = mapper.Map<CourseModel, Course>(courseModel);
            transformedCourse.CourseId = courseId;
            _courseService.Update(transformedCourse);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetCourse", new {transformedCourse.CourseId}));
            return response;
        }

        // DELETE: api/CourseModel/5
        /// <summary>
        ///     Delete
        /// </summary>
        /// <param name="courseId"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpDelete]
        [Route("v1/Course/DeleteCourse/{courseId}", Name = "DeleteCourse")]
        public HttpResponseMessage DeleteCourse(int courseId)
        {
            var course = _courseService.GetById(courseId);
            _courseService.Delete(course);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }

        // DELETE: v1/FinancialAid/DeleteFinancialAids
        /// <summary>
        ///     DeleteCourses
        /// </summary>
        /// <param name="courseModels"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpDelete]
        [Route("v1/Course/DeleteCourses", Name = "DeleteCourses")]
        public HttpResponseMessage DeleteCourses(IEnumerable<CourseModel> courseModels)
        {
            var courses = TransferCourseData.ConvertCourseModels(courseModels);
            _courseService.RemoveRange(courses);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }
    }
}