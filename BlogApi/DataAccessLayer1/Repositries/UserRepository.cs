using DataAccessLayer.Data;
using DataAccessLayer.IRepositories;
using DomainLayer.Models;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositries
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext _applicationDbContext;

        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public User CreateUser(User user)
        {
            _applicationDbContext.Users.Add(user);
            _applicationDbContext.SaveChanges();
            return user;
        }

        public void DeleteUser(User user)
        {
            _applicationDbContext.Remove(user);
            _applicationDbContext.SaveChanges();
        }

        public List<User> GetAllUsers()
        {
            return _applicationDbContext.Users.ToList();
        }

        public User? GetUser(int id)
        {
            User? users = _applicationDbContext.Users.Find(id);
            return users;
        }

        public List<User> GetUserByRole(string role)
        {
            List<User> user = _applicationDbContext.Users.Where(fil => fil.Role.ToLower() == role.ToLower()).ToList();
            return user;
        }

        public User? Update(User user)
        {
            User? existingUser = _applicationDbContext.Users.Find(user.Id);



            existingUser.Username = user.Username;
            existingUser.Email = user.Email;
            existingUser.UpdateAt = user.UpdateAt;

            _applicationDbContext.Users.Update(existingUser);
            _applicationDbContext.SaveChanges();

            return existingUser;
        }
    }
}
