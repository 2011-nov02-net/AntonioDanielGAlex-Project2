using System;
using System.Collections.Generic;
using System.Text;

namespace YourEpic.DB.Mappers
{
    public static class RolesMapper
    {
        public static Domain.Models.Role Map(Role entity)
        {
            return new Domain.Models.Role
            {
                ID = entity.Id,
                Name = entity.Name
            };
        }

        public static Role Map(Domain.Models.Role model)
        {
            return new Role
            {
                Id = model.ID,
                Name = model.Name
            };
        }
    }
}
