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
            IsActive = city.IsActive,
            Products = city.Products
            // ToDO Each Product to ProductDTO
        };
    }

    public static City ToCityFromCreate(this CreateCityDTO createCityDTO)
    {
        return new City
        {
            Title = createCityDTO.Title,
            IsActive = createCityDTO.IsActive
        };
    }
}
