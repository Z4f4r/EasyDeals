using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyDeals.Helpers;

public class ProductQueryObject
{
    private string? title = string.Empty;

    private string? description = string.Empty;

    [Column(TypeName = "decimal(18, 2)")]
    private decimal? price = null;

    // private DateTime createdAt = DateTime.Now.ToUniversalTime();

    // private DateTime updatedAt = DateTime.Now.ToUniversalTime();

    private int? categoryId = null;

    private string? userId = null;

    private int? cityId = null;

    private int? stateId = null;

    private string? sortBy = null;

    private bool isDescending = false;

    public int pageNumber = 1;

    public int pageSize = 20;


    // Getters and Setters
    [MaxLength(25, ErrorMessage = "Title cannot be over 25 characters")]
    public string? Title { get => title; set => title = value; }

    [MaxLength(255, ErrorMessage = "Description cannot be over 255 characters")]
    public string? Description { get => description; set => description = value; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Price { get => price; set => price = value; }

    // public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

    // public DateTime UpdatedAt { get => updatedAt; set => updatedAt = value; }
    // ToDo for filter

    public int? CategoryId { get => categoryId; set => categoryId = value; }

    public string? UserId { get => userId; set => userId = value; }

    public int? CityId { get => cityId; set => cityId = value; }

    public int? StateId { get => stateId; set => stateId = value; }

    public string? SortBy { get => sortBy; set => sortBy = value; }

    public bool IsDescending { get => isDescending; set => isDescending = value; }

    public int PageNumber { get => pageNumber; set => pageNumber = value; }

    public int PageSize { get => pageSize; set => pageSize = value; }
}
