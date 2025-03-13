using BusinessLogicLayer.Service;
using DataAccessLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.UnitOfWorkService
{
    public class UnitOfWorkService : IUnitOfWorkService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UnitOfWorkService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        private AuthorService _likeService;
        private BlogService _postService;
        private CategoryService _categoryService;
        private CommentService _commentService;
        private UserService _userService;

        public AuthorService authorService => _likeService ??= new AuthorService(_unitOfWork);

        public BlogService blogService => _postService ??= new BlogService(_unitOfWork);

        public CategoryService categoryService => _categoryService ??= new CategoryService(_unitOfWork);

        public CommentService commentService => _commentService ??= new CommentService(_unitOfWork);

        public UserService userService => _userService ??= new UserService(_unitOfWork);

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
