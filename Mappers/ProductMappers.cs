using EasyDeals.Data.Models;
using EasyDeals.DTOs.ProductDTOs;

namespace EasyDeals.Mappers;

public static class ProductMappers
{
    public static ProductDTO ToProductDTO(this Product product)
    {
        return new ProductDTO
        {
            Id = product.Id,
            Title = product.Title,
            Description = product.Description,
            Price = product.Price,
            Image_1 = product.Image_1,
            Image_2 = product.Image_2,
            Image_3 = product.Image_3,
            Views = product.Views,
            CreatedAt = product.CreatedAt,
            UpdatedAt = product.UpdatedAt,
            CategoryId = product.CategoryId,
            UserId = product.UserId,
            CityId = product.CityId,
            StateId = product.StateId,
            Comments = product.Comments.Select(c => c.ToCommentDTO()).ToList(),
            Favorites = product.Favorites
            // ToDo Each Favorite to FavoriteDTO
        };
}

    public static Product ToProductFromCreate(this CreateProductDTO createProductDTO)
    {
        return new Product
        {
            Title = createProductDTO.Title,
            Description = createProductDTO.Description,
            Price = createProductDTO.Price,
            Image_1 = createProductDTO.Image_1,
            Image_2 = createProductDTO.Image_2, 
            Image_3 = createProductDTO.Image_3,
            CategoryId = createProductDTO.CategoryId,
            CityId = createProductDTO.CityId,
            StateId = createProductDTO.StateId
        };
    }
}
