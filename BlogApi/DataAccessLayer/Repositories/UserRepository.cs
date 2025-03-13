using BlogApi.DomainLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class UserRepository
    {
        private readonly UserManager<User> _userManager;

        public UserRepository(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public List<User> users()
        {
            return _userManager.Users.ToList();
        }

        public async Task<User?> user(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<User> createUser(User user)
        {
            IdentityResult result = await _userManager.CreateAsync(user, user.PasswordHash);

            if (!result.Succeeded)
            {
                return null;
            }

            return user;
        }

        public async Task<User?> UpdateUser(User user)
        {
            IdentityResult result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                return null;
            }
            return user;
        }

        public async Task<bool> deleteUser(User user)
        {
            IdentityResult result = await _userManager.DeleteAsync(user);

            if (!result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public async Task<bool> AddUserToRole(User user, string roleName)
        {
            IdentityResult result = await _userManager.AddToRoleAsync(user, roleName);

            if (result.Succeeded)
            {
                return true;
            }

            return false;
        }
    }
}
