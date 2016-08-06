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
    ///     StudentController
    /// </summary>
    [EnableCors("*", "*", "*")]
    public class StudentController : ApiController
    {
        private readonly IStudentService _studentService;

        /// <summary>
        ///     StudentController
        /// </summary>
        public StudentController()
        {
        }

        /// <summary>
        ///     StudentController
        /// </summary>
        /// <param name="studentService"></param>
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/StudentModel
        /// <summary>
        ///     Get
        /// </summary>
        /// <returns>IEnumerable&lt;StudentModel&gt;</returns>
        [HttpGet]
        [Route("v1/Student/GetStudents", Name = "GetStudents")]
        public IEnumerable<StudentModel> GetStudents()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentModel>());
            var mapper = config.CreateMapper();

            var students = _studentService.GetAll();

            //var studentListModels = TransferStudentData.ConvertStudentsToModels(students);

            var studentListModels = mapper.Map<IEnumerable<Student>, List<StudentModel>>(students);
            return studentListModels;
        }

        // GET: api/StudentModel/5
        /// <summary>
        ///     Get
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>IHttpActionResult</returns>
        [HttpGet]
        [Route("v1/Student/GetStudent/{studentId}", Name = "GetStudent")]
        public IHttpActionResult GetStudent(int studentId)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Student, StudentModel>());
            var mapper = config.CreateMapper();

            var student = _studentService.GetById(studentId);
            //TransferStudentData transferStudentData = new TransferStudentData();
            //var transformedStudent = transferStudentData.ConvertStudentDomainToStudentViewModel(Student);

            var transformedStudent = mapper.Map<Student, StudentModel>(student);
            if (transformedStudent == null)
            {
                return BadRequest("No Students found");
            }
            return Ok(transformedStudent);
        }

        // POST: api/StudentModel
        /// <summary>
        ///     Post
        /// </summary>
        /// <param name="studentModel"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPost]
        [Route("v1/Student/PostStudent", Name = "PostStudent")]
        public HttpResponseMessage PostStudent(StudentModel studentModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StudentModel, Student>());
            var mapper = config.CreateMapper();
            var transformedStudent = mapper.Map<StudentModel, Student>(studentModel);
            _studentService.Add(transformedStudent);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetStudent", new {transformedStudent.StudentId}));
            return response;
        }

        // PUT: api/StudentModel/5
        /// <summary>
        ///     Put
        /// </summary>
        /// <param name="studentId"></param>
        /// <param name="studentModel"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpPut]
        [Route("v1/Student/PutStudent/{studentId}", Name = "PutStudent")]
        public HttpResponseMessage PutStudent(int studentId, StudentModel studentModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StudentModel, Student>());
            var mapper = config.CreateMapper();
            var transformedStudent = mapper.Map<StudentModel, Student>(studentModel);
            transformedStudent.StudentId = studentId;
            _studentService.Update(transformedStudent);
            var response = Request.CreateResponse(HttpStatusCode.Accepted, new JsonMediaTypeFormatter());
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response.Headers.Location = new Uri(Url.Link("GetStudent", new {transformedStudent.StudentId}));
            return response;
        }

        // DELETE: api/StudentModel/5
        /// <summary>
        ///     Delete
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns>HttpResponseMessage</returns>
        [HttpDelete]
        [Route("v1/Student/DeleteStudent/{studentId}", Name = "DeleteStudent")]
        public HttpResponseMessage DeleteStudent(int studentId)
        {
            var student = _studentService.GetById(studentId);
            _studentService.Delete(student);
            var response = Request.CreateResponse(HttpStatusCode.NoContent);
            return response;
        }
    }
}