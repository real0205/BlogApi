using BusinessLogicLayer.Service;
using DataAccessLayer.Repositries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.UnitOfWorkServicesFolder
{
    public interface IUnitOfWorkService: IDisposable
    {
        CategoriesService categoryService { get; }
        CommentService commentService { get; }
        LikeService likeService { get; }
        PostService postService { get; }
        UserService userService { get; }
        AuthService authService { get;  }
    }
}
