using System.ComponentModel.DataAnnotations.Schema;

namespace EasyDeals.Data.Models;

[Table("Favorites")]
public class Favorite
{
    private string? appUserId;

    private int productId;

    private AppUser? appUser;

    private Product? product;



    public string? AppUserId { get; set; }

    public int ProductId { get; set; }

    public AppUser? AppUser { get; set; }

    public Product? Product { get; set; }
}
