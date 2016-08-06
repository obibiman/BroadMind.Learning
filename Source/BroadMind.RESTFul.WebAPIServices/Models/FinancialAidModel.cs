using System;

namespace BroadMind.RESTFul.WebAPIServices.Models
{
    public class FinancialAidModel
    {
        public int FinancialAidId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public decimal? Amount { get; set; }
        public bool? OnTrack { get; set; }
        public string Classification { get; set; }

        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
            set
            {
                var names = value.Split(new[] {" "},
                    StringSplitOptions.RemoveEmptyEntries);
                FirstName = names[0];
                LastName = names[1];
            }
        }
    }
}