using System;
using System.Collections.Generic;
using System.Text;
using YourEpic.WebAPI.Models;

namespace YourEpic.WebAPI.Mappers
{
    public static class RoleModelMapper
    {
        public static RoleModel Map(Domain.Models.Role role)
        {
            return new RoleModel
            {
                ID = role.ID,
                Name = role.Name
            };
        }

        public static Domain.Models.Role Map (RoleModel role)
        {
            return new Domain.Models.Role
            {
                ID = role.ID,
                Name = role.Name
            };
        }
    }
}
