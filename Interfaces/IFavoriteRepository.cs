using EasyDeals.Data.Models;

namespace EasyDeals.Interfaces;

public interface IFavoriteRepository
{
    Task<List<Product>> GetUserFavorite(AppUser user);

    Task<Favorite?> CreateAsync(Favorite favorite);

    Task<Favorite?> DeleteFavorite(AppUser appUser, string title);
}
