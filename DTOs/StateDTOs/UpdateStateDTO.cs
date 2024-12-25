using System.ComponentModel.DataAnnotations;

namespace EasyDeals.DTOs.StateDTOs;

public class UpdateStateDTO 
{
    private string title = string.Empty;

    private bool isActive = true;



    [Required]
    [MinLength(5, ErrorMessage = "Title must be 5 characters")]
    [MaxLength(25, ErrorMessage = "Title cannot be over 25 characters")]
    public string Title { get => title; set => title = value; }

    [Required]
    public bool IsActive { get => isActive; set => isActive = value; }
}