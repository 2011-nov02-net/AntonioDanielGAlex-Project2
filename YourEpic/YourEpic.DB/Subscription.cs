using System;
using System.Collections.Generic;

#nullable disable

namespace YourEpic.DB
{
    public partial class Subscription
    {
        public int WriterId { get; set; }
        public int SubscriberId { get; set; }

        public virtual User Subscriber { get; set; }
        public virtual User Writer { get; set; }
    }
}
