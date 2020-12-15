#nullable disable

namespace YourEpic.DB
{
    public partial class EpicCategory
    {
        public int EpicId { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }
        public virtual Epic Epic { get; set; }
    }
}
