using EasyDeals.Data.Models;
using EasyDeals.DTOs.CategoryDTOs;

namespace EasyDeals.Mappers;

public static class CategoryMapper
{
    public static CategoryDTO ToCategoryDTO(this Category category)
    {
        return new CategoryDTO
        {
            Id = category.Id,
            Title = category.Title,
            CreatedAt = category.CreatedAt,
            UpdatedAt = category.UpdatedAt,
            IsActive = category.IsActive,
            ParentCategoryId = category.ParentCategoryId != 0 ? category.ParentCategoryId : null,
            Products = category.Products
            // ToDO Each Product to ProductDTO
        };
    }

    public static Category ToCategoryFromCreate(this CreateCategoryDTO createCategoryDTO)
    {
        return new Category
        {
            Title = createCategoryDTO.Title,
            IsActive = createCategoryDTO.IsActive,
            ParentCategoryId = createCategoryDTO.ParentCategoryId != 0 ? createCategoryDTO.ParentCategoryId : null
        };
    }
}
