using EasyDeals.Data.Models;
using EasyDeals.DTOs.CityDTOs;

namespace EasyDeals.Mappers;

public static class CityMappers
{
    public static CityDTO ToCityDTO(this City city)
    {
        return new CityDTO
        {
            Id = city.Id,
            Title = city.Title,
            CreatedAt = city.CreatedAt,
            UpdatedAt = city.UpdatedAt,
            Products = city.Products.Select(s => s.ToProductDTO()).ToList()
        };
    }

    public static City ToCityFromCreate(this CreateCityDTO createCityDTO)
    {
        return new City
        {
            Title = createCityDTO.Title,
        };
    }
}
