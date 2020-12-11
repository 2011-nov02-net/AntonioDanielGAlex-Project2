using System;
using System.Collections.Generic;

#nullable disable

namespace YourEpic.DB
{
    public partial class Epic
    {
        public Epic()
        {
            Chapters = new HashSet<Chapter>();
            Comments = new HashSet<Comment>();
            EpicCategories = new HashSet<EpicCategory>();
            Ratings = new HashSet<Rating>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int WriterId { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual User Writer { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<EpicCategory> EpicCategories { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
    }
}
