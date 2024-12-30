using EasyDeals.Data.Models;
using EasyDeals.DTOs.ProductDTOs;
using EasyDeals.Helpers;

namespace EasyDeals.Interfaces;

public interface IProductRepository
{
    Task<List<Product>?> GetAllAsync(ProductQueryObject query);

    Task<Product?> GetByIdAsync(int id);

    Task<Product?> CreateAsync(Product product);

    Task<Product?> UpdateAsync(int id, UpdateProductDTO updateProductDTO);

    Task<Product?> DeleteAsync(int id);

    Task<Product?> GetByTitleAsync(string title);
}
