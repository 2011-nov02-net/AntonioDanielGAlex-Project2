using System;
using System.Collections.Generic;

#nullable disable

namespace YourEpic.DB
{
    public partial class Rating
    {
        public int Id { get; set; }
        public int RaterId { get; set; }
        public int EpicId { get; set; }
        public int Rating1 { get; set; }

        public virtual Epic Epic { get; set; }
        public virtual User Rater { get; set; }
    }
}
