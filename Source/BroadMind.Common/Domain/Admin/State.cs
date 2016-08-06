using BroadMind.Common.Base;

namespace BroadMind.Common.Domain.Admin
{
    public class State : CommonBase
    {
        public int StateId { get; set; }
        public string StateCode { get; set; }
        public string StateName { get; set; }
    }
}