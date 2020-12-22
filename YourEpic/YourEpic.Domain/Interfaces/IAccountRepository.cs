using System.Collections.Generic;
using YourEpic.Domain.Models;

namespace YourEpic.Domain.Interfaces
{
    public interface IAccountRepository
    {
        bool CreateAccount(User user);

        bool DeleteAccount(int userID);

        bool EditAccount(User user);

        IEnumerable<User> GetUsers(string name = null);

        User GetUserByID(int id);

        User GetUserByEmail(string email);

    }
}
