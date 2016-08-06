using BroadMind.Common.Base;

namespace BroadMind.Common.Domain.Admin
{
    public class Major : CommonBase
    {
        public int MajorId { get; set; }
        public string MajorName { get; set; }
        public string MajorDescription { get; set; }
    }
}