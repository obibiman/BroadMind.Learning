using System;
using System.Collections.Generic;
using BroadMind.RESTFul.WebAPIServices.Enumerate;

namespace BroadMind.RESTFul.WebAPIServices.Models.Admin
{
    public class CourseModel
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int? Credit { get; set; }
        public DepartmentModel DepartmentModel { get; set; }
        public Grade? Grade { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public ICollection<StudentModel> StudentModels { get; set; }
    }
}