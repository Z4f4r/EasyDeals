using Microsoft.AspNetCore.Identity;

namespace EasyDeals.Data.Models;

public class AppUser : IdentityUser
{
    private List<Favorite> favorites = [];
    public List<Favorite> Favorites { get => favorites; set => favorites = value; }
}
