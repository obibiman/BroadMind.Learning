using System;
using System.Text;
using BroadMind.RESTFul.WebAPIServices.Enumerate;

namespace BroadMind.RESTFul.WebAPIServices.Models
{
    public class TelephoneModel
    {
        private string _telephoneNumber;
        public int TelephoneId { get; set; }
        public string AreaCode { get; set; }
        public string Prefix { get; set; }
        public string LineNumber { get; set; }
        public string Extension { get; set; }
        public PhoneType PhoneType { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int StudentId { get; set; }
        public StudentModel StudentModel { get; set; }

        public string TelephoneNumber
        {
            get { return _telephoneNumber; }
            set
            {
                var sb = new StringBuilder();
                sb.Append("1")
                    .Append("(")
                    .Append(AreaCode)
                    .Append(")")
                    .Append("-")
                    .Append(Prefix)
                    .Append("-")
                    .Append(LineNumber);
                if (!string.IsNullOrEmpty(Extension.Trim()) || !string.IsNullOrWhiteSpace(Extension.Trim()))
                {
                    sb.Append("-").Append(Extension);
                }
                _telephoneNumber = sb.ToString();
            }
        }
    }
}