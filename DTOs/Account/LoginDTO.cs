using System.ComponentModel.DataAnnotations;

namespace FinShark.DTOs.Account;

public class LoginDTO
{
    private string userName = "JohnDoe";

    private string password = "Password_example_1";


    // Getters and Setters
    [Required]
    public string UserName { get => userName; set => userName = value; }

    [Required]
    public string Password { get => password; set => password = value; }
}
