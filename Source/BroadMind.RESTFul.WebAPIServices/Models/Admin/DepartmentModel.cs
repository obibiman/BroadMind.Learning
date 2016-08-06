using System;
using System.Collections.Generic;

namespace BroadMind.RESTFul.WebAPIServices.Models.Admin
{
    public class DepartmentModel
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentDescription { get; set; }
        public ICollection<CourseModel> CourseModels { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}