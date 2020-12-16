namespace YourEpic.Domain.Models
{
    public class Role
    {
        private readonly int _id;
        private readonly string _name;

        public Role(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public Role(string name)
        {
            _name = name;
        }

        public int ID { get; set; }
        public string Name { get; set; }

    }
}
