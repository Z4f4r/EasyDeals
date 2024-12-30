using EasyDeals.Data.Models;
using EasyDeals.DTOs.CategoryDTOs;
using EasyDeals.Helpers;

namespace EasyDeals.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>?> GetAllAsync(CategoryQueryObject query);

    Task<Category?> GetByIdAsync(int id);

    Task<Category?> CreateAsync(Category category);

    Task<Category?> UpdateAsync(int id, UpdateCategoryDTO updateCategoryDTO);

    Task<Category?> DeleteAsync(int id);

    Task<bool> CategoryExists(int id);
}