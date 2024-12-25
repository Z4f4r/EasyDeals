﻿namespace EasyDeals.Data.Models;

public class Comment
{
    private int id;

    private string body = string.Empty;

    private bool isActive = true;

    private DateTime createdAt = DateTime.Now;

    private DateTime updatedAt = DateTime.Now;

    private int productId;

    private int userId;

    private Product? product;

    private AppUser? appUser;



    public int Id { get => id; set => id = value; }

    public string Body { get => body; set => body = value; }

    public bool IsActive { get => isActive; set => isActive = value; }

    public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

    public DateTime UpdatedAt { get => updatedAt; set => updatedAt = value; }

    public int ProductId { get => productId; set => productId = value; }

    public int UserId { get => userId; set => userId = value; }

    public Product? Product { get => product; set => product = value; }

    public AppUser? AppUser { get => appUser; set => appUser = value; }
}
