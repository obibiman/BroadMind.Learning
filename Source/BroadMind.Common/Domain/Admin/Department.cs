using System.Collections.Generic;
using BroadMind.Common.Base;

namespace BroadMind.Common.Domain.Admin
{
    public class Department : CommonBase
    {
        public int DepartmentId { get; set; }
        public string DepartmentCode { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentDescription { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}