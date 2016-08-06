using BroadMind.Common.Base;

namespace BroadMind.Common.Domain
{
    public class Address : CommonBase
    {
        public int AddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string StateCode { get; set; }
        public string ZipCode { get; set; }
        public string Country { get; set; }
    }
}