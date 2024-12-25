namespace EasyDeals.Helpers;

public class CityQueryObject
{
    private string title = string.Empty;

    // private DateTime createdAt = DateTime.Now.ToUniversalTime();

    // private DateTime updatedAt = DateTime.Now.ToUniversalTime();

    private string? sortBy;

    private bool isDescending = false;

    public int pageNumber = 1;

    public int pageSize = 20;



    public string Title { get => title; set => title = value; }

    // public DateTime CreatedAt { get => createdAt; set => createdAt = value; }

    // public DateTime UpdatedAt { get => updatedAt; set => updatedAt = value; }
    // ToDo for filter

    public string? SortBy { get => sortBy; set => sortBy = value; }

    public bool IsDescending { get => isDescending; set => isDescending = value; }

    public int PageNumber { get => pageNumber; set => pageNumber = value; }

    public int PageSize { get => pageSize; set => pageSize = value; }
}
