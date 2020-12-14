using System;
using System.Collections.Generic;

namespace YourEpic.DB.IRepositories
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Take a Domain User and send it to the Database
        /// </summary>
        /// <param name="user"></param>
        public bool CreateAccount(User user);

        /// <summary>
        /// Delete a User from the Database 
        /// </summary>
        /// <param name="userID"></param>
        public bool DeleteAccount(int userID);


        /// <summary>
        /// Edit a User's Account 
        /// </summary>
        /// <param name="userID"></param>
        public bool EditAccount(User user);

        /// <summary>
        /// Search for users
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IEnumerable<User> GetUsers(string name = null);

        /// <summary>
        /// Get a single User by userID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetUserByID(int id);

    }

}
