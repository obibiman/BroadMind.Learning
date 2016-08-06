using System;
using BroadMind.RESTFul.WebAPIServices.Enumerate;

namespace BroadMind.RESTFul.WebAPIServices.Models.Admin
{
    public class TranscriptModel
    {
        public int TranscriptId { get; set; }
        public SemesterModel SemesterModel { get; set; }
        public CourseModel CourseModel { get; set; }
        public Grade Grade { get; set; }
        public StudentModel StudentModel { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}