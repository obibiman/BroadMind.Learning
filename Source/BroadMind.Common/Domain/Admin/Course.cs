using System.Collections.Generic;
using BroadMind.Common.Base;

namespace BroadMind.Common.Domain.Admin
{
    public class Course : CommonBase
    {
        public Course()
        {
            Students = new List<Student>();
        }

        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public int? Credit { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}