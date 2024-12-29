using EasyDeals.Data.Models;

namespace FinShark.DTOs.Account;

public class NewUserDTO
{
    private string userName = "JohnDoe";

    private string? firstName = "John";

    private string? lastName = "Doe";

    private int age;

    private string email = string.Empty;

    private string? phoneNumber = "+992 90 123 45 67";

    private string? avatar = null;

    private DateTime createdAt = DateTime.Now.ToUniversalTime();

    private string token = string.Empty;


    // Getters and Setters
    public string UserName { get => userName; set => userName = value; }

    public string? FirstName { get => firstName; set => firstName = value; }

    public string? LastName { get => lastName; set => lastName = value; }

    public int Age { get => age; set => age = value; }

    public string Email { get => email; set => email = value; }

    public string? PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

    public string? Avatar { get => avatar; set => avatar = value; }

    public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

    public string Token { get => token; set => token = value; }
}
