using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.IService
{
    public interface IUserService
    {
        /// <summary>
        /// Crease A user and display the output
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        User? CreateUser(User user, out string message);

        /// <summary>
        /// Get users by role
        /// </summary>
        /// <param name="role"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        List<User> GetUserByRole(string role, out string message);

        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        bool DeleteUser(int id, out string message);

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        List<User> GetAllUsers();

        /// <summary>
        /// Get user by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        
        User? GetUser(int id);
        /// <summary>
        /// Update user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        User? UpdateUser(User user, out string message);
    }
}
