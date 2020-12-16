using System;
using System.Collections.Generic;

#nullable disable

namespace YourEpic.DB
{
    public partial class Category
    {
        public Category()
        {
            EpicCategories = new HashSet<EpicCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<EpicCategory> EpicCategories { get; set; }
    }
}
