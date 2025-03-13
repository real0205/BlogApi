using BlogApi.DataAccessLayer.Data;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDBContext _applicationDbContext;
        public UnitOfWork(ApplicationDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        private AuthorRepository _authorRepository;
        private BlogRepository _blogRepository;
        private CategoryRepository _categoryRepository;
        private CommentRepository _commentRepository;
        private RoleRepository _roleRepository;
        private UserRepository _userRepository;

        public AuthorRepository authorRepository => _authorRepository ??= new AuthorRepository(_applicationDbContext);

        public BlogRepository blogRepository => _blogRepository ??= new BlogRepository(_applicationDbContext);

        public CategoryRepository categoryRepository => _categoryRepository ??= new CategoryRepository(_applicationDbContext);

        public CommentRepository commentRepository => _commentRepository ??= new CommentRepository(_applicationDbContext);

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
