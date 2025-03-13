using BusinessLogicLayer.Service;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.UnitOfWorkService
{
    public class IUnitOfWorkService : IDisposable
    {
        AuthorService likeService { get; }
        BlogService postService { get; }
        CategoryService categoryService { get; }
        CommentService commentService { get; }
        UserService userService { get; }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
