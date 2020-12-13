using System;
namespace YourEpic.DB.IRepositories
{
    public interface IAccountRepository
    {
        /// <summary>
        /// Take a Domain User and send it to the Database
        /// </summary>
        /// <param name="user"></param>
        public void CreateAccount(Domain.User user);

        /// <summary>
        /// Delete a User from the Database 
        /// </summary>
        /// <param name="userID"></param>
        public void DeleteAccount(int userID);


        /// <summary>
        /// Edit a User's Account 
        /// </summary>
        /// <param name="userID"></param>
        public void EditAccount(Domain.user user);

    }

}
