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
    public class AuthorRepository : IAuthor
    {
        private readonly ApplicationDBContext _applicationDbContext;

        public AuthorRepository(ApplicationDBContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public Author Create(Author author)
        {
            _applicationDbContext.Authors.Add(author);
            _applicationDbContext.SaveChanges();

            return author;
        }

        public void Delete(Author author)
        {
            _applicationDbContext.Remove(author);
            _applicationDbContext.SaveChanges();
        }

        public Author? Get(int id)
        {
            Author? author = _applicationDbContext.Authors.Find(id);
            return author;
        }

        public List<Author> Get()
        {
            return _applicationDbContext.Authors.ToList();
        }

        public Author Update(int id, Author author)
        {
            Author existingAuthor = _applicationDbContext.Authors.Find(id);

            if (existingAuthor == null)
            {
                return null;
            }

            existingAuthor.FirstName = author.FirstName;
            existingAuthor.LastName = author.LastName;
            existingAuthor.Password = author.Password;

            _applicationDbContext.Authors.Update(existingAuthor);
            _applicationDbContext.SaveChanges();

            return author;
        }

    }
}
