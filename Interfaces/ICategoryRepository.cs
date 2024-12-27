using EasyDeals.Data.Models;
using EasyDeals.DTOs.CategoryDTOs;

namespace EasyDeals.Interfaces;

public interface ICategoryRepository
{
    Task<List<Category>?> GetAllAsync();

    Task<Category?> GetByIdAsync(int id);

    Task<Category?> CreateAsync(Category category);

    Task<Category?> UpdateAsync(int id, UpdateCategoryDTO updateCategoryDTO);

    Task<Category?> DeleteAsync(int id);
}
