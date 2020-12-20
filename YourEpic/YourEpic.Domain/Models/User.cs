using System;
using System.Collections.Generic;
using System.Linq;

namespace YourEpic.Domain.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }
        public IEnumerable<Epic> Epics { get; set; }
        public int EpicCount { get; set; }

        public IEnumerable<Subscription> MySubscriptions { get; set; }

        public Epic GetEpicById(int id)
        {
            Epic epic;
            try
            {
                epic = Epics.FirstOrDefault(e => e.ID == id);
            }
            catch (InvalidOperationException)
            {
                return null;
            }

            return epic;
        }

        public Epic GetEpicByTitle(string name)
        {
            Epic epic;

            try
            {
                epic = Epics.FirstOrDefault(e => e.Title == name);
            }
            catch (InvalidOperationException)
            {
                return null;
            }

            return epic;
        }
        
        public void AddSubscription(User user) 
        {
            if (user.UserRole.Name != "Publisher") 
            {
                return;
            }
            MySubscriptions.ToList().Add(new Subscription { Publisher = user });
        }

        public Epic GetHighestRatedEpic()
        {
            Epic epic;
            try
            {
                epic = Epics.Where(e => e.GetAverageRating() == Epics.Max(e => e.GetAverageRating())).FirstOrDefault();
            }
            catch(InvalidOperationException)
            {
                return null;
            }

            return epic;
        }
    }
}
