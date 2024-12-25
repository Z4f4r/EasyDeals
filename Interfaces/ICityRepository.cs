using EasyDeals.Data.Models;
using EasyDeals.DTOs.CityDTOs;
using EasyDeals.Helpers;

namespace EasyDeals.Interfaces;

public interface ICityRepository
{
    Task<List<City>?> GetAllAsync(CityQueryObject query);

    Task<City?> GetByIdAsync(int id);

    Task<City?> CreateAsync(City city);

    Task<City?> UpdateAsync(int id, UpdateCityDTO city);

    Task<City?> DeleteAsync(int id);
}
