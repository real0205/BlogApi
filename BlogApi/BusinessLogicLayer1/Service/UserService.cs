using BusinessLogicLayer.IService;
using DataAccessLayer.UnitOfWorkFolder;
using DomainLayer.Models.BlogModels;

namespace BusinessLogicLayer.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public User? CreateUser(User user, out string message)
        {
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                message = "Userame cannot be empty";
                return null;
            }

            if (string.IsNullOrWhiteSpace(user.Email))
            {
                message = "Email Cannot be empty";
                return null;
            }
            if (string.IsNullOrWhiteSpace(user.Password))
            {
                message = "Email Cannot be empty";
                return null;
            }
            // Hash the password using BCrypt.
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

            user.Password = hashedPassword;

            User result = _unitOfWork.userRepository.CreateUser(user);
            message = "Successful";
            return result;
        }



        public bool DeleteUser(int id, out string message)
        {
            if (id <= 0)
            {
                message = "Invalid";
                return false;
            }

            User? UserData = _unitOfWork.userRepository.GetUser(id);

            if (UserData == null)
            {
                message = "Return a Number";
                return false;
            }

            _unitOfWork.userRepository.DeleteUser(UserData);

            message = "Deleted Successfully";
            return true;

        }

        public List<User> GetAllUsers()
        {
            return _unitOfWork.userRepository.GetAllUsers();
        }

        public User? GetUser(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _unitOfWork.userRepository.GetUser(id);
        }

        public List<User> GetUserByRole(string role, out string message)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                message = "Username is Required";
                return null;
            }

            List<User> result = _unitOfWork.userRepository.GetUserByRole(role);

            if (result == null)
            {
                message = "User role not found";
                return null;
            }

            message = "Successfully fetched users";
            return result;
        }

        public User? UpdateUser(User user, out string message)
        {
            if (user.Id <= 0)
            {
                message = "Invalid Id";
                return null;
            }

            if (string.IsNullOrWhiteSpace(user.Username))
            {
                message = "Username is Required";
                return null;
            }

            if (string.IsNullOrWhiteSpace(user.Email))
            {
                message = "Name is Required";
                return null;
            }

            User? updatedUSer = _unitOfWork.userRepository.Update(user);

            if (updatedUSer is null)
            {
                message = "User not found";
                return null;
            }

            message = "Successfully Upated user";
            return updatedUSer;
        }
    }
}
