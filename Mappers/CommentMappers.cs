using EasyDeals.Data.Models;
using EasyDeals.DTOs.CommentDTOs;

namespace EasyDeals.Mappers;

public static class CommentMappers
{
    public static CommentDTO ToCommentDTO(this Comment comment)
    {
        return new CommentDTO
        {
            Id = comment.Id,
            Body = comment.Body,
            CreatedAt = comment.CreatedAt,
            UpdatedAt = comment.UpdatedAt,
            UserId = comment.UserId,
            ProductId = comment.ProductId
        };
    }

    public static Comment ToCommentFromCreate(this CreateCommentDTO comment, int productId)
    {
        return new Comment
        {
            Body = comment.Body,
            ProductId = productId
        };
    }

    // public static Comment ToCommentFromUpdate(this UpdateCommentDTO comment)
    // {
    //     return new Comment
    //     {
    //         Body = comment.Body
    //     };
    // }
}
