using EasyDeals.Data;
using EasyDeals.Data.Models;
using EasyDeals.DTOs.CategoryDTOs;
using EasyDeals.Helpers;
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
    public async Task<List<Category>?> GetAllAsync(CategoryQueryObject query)
    {
        var categories = db.Categories.AsQueryable();


        // Checking IsActive (deleted or not)
        categories = categories.Where(s => s.IsActive == true);


        // Filter
        if (!string.IsNullOrWhiteSpace(query.Title))
            categories = categories.Where(s => s.Title.Contains(query.Title));
        if (query.ParentCategoryId != null)
            categories = categories.Where(s => s.ParentCategoryId == query.ParentCategoryId);
        // ToDO (add CreatedAt and UpdatedAt filter)


        // Sorting
        if (!string.IsNullOrWhiteSpace(query.SortBy))
        {
            if (query.SortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                categories = query.IsDescending ? categories.OrderByDescending(s => s.Title) : categories.OrderBy(s => s.Title);
            else if (query.SortBy.Equals("CreatedAt", StringComparison.OrdinalIgnoreCase))
                categories = query.IsDescending ? categories.OrderByDescending(s => s.CreatedAt) : categories.OrderBy(s => s.CreatedAt);
            else if (query.SortBy.Equals("Date", StringComparison.OrdinalIgnoreCase))
                categories = query.IsDescending ? categories.OrderByDescending(s => s.UpdatedAt) : categories.OrderBy(s => s.UpdatedAt);
        }


        // Pagination
        var skipNumber = (query.PageNumber - 1) * query.PageSize;


        return await categories.Skip(skipNumber).Take(query.PageSize).ToListAsync();
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
