using BroadMind.Common.Base;

namespace BroadMind.Common.Domain
{
    public class Semester : CommonBase
    {
        public int SemesterId { get; set; }
        public string AcademicYear { get; set; }
        public string CalendarYear { get; set; }
        public string SemesterName { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}