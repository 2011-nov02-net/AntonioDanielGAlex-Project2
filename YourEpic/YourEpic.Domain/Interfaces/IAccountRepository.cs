using System.Collections.Generic;

namespace YourEpic.Domain.Interfaces
{
    public interface IAccountRepository
    {

        bool CreateAccount(User user);

        bool DeleteAccount(int userID);

        bool EditAccount(User user);

        IEnumerable<User> GetUsers(string name = null);

        User GetUserByID(int id);

    }
}
