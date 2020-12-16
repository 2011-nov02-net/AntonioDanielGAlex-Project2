using System;
using System.Collections.Generic;

#nullable disable

namespace YourEpic.DB
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Epics = new HashSet<Epic>();
            Ratings = new HashSet<Rating>();
            SubscriptionSubscribers = new HashSet<Subscription>();
            SubscriptionWriters = new HashSet<Subscription>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Role { get; set; }
        public string Email { get; set; }

        public virtual Role RoleNavigation { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Epic> Epics { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Subscription> SubscriptionSubscribers { get; set; }
        public virtual ICollection<Subscription> SubscriptionWriters { get; set; }
    }
}
