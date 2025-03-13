using DataAccessLayer.Data;
using DomainLayer.Models.BlogModels;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DataAccessLayer.IRepositories;

namespace DataAccessLayer.Repositries
{
    public class CommentRepository: ICommentRepository
    {
        private ApplicationDbContext _applicationDbContext;
        public CommentRepository(ApplicationDbContext applicationDbContext)
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
            Comment? category = _applicationDbContext.Comments.Find(id);
            return null;
        }

        public List<Comment> Get()
        {
            return _applicationDbContext.Comments.ToList();
        }

        public Comment? Update(Comment comment)
        {
            Comment? existingComment = _applicationDbContext.Comments.Find(comment.Id);



            existingComment.Content = comment.Content;

            _applicationDbContext.Comments.Update(existingComment);
            _applicationDbContext.SaveChanges();

            return existingComment;
        }
    }
}
