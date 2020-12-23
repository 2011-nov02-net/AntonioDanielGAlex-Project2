using System;
namespace YourEpic.WebAPI.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public RoleModel Role { get; set; }
    }
}
