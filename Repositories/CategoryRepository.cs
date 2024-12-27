using EasyDeals.Data;
using EasyDeals.Data.Models;
using EasyDeals.DTOs.CategoryDTOs;
using EasyDeals.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyDeals.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext db;

    // DI contructor
    public CategoryRepository(ApplicationDbContext db)
    {
        this.db = db;
    }



    // CREATE
    public async Task<Category?> CreateAsync(Category category)
    {
        await db.Categories.AddAsync(category);
        await db.SaveChangesAsync();

        return category;
    }



    // READ
    public async Task<List<Category>?> GetAllAsync()
    {
        var categories = await db.Categories
            .Where(s => s.IsActive == true)
            .Include(s => s.ParentCategory)
            .ToListAsync();

        return categories;
    }



    // READ
    public async Task<Category?> GetByIdAsync(int id)
    {
        var category = await db.Categories.FindAsync(id);
        // ToDo include ParentCategory

        return category?.IsActive == true ? category : null;
    }



    // UPDATE
    public async Task<Category?> UpdateAsync(int id, UpdateCategoryDTO updateCategoryDTO)
    {
        var modelCategory = await db.Categories.FindAsync(id);

        // Checking IsActive (deleted or not)
        modelCategory = modelCategory?.IsActive == true ? modelCategory : null;

        if (modelCategory == null)
            return null;

        // Updating the fields
        modelCategory.Title = updateCategoryDTO.Title;
        modelCategory.IsActive = updateCategoryDTO.IsActive;
        modelCategory.ParentCategoryId = updateCategoryDTO.ParentCategoryId;
        modelCategory.UpdatedAt = DateTime.Now.ToUniversalTime();

        await db.SaveChangesAsync();

        return modelCategory;
    }



    // DELETE
    public async Task<Category?> DeleteAsync(int id)
    {
        var modelCategory = await db.Categories.FindAsync(id);

        // Checking IsActive (deleted or not)
        modelCategory = modelCategory?.IsActive == true ? modelCategory : null;

        if (modelCategory == null)
            return null;

        modelCategory!.IsActive = false;
        await db.SaveChangesAsync();

        return modelCategory;
    }
}
