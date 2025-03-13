using DomainLayer.DTO.PostDTO;
using DomainLayer.DTO.UserDTO;
using DomainLayer.Models.BlogModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.MapperMethods
{
    public class PostMapper
    {
        public Post MapCreatePostRequestToUser(CreatePostRequest CreatePostDto)
        {
            return new Post
            {
                Title = CreatePostDto.Title,
                Content = CreatePostDto.Content,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                AuthorId = CreatePostDto.AuthorId,
                CategoryId = CreatePostDto.CategoryId,
            };
        }
        public Post MapUpdatePostRequestToUser(UpdatePostRequest updateRequestPostDto)
        {
            return new Post
            {
                Id = updateRequestPostDto.Id,
                Title = updateRequestPostDto.Title,
                Content = updateRequestPostDto.Content,
                UpdatedAt = DateTime.Now,
                CategoryId = updateRequestPostDto.CategoryId
            };
        }

        public PostDto MapPostToPostDto(Post post)
        {
            return new PostDto
            {
                Title = post.Title,
                Content = post.Content,
                CreatedAt = post.CreatedAt,
                AuthorId = post.AuthorId,
                CategoryId = post.CategoryId
            };
        }
        public Post MapDeletePostRequestToCategory(DeletePostRequest deleteRequestPostDto)
        {
            return new Post
            {
                Id = deleteRequestPostDto.Id
            };
        }
    }
}
