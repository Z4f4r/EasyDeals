using EasyDeals.Data.Models;
using System.ComponentModel.DataAnnotations;

namespace EasyDeals.DTOs.CommentDTOs;

public class CommentDTO
{
    private int id;

    private string body = string.Empty;

    private DateTime createdAt = DateTime.Now.ToUniversalTime();

    private DateTime updatedAt = DateTime.Now.ToUniversalTime();

    private int productId;

    private string userId = string.Empty;


    // Getters and Setters
    [Key]
    public int Id { get => id; set => id = value; }

    [Required]
    [MaxLength(25, ErrorMessage = "Comment cannot be over 25 characters")]
    public string Body { get => body; set => body = value; }

    public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

    public DateTime UpdatedAt { get => updatedAt; set => updatedAt = value; }

    [Required]
    public int ProductId { get => productId; set => productId = value; }

    [Required]
    public string UserId { get => userId; set => userId = value; }
}
