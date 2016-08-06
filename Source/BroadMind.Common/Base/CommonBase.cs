using System;

namespace BroadMind.Common.Base
{
    public abstract class CommonBase
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
    }
}