using EasyDeals.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace EasyDeals.DTOs.CityDTOs;

public class CityDTO
{
    private int id;

    private string title = string.Empty;

    private bool isActive = true;

    private DateTime createdAt = DateTime.Now.ToUniversalTime();

    private DateTime updatedAt = DateTime.Now.ToUniversalTime();

    private List<Product> products = [];



    [Key]
    public int Id { get => id; set => id = value; }

    [Required]
    [MinLength(5, ErrorMessage = "Title must be 5 characters")]
    [MaxLength(25, ErrorMessage = "Title cannot be over 25 characters")]
    public string Title { get => title; set => title = value; }

    [Required]
    public bool IsActive { get => isActive; set => isActive = value; }

    public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

    public DateTime UpdatedAt { get => updatedAt; set => updatedAt = value; }

    public List<Product> Products { get => products; set => products = value; }
}
