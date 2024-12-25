using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyDeals.Data.Models;

[Table("Products")]
public class Product
{
    private int id;

    private string title = string.Empty;

    private string description = string.Empty;

    [Column(TypeName = "decimal(18, 2)")]
    private decimal price;

    private string? image_1;

    private string? image_2;

    private string? image_3;

    private long views;

    private bool isActive = true;

    private DateTime createdAt = DateTime.Now.ToUniversalTime();

    private DateTime updatedAt = DateTime.Now.ToUniversalTime();

    private int categoryId;

    private int userId;

    private int cityId;

    private int stateId;

    private Category? category;

    private AppUser? appUser;

    private City? city;

    private State? state;

    private List<Favorite> favorites = [];



    public int Id { get => id; set => id = value; }

    public string Title { get => title; set => title = value; }

    public string Description { get => description; set => description = value; }

    public decimal Price { get => price; set => price = value; }

    public long Views { get => views; set => views = value; }

    public bool IsActive { get => isActive; set => isActive = value; }

    public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

    public DateTime UpdatedAt { get => updatedAt; set => updatedAt = value; }

    public int CategoryId { get => categoryId; set => categoryId = value; }

    public int UserId { get => userId; set => userId = value; }

    public int CityId { get => cityId; set => cityId = value; }

    public int StateId { get => stateId; set => stateId = value; }

    public Category? Category { get => category; set => category = value; }

    public AppUser? AppUser { get => appUser; set => appUser = value; }

    public City? City { get => city; set => city = value; }

    public State? State { get => state; set => state = value; }

    public List<Favorite> Favorites { get => favorites; set => favorites = value; }
}
