using System.ComponentModel.DataAnnotations;

namespace EasyDeals.DTOs.StateDTOs;

public class UpdateStateDTO 
{
    private string title = string.Empty;


    // Getters and Setters
    [Required]
    [MinLength(3, ErrorMessage = "Title must be 3 characters")]
    [MaxLength(25, ErrorMessage = "Title cannot be over 25 characters")]
    public string Title { get => title; set => title = value; }
}