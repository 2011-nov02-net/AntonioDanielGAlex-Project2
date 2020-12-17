using System;
using System.Collections.Generic;
using System.Text;

namespace YourEpic.DB.Mappers
{
    public static class UserMapper
    {
        public static Domain.Models.User Map(User entity) {
            return new Domain.Models.User {
                ID = entity.Id,
                Name = entity.Name,
                Email = entity.Email
            };
        }
    }
}
