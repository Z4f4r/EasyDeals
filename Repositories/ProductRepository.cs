using EasyDeals.Data;
using EasyDeals.Data.Models;
using EasyDeals.DTOs.ProductDTOs;
using EasyDeals.Helpers;
using EasyDeals.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyDeals.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext db;

    // DI constructor
    public ProductRepository(ApplicationDbContext db)
    {
        this.db = db;
    }



    // CREATE
    public async Task<Product?> CreateAsync(Product product)
    {
        await db.Products.AddAsync(product);
        await db.SaveChangesAsync();

        return product;
    }



    // READ
    public async Task<List<Product>?> GetAllAsync(ProductQueryObject query)
    {
        var products = db.Products
            .Include(a => a.AppUser)
            .Include(a => a.Comments).ThenInclude(a => a.AppUser)
            .AsQueryable();


        // Checking IsActive (deleted or not)
        products = products.Where(s => s.IsActive == true);


        // Filter
        if (!string.IsNullOrWhiteSpace(query.Title))
            products = products.Where(s => s.Title.Contains(query.Title));
        if (!string.IsNullOrWhiteSpace(query.Description))
            products = products.Where(s => s.Description.Contains(query.Description));
        if (query.Price != null)
            products = products.Where(s => s.Price == query.Price);
        if (query.CategoryId != null)
            products = products.Where(s => s.CategoryId == query.CategoryId);
        if (!string.IsNullOrWhiteSpace(query.UserId))
            products = products.Where(s => s.UserId.Contains(query.UserId));
        if (query.CityId != null)
            products = products.Where(s => s.CityId == query.CityId);
        if (query.StateId != null)
            products = products.Where(s => s.StateId == query.StateId);
        // ToDO (add CreatedAt and UpdatedAt filter)


        // Sorting
        if (!string.IsNullOrWhiteSpace(query.SortBy))
        {
            if (query.SortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                products = query.IsDescending ? products.OrderByDescending(s => s.Title) : products.OrderBy(s => s.Title);
            else if (query.SortBy.Equals("Description", StringComparison.OrdinalIgnoreCase))
                products = query.IsDescending ? products.OrderByDescending(s => s.Description) : products.OrderBy(s => s.Description);
            else if (query.SortBy.Equals("Price", StringComparison.OrdinalIgnoreCase))
                products = query.IsDescending ? products.OrderByDescending(s => s.Price) : products.OrderBy(s => s.Price);
            else if (query.SortBy.Equals("Views", StringComparison.OrdinalIgnoreCase))
                products = query.IsDescending ? products.OrderByDescending(s => s.Views) : products.OrderBy(s => s.Views);
            else if (query.SortBy.Equals("CreatedAt", StringComparison.OrdinalIgnoreCase))
                products = query.IsDescending ? products.OrderByDescending(s => s.CreatedAt) : products.OrderBy(s => s.CreatedAt);
            else if (query.SortBy.Equals("Date", StringComparison.OrdinalIgnoreCase))
                products = query.IsDescending ? products.OrderByDescending(s => s.UpdatedAt) : products.OrderBy(s => s.UpdatedAt);
        }


        // Pagination
        var skipNumber = (query.PageNumber - 1) * query.PageSize;


        return await products.Skip(skipNumber).Take(query.PageSize).ToListAsync();
    }



    // READ
    public async Task<Product?> GetByIdAsync(int id)
    {
        var product = await db.Products
            .Include(a => a.AppUser)
            .Include(a => a.Comments).ThenInclude(a => a.AppUser)
            .FirstOrDefaultAsync(x => x.Id == id);

        return product?.IsActive == true ? product : null;
    }



    // UPDATE
    public async Task<Product?> UpdateAsync(int id, UpdateProductDTO updateProductDTO)
    {
        var productModel = await db.Products.FindAsync(id);
        
        if (productModel == null || productModel.IsActive == false)
            return null;

        // Updating the fields
        productModel.Title = updateProductDTO.Title;
        productModel.Description = updateProductDTO.Description;
        productModel.Price = updateProductDTO.Price;
        productModel.Image_1 = updateProductDTO.Image_1;
        productModel.Image_2 = updateProductDTO.Image_2;
        productModel.Image_3 = updateProductDTO.Image_3;
        productModel.UpdatedAt = DateTime.Now.ToUniversalTime();
        productModel.CategoryId = updateProductDTO.CategoryId;
        productModel.CityId = updateProductDTO.CityId;
        productModel.StateId = updateProductDTO.StateId;

        await db.SaveChangesAsync();

        return productModel;
    }



    // DELETE
    public async Task<Product?> DeleteAsync(int id)
    {
        var productModel = await db.Products.FindAsync(id);

        if (productModel == null || productModel.IsActive == false)
            return null;

        productModel!.IsActive = false;
        await db.SaveChangesAsync();

        return productModel;
    }
}
