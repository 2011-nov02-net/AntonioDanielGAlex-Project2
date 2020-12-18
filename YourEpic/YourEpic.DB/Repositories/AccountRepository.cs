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

        /// <summary>
        /// Create a user account
        /// </summary>
        /// <param name="user">user to add to database</param>
        /// <returns>True if user succesfully added to database or false if customer already exists</returns>
        public bool CreateAccount(Domain.Models.User user)
        {
            var dbUser = _context.Users
                .FirstOrDefault(u => u.Email == user.Email);

            if(dbUser != null)
            {
                return false;
            }

            dbUser = new User
            {
                Name = user.Name,
                Role = user.UserRole.ID,
                Email = user.Email
            };

            _context.Users.Add(dbUser);
            _context.SaveChanges();

            return true;
            
        }

        /// <summary>
        /// Deletes user and related data from database.
        /// </summary>
        /// <param name="userID">User Id</param>
        /// <returns>True if deltetion was succesful or false if not customer was found to delete</returns>
        public bool DeleteAccount(int userID)
        {
            var dbUser = _context.Users
                .FirstOrDefault(u => u.Id == userID);

            if (dbUser == null)
            {
                return false;
            }

            _context.Users.Remove(dbUser);
            _context.SaveChanges();

            return true;
        }
        /// <summary>
        /// Changes Name and Email of user in database.
        /// </summary>
        /// <param name="user">Domain.Models.User object</param>
        /// <returns>True if edit was succesfull or false if not user was foundto edit</returns>
        public bool EditAccount(Domain.Models.User user)
        {
            var dbUser = _context.Users
                .FirstOrDefault(u => u.Id == user.ID);

            if (dbUser == null)
            {
                return false;
            }

            dbUser.Name = user.Name;
            dbUser.Email = user.Email;

            _context.SaveChanges();

            return true;
        }

        /// <summary>
        /// Gets users by name.
        /// </summary>
        /// <param name="name">Target user name</param>
        /// <returns>users by search criteria, all users if no users match criteria or empty user list if no users exist</returns>
        public IEnumerable<Domain.Models.User> GetUsers(string name = null)
        {
            List<User> dbUsers = new List<User>();

            if(!string.IsNullOrWhiteSpace(name))
            {
                dbUsers = _context.Users
                .Include(u => u.Epics)
                .Include(u => u.RoleNavigation)
                .Where(u => u.Name.Contains(name))
                .ToList();
            }
            else
            {
                dbUsers = _context.Users
                .Include(u => u.Epics)
                .Include(u => u.RoleNavigation)
                .ToList();
            }

            if (!dbUsers.Any())
            {
                return new List<Domain.Models.User>();
            }
            List<Domain.Models.User> users = dbUsers.Select(u => new Domain.Models.User
            {
                ID = u.Id,
                Name = u.Name,
                Email = u.Email,
                UserRole = new Domain.Models.Role
                {
                    ID = u.RoleNavigation.Id,
                    Name = u.RoleNavigation.Name
                },
                //User epics will only have Id, Title, and Date set here.
                //If we want more details, get info through Epics repository.
                Epics = u.Epics.Select(e => new Domain.Models.Epic
                {
                    ID = e.Id,
                    Title = e.Name,
                    Date = (DateTime)e.DateCreated
                })
            }).ToList();

            return users;
        }

        /// <summary>
        /// Gets user by Id
        /// </summary>
        /// <param name="id">User Id</param>
        /// <returns>Domain.Models.User object with epic info if exists in database, null otherwise</returns>
        public Domain.Models.User GetUserByID(int id)
        {
            var dbUser = _context.Users
                .Include(u => u.Epics)
                .Include(u => u.RoleNavigation)
                .FirstOrDefault(u => u.Id == id);

            if(dbUser == null)
            {
                return null;
            }

            Domain.Models.User user = new Domain.Models.User
            {
                ID = dbUser.Id,
                Name = dbUser.Name,
                Email = dbUser.Email,
                UserRole = new Domain.Models.Role
                {
                    ID = dbUser.RoleNavigation.Id,
                    Name = dbUser.RoleNavigation.Name
                },

                //User epics will only have Id, Title, and Date set here.
                //If we want more details, get info through Epics repository.
                Epics = dbUser.Epics.Select(e => new Domain.Models.Epic
                {
                    ID = e.Id,
                    Title = e.Name,
                    Date = (DateTime)e.DateCreated
                })
            };

            return user;
        }
    }
}
