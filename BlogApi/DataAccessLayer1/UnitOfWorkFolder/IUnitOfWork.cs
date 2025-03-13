using DataAccessLayer.Repositries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWorkFolder
{
    public interface IUnitOfWork: IDisposable
    {
        CategoryRepository categoryRepository { get; }
        CommentRepository commentRepository { get; }
        LikeRepository likeRepository { get;  }
        PostRepository postRepository { get;  }
        UserRepository userRepository { get; }
        SigningKeyRepository signingKeyRepository { get;  }

        Task<int> CompleteAsync();
    }
}
