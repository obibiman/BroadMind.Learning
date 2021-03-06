using System.Text;
using BroadMind.Common.Base;
using BroadMind.Common.Enumerate;

namespace BroadMind.Common.Domain
{
    public class Telephone : CommonBase
    {
        private string _telephoneNumber;
        public int TelephoneId { get; set; }
        public string AreaCode { get; set; }
        public string Prefix { get; set; }
        public string LineNumber { get; set; }
        public string Extension { get; set; }
        public virtual PhoneType PhoneType { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }

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