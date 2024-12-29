using EasyDeals.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace EasyDeals.DTOs.CityDTOs;

public class CityDTO
{
    private int id;

    private string title = string.Empty;

    private DateTime createdAt = DateTime.Now.ToUniversalTime();

    private DateTime updatedAt = DateTime.Now.ToUniversalTime();

    private List<Product> products = [];


    // Getters and Setters
    [Key]
    public int Id { get => id; set => id = value; }

    [Required]
    [MinLength(3, ErrorMessage = "Title must be 3 characters")]
    [MaxLength(25, ErrorMessage = "Title cannot be over 25 characters")]
    public string Title { get => title; set => title = value; }

    public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

    public DateTime UpdatedAt { get => updatedAt; set => updatedAt = value; }

    public List<Product> Products { get => products; set => products = value; }
}
