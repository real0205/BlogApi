using DataAccessLayer.Data;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositries;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.UnitOfWorkFolder
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private ApplicationDbContext _applicationDbContext;
        public UnitOfWork(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        private CategoryRepository _categoryRepository;
        private CommentRepository _commentRepository;
        private LikeRepository _likeRepository;
        private PostRepository _postRepository;
        private UserRepository _userRepository;
        private SigningKeyRepository _signingKeyRepository;

        public CategoryRepository categoryRepository => _categoryRepository ??= new CategoryRepository(_applicationDbContext);

        public CommentRepository commentRepository => _commentRepository ??= new CommentRepository(_applicationDbContext);

        public LikeRepository likeRepository => _likeRepository ??= new LikeRepository(_applicationDbContext);

        public PostRepository postRepository => _postRepository ??= new PostRepository(_applicationDbContext);

        public UserRepository userRepository => _userRepository ??= new UserRepository(_applicationDbContext);
        public SigningKeyRepository signingKeyRepository => _signingKeyRepository ??= new SigningKeyRepository(_applicationDbContext);

        public async Task<int> CompleteAsync()
        {
            return await _applicationDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _applicationDbContext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
