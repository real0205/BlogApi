using BlogApi.DataAccessLayer.Data;
using BlogApi.DomainLayer.Models;
using DataAccessLayer.Data.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class CommentRepository : IComment
    {
        private readonly ApplicationDBContext _applicationDbContext;

        public CommentRepository(ApplicationDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Comment Create(Comment comment)
        {
            _applicationDbContext.Comments.Add(comment);
            _applicationDbContext.SaveChanges();

            return comment;
        }

        public void Delete(Comment comment)
        {
            _applicationDbContext.Remove(comment);
            _applicationDbContext.SaveChanges();
        }

        public Comment? Get(int id)
        {
            Comment? comment = _applicationDbContext.Comments.Find(id);
            return comment;
        }

        public List<Comment> Get()
        {
            return _applicationDbContext.Comments.ToList();
        }

        public Comment Update(int id, Comment comment)
        {
            Comment existingComment = _applicationDbContext.Comments.Find(id);

            if (existingComment == null)
            {
                return null;
            }

            existingComment.Comments = comment.Comments;

            _applicationDbContext.Comments.Update(existingComment);
            _applicationDbContext.SaveChanges();

            return comment;
        }
    }
}
