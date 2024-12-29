using System.ComponentModel.DataAnnotations;

namespace EasyDeals.DTOs.CommentDTOs;

public class CreateCommentDTO
{
    private string body = string.Empty;


    // Getters and Setters
    [Required]
    [MaxLength(25, ErrorMessage = "Comment cannot be over 25 characters")]
    public string Body { get => body; set => body = value; }
}
