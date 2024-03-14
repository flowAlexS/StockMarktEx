using Api.DTOs.Comment;
using Api.Models;

namespace Api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment comment)
        => new()
        {
            Id = comment.Id,
            Title = comment.Title,
            Content = comment.Content,
            CreatedOn = comment.CreatedOn,
            StockId = comment.StockId,
        };
    }
}
