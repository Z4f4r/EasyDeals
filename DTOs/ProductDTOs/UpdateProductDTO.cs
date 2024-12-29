﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyDeals.DTOs.ProductDTOs;

public class UpdateProductDTO
{
    private string title = string.Empty;

    private string description = string.Empty;

    private decimal price;

    private string? image_1;

    private string? image_2;

    private string? image_3;

    private int categoryId;

    private int cityId;

    private int stateId;


    // Getters and Setters
    [Required]
    [MinLength(3, ErrorMessage = "Title must be 3 characters")]
    [MaxLength(25, ErrorMessage = "Title cannot be over 25 characters")]
    public string Title { get => title; set => title = value; }

    [Required]
    [MaxLength(255, ErrorMessage = "Description cannot be over 255 characters")]
    public string Description { get => description; set => description = value; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get => price; set => price = value; }

    [MaxLength(255, ErrorMessage = "Image URL cannot be over 255 characters")]
    public string? Image_1 { get => image_1; set => image_1 = value; }

    [MaxLength(255, ErrorMessage = "Image URL cannot be over 255 characters")]
    public string? Image_2 { get => image_2; set => image_2 = value; }

    [MaxLength(255, ErrorMessage = "Image URL cannot be over 255 characters")]
    public string? Image_3 { get => image_3; set => image_3 = value; }

    public int CategoryId { get => categoryId; set => categoryId = value; }

    public int CityId { get => cityId; set => cityId = value; }

    public int StateId { get => stateId; set => stateId = value; }
}
