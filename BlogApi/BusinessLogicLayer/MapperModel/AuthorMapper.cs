using BlogApi.DomainLayer.Models;
using DomainLayer.DTO.AuthorDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.MapperModel
{
    public class AuthorMapper
    {
        public Author MapAuthorRequestToAuthor(CreateRequestAuthorDto createRequestAuthorDto)
        {
            return new Author
            {
                FirstName = createRequestAuthorDto.FirstName,
                LastName = createRequestAuthorDto.LastName,
                Password = createRequestAuthorDto.Password,
            };
        }

        public AuthorDto MapAuthorToAuthorDto(Author author)
        {
            return new AuthorDto
            {
                FirstName = author.FirstName,
                LastName = author.LastName,
                Password = author.Password,
            };
        }

        public Author MapUpdateAuthorDtoToAuthor(UpdateAuthorDto updateAuthorDto)
        {
            return new Author
            {
                FirstName = updateAuthorDto.FirstName,
                LastName = updateAuthorDto.LastName,
                Password = updateAuthorDto.Password,
            };
        }
    }
}
