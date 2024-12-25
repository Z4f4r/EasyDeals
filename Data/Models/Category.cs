﻿using System.ComponentModel.DataAnnotations.Schema;

namespace EasyDeals.Data.Models;

[Table("Categories")]
public class Category
{
    private int id;

    private string title = string.Empty;

    private bool isActive = true;

    private DateTime createdAt = DateTime.Now;

    private DateTime updatedAt = DateTime.Now;

    private int parentCategoryId;

    private Category? parentCategory;

    private List<Product> products = [];



    public int Id { get => id; set => id = value; }

    public string Title { get => title; set => title = value; }

    public bool IsActive { get => isActive; set => isActive = value; }

    public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

    public DateTime UpdatedAt { get => updatedAt; set => updatedAt = value; }

    public int ParentCategoryId { get => parentCategoryId; set => parentCategoryId = value; }

    public Category? ParentCategory { get => parentCategory; set => parentCategory = value; }

    public List<Product> Products { get => products; set => products = value; }
}