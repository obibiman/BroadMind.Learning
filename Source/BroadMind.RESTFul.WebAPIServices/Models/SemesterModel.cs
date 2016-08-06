using System;

namespace BroadMind.RESTFul.WebAPIServices.Models
{
    public class SemesterModel
    {
        public int SemesterId { get; set; }
        public string AcademicYear { get; set; }
        public string CalendarYear { get; set; }
        public string SemesterName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int StudentId { get; set; }
        public StudentModel Student { get; set; }
    }
}