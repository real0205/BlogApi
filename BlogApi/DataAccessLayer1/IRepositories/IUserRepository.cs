using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.IRepositories
{
    public interface IUserRepository
    {
        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>user Object by Id</returns>
        User? GetUser(int id);

        /// <summary>
        /// Get user by role
        /// </summary>
        /// <param name="role"></param>
        /// <returns>user Object by Id</returns>
        List<User> GetUserByRole(string role);


        /// <summary>
        /// All users
        /// </summary>
        /// <returns>List of users</returns>
        List<User> GetAllUsers();



        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="user"></param>
        void DeleteUser(User user);


        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="user"></param>
        /// <returns>User Object</returns>
        User CreateUser(User user);

        /// <summary>
        /// Update user Details
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Updated Object</returns>
        User? Update(User user);
    }
}
