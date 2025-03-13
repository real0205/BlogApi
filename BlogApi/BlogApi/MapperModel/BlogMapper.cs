using BlogApi.DomainLayer.Models;
using DomainLayer.DTO.BlogDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.MapperModel
{
    public class BlogMapper
    {
        public Blog MapBlogRequestToBlog(CreateRequestBlogDto createRequestBlogDto)
        {
            return new Blog
            {
                Post = createRequestBlogDto.Post,
                AuthorId = createRequestBlogDto.AuthorId,
                CategoryId = createRequestBlogDto.CategoryId,
                CommentId = createRequestBlogDto.CommentId,
                UserId = createRequestBlogDto.UserId,
            };
        }

        public BlogDto MapBlogToBlogDto(Blog Blog)
        {
            return new BlogDto
            {
                Post = Blog.Post,
                AuthorId = Blog.AuthorId,
                CategoryId = Blog.CategoryId,
                CommentId = Blog.CommentId,
                UserId = Blog.UserId,
            };
        }

        public Blog MapUpdateBlogDtoToBlog(UpdateBlogDto updateBlogDto)
        {
            return new Blog
            {
                Post = updateBlogDto.Post,
                AuthorId = updateBlogDto.AuthorId,
                CategoryId = updateBlogDto.CategoryId,
                CommentId = updateBlogDto.CommentId,
                UserId = updateBlogDto.UserId,
            };
        }
    }
}
