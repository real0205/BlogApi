using BusinessLogicLayer.MapperMethods;
using BusinessLogicLayer.Service;
using DataAccessLayer.UnitOfWorkFolder;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.UnitOfWorkServicesFolder
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        private readonly UserMapper _userMapper;
        public UnitOfWorkService(IUnitOfWork unitOfWork, IConfiguration configuration, UserMapper userMapper)
        {
            _unitOfWork = unitOfWork;
            _userMapper = userMapper;
            _configuration = configuration;
        }

        private CategoriesService _categoriesService;
        private CommentService _commentService;
        private LikeService _likeService;
        private PostService _postService;
        private UserService _userService;
        private AuthService _authService;

        public CategoriesService categoryService => _categoriesService ??= new CategoriesService(_unitOfWork);

        public CommentService commentService => _commentService ??= new CommentService(_unitOfWork);

        public LikeService likeService => _likeService ??= new LikeService(_unitOfWork);

        public PostService postService => _postService ??= new PostService(_unitOfWork);

        public UserService userService => _userService ??= new UserService(_unitOfWork);

        public AuthService authService => _authService ??= new AuthService(_configuration, _unitOfWork, _userMapper);
        public void Dispose()
        {
            _unitOfWork?.Dispose();

            GC.SuppressFinalize(this);
        }
    }
}
