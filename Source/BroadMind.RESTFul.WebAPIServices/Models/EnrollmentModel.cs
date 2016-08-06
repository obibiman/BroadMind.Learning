using System;
using System.Collections.Generic;
using BroadMind.RESTFul.WebAPIServices.Models.Admin;

namespace BroadMind.RESTFul.WebAPIServices.Models
{
    public class EnrollmentModel
    {
        public int EnrollmentId { get; set; }
        public SemesterModel SemesterModel { get; set; }
        //public int CourseId { get; set; }
        public CourseModel CourseModel { get; set; }
        public ICollection<StudentModel> StudentsModel { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}