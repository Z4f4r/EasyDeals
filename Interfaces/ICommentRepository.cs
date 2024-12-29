using EasyDeals.Data.Models;
using EasyDeals.DTOs.CommentDTOs;

namespace EasyDeals.Interfaces;

public interface ICommentRepository
{
    Task<List<Comment>> GetAllAsync();

    Task<Comment?> GetByIdAsync(int id);

    Task<Comment?> CreateAsync(Comment comment);

    Task<Comment?> UpdateAsync(int id, UpdateCommentDTO comment);

    Task<Comment?> DeleteAsync(int id);
}
