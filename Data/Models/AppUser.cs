using Microsoft.AspNetCore.Identity;

namespace EasyDeals.Data.Models;

public class AppUser : IdentityUser
{
    private string? lastName = "John";

    private string? firstName = "Doe";

    private int age;

    private string? avatar = null;

    private bool isActive = true;

    private DateTime createdAt = DateTime.Now.ToUniversalTime();

    private DateTime updatedAt = DateTime.Now.ToUniversalTime();

    private List<Favorite> favorites = [];


    // Getters and Setters
    public string? FirstName { get => firstName; set => firstName = value; }

    public string? LastName { get => lastName; set => lastName = value; }

    public int Age { get => age; set => age = value; }

    public string? Avatar { get => avatar; set => avatar = value; }

    public bool IsActive { get => isActive; set => isActive = value; }

    public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

    public DateTime UpdatedAt { get => updatedAt; set => updatedAt = value; }

    public List<Favorite> Favorites { get => favorites; set => favorites = value; }
}
