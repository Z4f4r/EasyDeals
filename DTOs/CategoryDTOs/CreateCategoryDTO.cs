using System.ComponentModel.DataAnnotations;

namespace EasyDeals.DTOs.CategoryDTOs;

public class CreateCategoryDTO
{
    private string title = string.Empty;

    private bool isActive = true;

    private int? parentCategoryId = null;



    [Required]
    [MinLength(2, ErrorMessage = "Title must be 2 characters")]
    [MaxLength(25, ErrorMessage = "Title cannot be over 25 characters")]
    public string Title { get => title; set => title = value; }

    [Required]
    public bool IsActive { get => isActive; set => isActive = value; }

    public int? ParentCategoryId { get => parentCategoryId; set => parentCategoryId = value; }
}
