using System.Collections.Generic;
using BroadMind.Common.Base;
using BroadMind.Common.Domain.Admin;

namespace BroadMind.Common.Domain
{
    public class Enrollment : CommonBase
    {
        public Enrollment()
        {
            Students = new List<Student>();
        }

        public int EnrollmentId { get; set; }
        //public int? CourseId { get; set; }
        public virtual Course Course { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}