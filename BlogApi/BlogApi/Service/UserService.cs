using BlogApi.DomainLayer.Models;
using BusinessLogicLayer.IService;
using DataAccessLayer.Data.IRepositories;
using DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class UserService : IUserService
    {
        //UserRepository _categoryRepository;

        private readonly IUser _userRepository;

        public UserService(IUser userRepository)
        {
            _userRepository = userRepository;
        }

        public UserService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        public User? CreateUser(User user, out string message)
        {
            if (string.IsNullOrWhiteSpace(user.firstname))
            {
                message = "First Name cannot be empty";
                return null;
            }

            if (string.IsNullOrWhiteSpace(user.lastname))
            {
                message = "Last Name cannot be empty";
                return null;
            }

            if (user.dob == null)
            {
                message = "DOB cannot be empty";
                return null;
            }

            message = "Created Successfuly";
            ; return _userRepository.Create(user);
        }

        public bool DeleteUser(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            User? user = _userRepository.Get(id);

            if (user == null)
            {
                return false;
            }

            _userRepository.Delete(user);
            return true;
        }

        public List<User> GetAllUser()
        {
            return _userRepository.Get();
        }

        public User? GetUser(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return null;
            }
            return _userRepository.Get(id);
        }

        public User? UpdateUser(User user, out string message)
        {

            if (string.IsNullOrWhiteSpace(user.firstname))
            {
                message = "First Name is required";
                return null;
            }

            User? updatedUser = _userRepository.Get(user.Id);

            if (updatedUser is null)
            {
                message = "User not found";
                return null;
            }
            message = "User Updated Successfully";
            return updatedUser;
        }
    }
}
