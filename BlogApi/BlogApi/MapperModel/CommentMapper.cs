using BlogApi.DomainLayer.Models;
using DomainLayer.DTO.CommentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.MapperModel
{
    public class CommentMapper
    {
        public Comment MapCommentRequestToComment(CreateRequestCommentDto createRequestCommentDto)
        {
            return new Comment
            {
                Comments = createRequestCommentDto.Comments,
            };
        }

        public CommentDto MapCommentToCommentDto(Comment Comment)
        {
            return new CommentDto
            {
                Comments = Comment.Comments,
            };
        }

        public Comment MapUpdateCommentDtoToComment(UpdateCommentDto updateCommentDto)
        {
            return new Comment
            {
                Comments = updateCommentDto.Comments,
            };
        }
    }
}
