using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUnitOfWork :IDisposable
    {
        AuthorRepository authorRepository { get; }
        BlogRepository blogRepository { get; }
        CategoryRepository categoryRepository { get; }
        CommentRepository commentRepository { get; }
    }
}
