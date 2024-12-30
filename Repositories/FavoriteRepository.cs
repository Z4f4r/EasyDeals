using EasyDeals.Data;
using EasyDeals.Data.Models;
using EasyDeals.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyDeals.Repositories;

public class FavoriteRepository : IFavoriteRepository
{
    private readonly ApplicationDbContext db;

    // DI contsructor
    public FavoriteRepository(ApplicationDbContext db)
    {
        this.db = db;
    }



    // READ
    public async Task<List<Product>> GetUserFavorite(AppUser user)
    {
        return await db.Favorites.Where(u => u.AppUserId == user.Id)
            .Select(favorite => new Product 
            {
                Id = favorite.ProductId,
                Title = favorite.Product!.Title!,
                Description = favorite.Product!.Description!,
                Price = favorite.Product!.Price!,
                Views = favorite.Product!.Views!,
                Image_1 = favorite.Product.Image_1,
                Image_2 = favorite.Product.Image_2,
                Image_3 = favorite.Product.Image_3,
                CreatedAt = favorite.Product!.CreatedAt,
                UpdatedAt = favorite.Product!.UpdatedAt,
                CategoryId = favorite.Product!.CategoryId!,
                UserId = favorite.Product!.UserId!,
                CityId = favorite.Product!.CityId!,
                StateId = favorite.Product!.StateId!,
            }).ToListAsync();
    }



    // CREATE
    public async Task<Favorite?> CreateAsync(Favorite favorite)
    {
        await db.Favorites.AddAsync(favorite);
        await db.SaveChangesAsync();

        return favorite;
    }



    // DELETE
    public async Task<Favorite?> DeleteFavorite(AppUser appUser, string title)
    {
        var favoriteModel = await db.Favorites.FirstOrDefaultAsync(
            x => x.AppUserId == appUser.Id && x.Product!.Title.ToLower() == title.ToLower());

        if (favoriteModel == null)
            return null;

        db.Favorites.Remove(favoriteModel);
        await db.SaveChangesAsync();

        return favoriteModel;
    }
}
