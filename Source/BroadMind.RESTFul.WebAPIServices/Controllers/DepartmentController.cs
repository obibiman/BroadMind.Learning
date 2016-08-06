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
    ///     DepartmentController
    /// </summary>
    [EnableCors("*", "*", "*")]
    public class DepartmentController : ApiController
    {
        private readonly IDepartmentService _departmentService;

        /// <summary>
        ///     DepartmentController
        /// </summary>
        public DepartmentController()
        {
        }

        /// <summary>
        ///     DepartmentController
        /// </summary>
        /// <param name="departmentService"></param>
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        // GET: api/DepartmentModel
        /// <summary>
        ///     GetDepartments
        /// </summary>
        /// <returns>IEnumerable&lt;DepartmentModel&gt;</returns>
        [HttpGet]
        [Route("v1/Department/GetDepartments", Name = "GetDepartments")]
        public IEnumerable<DepartmentModel> GetDepartments()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Department, DepartmentModel>());
            var mapper = config.CreateMapper();

            var departments = _departmentService.GetAll();
            //var departmentListModels2 = TransferDepartmentData.ConvertDepartmentsToModels(departments);

            var departmentListModels = mapper.Map<IEnumerable<Department>, List<DepartmentModel>>(departments);
            return departmentListModels;
        }

        // GET: api/DepartmentModel/5
        /// <summary>
        ///     GetDepartment
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        [Route("v1/Department/GetDepartment/{departmentId}", Name = "GetDepartment")]
        public IHttpActionResult GetDepartment(int departmentId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Department, DepartmentModel>());
            var mapper = config.CreateMapper();

            var department = _departmentService.GetById(departmentId);
            //var transformedDepartment = TransferDepartmentData.ConvertDepartmentToModel(department);

            var transformedDepartment = mapper.Map<Department, DepartmentModel>(department);
            if (transformedDepartment == null)
            {
                return BadRequest("No Department found");
            }
            return Ok(transformedDepartment);
        }

        // POST: api/DepartmentModel
        /// <summary>
        ///     PostDepartment
        /// </summary>
        /// <param name="departmentModel"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        [Route("v1/Department/PostDepartment", Name = "PostDepartment")]
        public HttpResponseMessage PostDepartment(DepartmentModel departmentModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DepartmentModel, Department>());
            var mapper = config.CreateMapper();
            var transformedDepartment = mapper.Map<DepartmentModel, Department>(departmentModel);
            //var transformedDepartment = TransferDepartmentData.ConvertDepartmentModel(departmentModel);
            _departmentService.Add(transformedDepartment);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetDepartment", new {transformedDepartment.DepartmentId}));
            return response;
        }

        // PUT: api/DepartmentModel/5
        /// <summary>
        ///     PutDepartment
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="departmentModel"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPut]
        [Route("v1/Department/PutDepartment/{departmentId}", Name = "PutDepartment")]
        public HttpResponseMessage PutDepartment(int departmentId, DepartmentModel departmentModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<DepartmentModel, Department>());
            var mapper = config.CreateMapper();
            var transformedDepartment = mapper.Map<DepartmentModel, Department>(departmentModel);
            transformedDepartment.DepartmentId = departmentId;
            _departmentService.Update(transformedDepartment);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetDepartment", new {transformedDepartment.DepartmentId}));
            return response;
        }

        // DELETE: api/DepartmentModel/5
        /// <summary>
        ///     DeleteDepartment
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpDelete]
        [Route("v1/Department/DeleteDepartment/{departmentId}", Name = "DeleteDepartment")]
        public HttpResponseMessage DeleteDepartment(int departmentId)
        {
            var department = _departmentService.GetById(departmentId);
            _departmentService.Delete(department);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }
    }
}