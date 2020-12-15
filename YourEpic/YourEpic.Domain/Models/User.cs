using System;
using System.Collections.Generic;
using System.Linq;

namespace YourEpic.Domain.Models
{
    public class User
    {
        private readonly int _id;
        private readonly string _name;
        private readonly string _email;
        private readonly string _pasword;
        private readonly Role _userRole;
        private readonly List<Epic> _epics;

        public User(int id, string name, string email, string password, Role role, List<Epic> epics)
        {
            _id = id;
            _name = name;
            _email = email;
            _pasword = password;
            _userRole = role;
            _epics = epics;
        }

        public User(string name, string email, string password, Role role)
        {
            _name = name;
            _email = email;
            _pasword = password;
            _userRole = role;
        }

        public int ID => _id;
        public string Name => _name;
        public string Email => _email;
        public string Password => _pasword;
        public Role UserRole => _userRole;
        public List<Epic> Epics => _epics;
        public int EpicCount => _epics.Count;

        public Epic GetEpicById(int id)
        {
            Epic epic;
            try
            {
                epic = _epics.FirstOrDefault(e => e.ID == id);
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
                epic = _epics.FirstOrDefault(e => e.Title == name);
            }
            catch (InvalidOperationException)
            {
                return null;
            }

            return epic;
        }
    }
}
