using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YourEpic.Domain.Interfaces;

namespace YourEpic.DB.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly YourEpicProjectTwoDatabaseContext _context;

        public RolesRepository(YourEpicProjectTwoDatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IEnumerable<Domain.Models.Role> GetRoles()
        {
            return _context.Roles.Select(Mappers.RolesMapper.Map);
        }
    }
}
