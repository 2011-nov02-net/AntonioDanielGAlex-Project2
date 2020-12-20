using System;
using System.Collections.Generic;
using System.Text;

namespace YourEpic.Domain.Models
{
    public class Subscription
    {
        public User Publisher { get; set; }
        public User Subscriber { get; set; }
        public bool HasNewContent { get; set; } = false;
    }
}
