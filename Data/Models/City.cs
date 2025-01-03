﻿using System.ComponentModel.DataAnnotations.Schema;

namespace EasyDeals.Data.Models;

[Table("Cities")]
public class City
{
    private int id;

    private string title = string.Empty;

    private bool isActive = true;

    private DateTime createdAt = DateTime.Now.ToUniversalTime();

    private DateTime updatedAt = DateTime.Now.ToUniversalTime();

    private List<Product> products = [];


    // Getters and Setters
    public int Id { get => id; set => id = value; }

    public string Title { get => title; set => title = value; }

    public bool IsActive { get => isActive; set => isActive = value; }

    public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

    public DateTime UpdatedAt { get => updatedAt; set => updatedAt = value; }

    public List<Product> Products { get => products; set => products = value; }
}
