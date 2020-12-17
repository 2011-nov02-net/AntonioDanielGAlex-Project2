using System;
using System.Collections.Generic;
using System.Text;
using YourEpic.Domain.Models;

namespace YourEpic.Domain.Interfaces
{
    public interface IRolesRepository
    {
        IEnumerable<Role> GetRoles();
    }
}
