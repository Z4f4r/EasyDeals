using System.ComponentModel.DataAnnotations;

namespace FinShark.DTOs.Account;

public class RegisterDTO
{
    private string userName = "JohnDoe";

    private string password = "Password_example_1";

    private string? firstName = "John";

    private string? lastName = "Doe";

    private int age;

    private string email = string.Empty;

    private string? phoneNumber = "+992 90 123 45 67";

    private string? avatar = null;


    // Getters and Setters
    [Required]
    public string UserName { get => userName; set => userName = value; }

    [Required]
    public string Password { get => password; set => password = value; }

    [MinLength(3, ErrorMessage = "First name must be 3 characters")]
    [MaxLength(25, ErrorMessage = "First name cannot be over 25 characters")]
    public string? FirstName { get => firstName; set => firstName = value; }

    [MinLength(3, ErrorMessage = "Last name must be 3 characters")]
    [MaxLength(25, ErrorMessage = "Last name cannot be over 25 characters")]
    public string? LastName { get => lastName; set => lastName = value; }

    [Required]
    public int Age { get => age; set => age = value; }

    [Required]
    [EmailAddress]
    public string Email { get => email; set => email = value; }

    [MinLength(9, ErrorMessage = "Phone number must be 3 characters")]
    [MaxLength(25, ErrorMessage = "Phone number cannot be over 25 characters")]
    public string? PhoneNumber { get => phoneNumber; set => phoneNumber = value; }

    [MaxLength(255, ErrorMessage = "Image URL cannot be over 255 characters")]
    public string? Avatar { get => avatar; set => avatar = value; }
}
