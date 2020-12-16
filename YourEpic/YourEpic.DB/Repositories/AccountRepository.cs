using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using YourEpic.Domain.Interfaces;
using YourEpic.Domain.Models;

namespace YourEpic.DB.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly YourEpicProjectTwoDatabaseContext _context;

        public AccountRepository(YourEpicProjectTwoDatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public bool CreateAccount(Domain.Models.User user)
        {
            return false;
        }

        public bool DeleteAccount(int userID)
        {
            return false;
        }

        public bool EditAccount(Domain.Models.User user)
        {
            return false;
        }

        public IEnumerable<Domain.Models.User> GetUsers(string name = null)
        {
            return null;
        }

        public Domain.Models.User GetUserByID(int id)
        {
            return null;
        }
    }
}
