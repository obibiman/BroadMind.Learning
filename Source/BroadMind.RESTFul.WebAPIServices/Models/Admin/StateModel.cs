using System;

namespace BroadMind.RESTFul.WebAPIServices.Models.Admin
{
    public class StateModel
    {
        public int StateId { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}