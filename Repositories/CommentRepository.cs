using EasyDeals.Data;
using EasyDeals.Data.Models;
using EasyDeals.DTOs.CommentDTOs;
using EasyDeals.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyDeals.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly ApplicationDbContext db;

    public CommentRepository(ApplicationDbContext db)
    {
        this.db = db;
    }



    // CREATE
    public async Task<Comment?> CreateAsync(Comment comment)
    {
        await db.Comments.AddAsync(comment);
        await db.SaveChangesAsync();

        return comment;
    }



    // READ
    public async Task<List<Comment>> GetAllAsync()
    {
        return await db.Comments.Where(s => s.IsActive == true).Include(a => a.AppUser).ToListAsync();
    }



    // READ
    public async Task<Comment?> GetByIdAsync(int id)
    {
        return await db.Comments
            .Where(s => s.IsActive == true)
            .Include(a => a.AppUser)
            .FirstOrDefaultAsync(c => c.Id == id);
    }



    // UPDATE
    public async Task<Comment?> UpdateAsync(int id, UpdateCommentDTO comment)
    {
        var existingComment = await db.Comments
            .Where(s => s.IsActive == true)
            .Include(a => a.AppUser)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (existingComment == null)
            return null;

        // Updating the fields
        existingComment.Body = comment.Body;
        existingComment.UpdatedAt = DateTime.Now.ToUniversalTime();

        await db.SaveChangesAsync();

        return existingComment;
    }



    // DELETE
    public async Task<Comment?> DeleteAsync(int id)
    {
        var modelComment = await db.Comments.Include(x => x.AppUser).FirstOrDefaultAsync(c => c.Id == id);

        // Checking IsActive (deleted or not)
        modelComment = modelComment?.IsActive == true ? modelComment : null;

        if (modelComment == null)
            return null;

        modelComment!.IsActive = false;
        await db.SaveChangesAsync();

        return modelComment;
    }
}
