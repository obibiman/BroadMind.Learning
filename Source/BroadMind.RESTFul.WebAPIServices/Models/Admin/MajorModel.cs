using System;

namespace BroadMind.RESTFul.WebAPIServices.Models.Admin
{
    public class MajorModel
    {
        public int MajorId { get; set; }
        public string MajorName { get; set; }
        public string MajorDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}