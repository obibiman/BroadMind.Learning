using System;
using System.Collections.Generic;
using System.Linq;
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
    ///     SemesterController
    /// </summary>
    [EnableCors("*", "*", "*")]
    public class SemesterController : ApiController
    {
        private readonly ISemesterService _semesterService;

        /// <summary>
        ///     SemesterController
        /// </summary>
        public SemesterController()
        {
        }

        /// <summary>
        ///     SemesterController
        /// </summary>
        /// <param name="semesterService"></param>
        public SemesterController(ISemesterService semesterService)
        {
            _semesterService = semesterService;
        }

        // GET: api/SemesterModel
        /// <summary>
        ///     GetSemesters
        /// </summary>
        /// <returns>IEnumerable&lt;SemesterModel&gt;</returns>
        [HttpGet]
        [Route("v1/Semester/GetSemesters", Name = "GetSemesters")]
        public IEnumerable<SemesterModel> GetSemesters()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Semester, SemesterModel>());
            var mapper = config.CreateMapper();

            var semesters = _semesterService.GetAll();

            var semesterListModels = mapper.Map<IEnumerable<Semester>, List<SemesterModel>>(semesters);
            return semesterListModels;
        }

        // GET: api/SemesterModel/5
        /// <summary>
        ///     GetSemester
        /// </summary>
        /// <param name="semesterId"></param>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        [Route("v1/Semester/GetSemester/{semesterId}", Name = "GetSemester")]
        public IHttpActionResult GetSemester(int semesterId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Semester, SemesterModel>());
            var mapper = config.CreateMapper();

            var semester = _semesterService.GetById(semesterId);

            var transformedSemester = mapper.Map<Semester, SemesterModel>(semester);
            if (transformedSemester == null)
            {
                return BadRequest("No Semesters found");
            }
            return Ok(transformedSemester);
        }

        // POST: api/SemesterModel
        /// <summary>
        ///     PostSemester
        /// </summary>
        /// <param name="semesterModel"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        [Route("v1/Semester/PostSemester", Name = "PostSemester")]
        public HttpResponseMessage PostSemester(SemesterModel semesterModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SemesterModel, Semester>());
            var mapper = config.CreateMapper();
            var transformedSemester = mapper.Map<SemesterModel, Semester>(semesterModel);
            _semesterService.Add(transformedSemester);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetSemester", new {transformedSemester.SemesterId}));
            return response;
        }

        // PUT: api/SemesterModel/5
        /// <summary>
        ///     PutSemester
        /// </summary>
        /// <param name="semesterId"></param>
        /// <param name="semesterModel"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPut]
        [Route("v1/Semester/PutSemester/{semesterId}", Name = "PutSemester")]
        public HttpResponseMessage PutSemester(int semesterId, SemesterModel semesterModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<SemesterModel, Semester>());
            var mapper = config.CreateMapper();
            var transformedSemester = mapper.Map<SemesterModel, Semester>(semesterModel);
            transformedSemester.SemesterId = semesterId;
            _semesterService.Update(transformedSemester);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetSemester", new {transformedSemester.SemesterId}));
            return response;
        }

        // DELETE: api/SemesterModel/5
        /// <summary>
        ///     DeleteSemester
        /// </summary>
        /// <param name="semesterId"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpDelete]
        [Route("v1/Semester/DeleteSemester/{semesterId}", Name = "DeleteSemester")]
        public HttpResponseMessage DeleteSemester(int semesterId)
        {
            var semester = _semesterService.GetById(semesterId);
            _semesterService.Delete(semester);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }

        // DELETE: v1/Semester/DeleteSemesters
        /// <summary>
        ///     DeleteSemesters
        /// </summary>
        /// <param name="semesterModels"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpDelete]
        [Route("v1/Semester/DeleteSemesters", Name = "DeleteSemesters")]
        public HttpResponseMessage DeleteSemesters(List<SemesterModel> semesterModels)
        {
            var semesters = semesterModels.Select(model => new Semester
            {
                SemesterId = model.SemesterId,
                AcademicYear = model.AcademicYear,
                CalendarYear = model.CalendarYear,
                CreatedDate = model.CreatedDate,
                ModifiedBy = model.ModifiedBy,
                ModifiedDate = model.ModifiedDate
            }).ToList();

            _semesterService.RemoveRange(semesters);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }

        // POST: api/SemesterModel
        /// <summary>
        ///     PostSemesters
        /// </summary>
        /// <param name="semesterModels"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        [Route("v1/Semester/PostSemesters", Name = "PostSemesters")]
        public HttpResponseMessage PostSemesters(List<SemesterModel> semesterModels)
        {
            var semesters = semesterModels.Select(stateModel => new Semester
            {
                SemesterId = stateModel.SemesterId,
                AcademicYear = stateModel.AcademicYear,
                CalendarYear = stateModel.CalendarYear,
                CreatedDate = stateModel.CreatedDate,
                ModifiedBy = stateModel.ModifiedBy,
                ModifiedDate = stateModel.ModifiedDate
            }).ToList();
            _semesterService.AddRange(semesters);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            return response;
        }
    }
}