using BlogApi.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.IRepositories
{
    public interface IUser
    {
        /// <summary>
        /// Get User By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User? Get(string id);

        /// <summary>
        /// Get all User
        /// </summary>
        /// <returns></returns>
        List<User> Get();

        /// <summary>
        /// Delete User
        /// </summary>
        /// <param name="User"></param>
        void Delete(User User);

        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        User Create(User User);

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="User"></param>
        /// <returns></returns>
        User Update(string id, User User);
        
    }
}
