using System;
using System.Collections.Generic;
using System.Text;

namespace YourEpic.Domain.Models
{
    public class Category
    {
        private readonly int _id;
        private readonly string _name;

        public Category(int id, string name)
        {
            _id = id;
            _name = name;
        }

        public Category(string name)
        {
            _name = name;
        }

        public int ID => _id;
        public string Name => _name;
         
    }
}
