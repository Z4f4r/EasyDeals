using System.ComponentModel.DataAnnotations.Schema;

namespace EasyDeals.Data.Models;

[Table("Favorites")]
public class Favorite
{
    private string? appUserId;

    private int productId;

    private AppUser? appUser;

    private Product? product;


    // Getters and Setters
    public string? AppUserId { get => appUserId; set => appUserId = value; }

    public int ProductId { get => productId; set => productId = value; }

    public AppUser? AppUser { get => appUser; set => appUser = value; }

    public Product? Product { get => product; set => product = value; }
}
