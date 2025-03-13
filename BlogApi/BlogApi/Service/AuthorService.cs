using BlogApi.DomainLayer.Models;
using BusinessLogicLayer.IService;
using DataAccessLayer.Data.IRepositories;
using DataAccessLayer.UnitOfWork;
using DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Service
{
    public class AuthorService : IAuthorService
    {
        //AuthorRepository _authorRepository;

        private readonly IAuthor _authorRepository;

        public AuthorService(IAuthor authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public AuthorService(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get; }

        public Author? CreateAuthor(Author author, out string message)
        {
            if (string.IsNullOrWhiteSpace(author.FirstName))
            {
                message = "First Name cannot be empty";
                return null;
            }

            if (string.IsNullOrWhiteSpace(author.LastName))
            {
                message = "Last Name cannot be empty";
                return null;
            }

            if (string.IsNullOrWhiteSpace(author.Password))
            {
                message = "Password cannot be empty";
                return null;
            }

            message = "Created Successfuly";
            ; return _authorRepository.Create(author);
        }

        public bool DeleteAuthor(int id)
        {
            if (id <= 0)
            {
                return false;
            }

            Author? author = _authorRepository.Get(id);

            if (author == null)
            {
                return false;
            }

            _authorRepository.Delete(author);
            return true;
        }

        public List<Author> GetAllAuthor()
        {
            return _authorRepository.Get();
        }

        public Author? GetAuthor(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _authorRepository.Get(id);
        }

        public Author? UpdateAuthor(Author author, out string message)
        {
            if (string.IsNullOrWhiteSpace(author.FirstName))
            {
                message = "First Name is required";
                return null;
            }

            if (string.IsNullOrWhiteSpace(author.LastName))
            {
                message = "Last Name is required";
                return null;
            }

            if (string.IsNullOrWhiteSpace(author.Password))
            {
                message = "Password is required";
                return null;
            }

            Author? updatedAuthor = _authorRepository.Get(author.Id);

            if (updatedAuthor is null)
            {
                message = "Author not found";
                return null;
            }
            message = "Author Updated Successfully";
            return updatedAuthor;
        }
    }
}
