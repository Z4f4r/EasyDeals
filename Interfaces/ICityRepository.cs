using EasyDeals.Data.Models;
using EasyDeals.DTOs.CityDTOs;

namespace EasyDeals.Interfaces;

public interface ICityRepository
{
    Task<List<City>?> GetAllAsync();

    Task<City?> GetByIdAsync(int id);

    Task<City?> CreateAsync(City comment);

    Task<City?> UpdateAsync(int id, UpdateCityDTO city);

    Task<City?> DeleteAsync(int id);
}
