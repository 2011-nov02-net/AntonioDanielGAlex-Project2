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
                Email = entity.Email,
                UserRole = RolesMapper.Map(entity.RoleNavigation)
            };
        }
        public static User MapBasic(Domain.Models.User model)
        {
            return new User
            {
                Id = model.ID,
                Email = model.Email,
                Name = model.Name,
                Role = model.UserRole.ID
            };
        }
        public static User Map(Domain.Models.User model) {
            return new User {
                Id = model.ID,
                Email = model.Email,
                Name = model.Name,
                RoleNavigation = RolesMapper.Map(model.UserRole)
            };
        }
    }
}
