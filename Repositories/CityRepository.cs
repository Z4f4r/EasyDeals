using EasyDeals.Data;
using EasyDeals.Data.Models;
using EasyDeals.DTOs.CityDTOs;
using EasyDeals.Helpers;
using EasyDeals.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyDeals.Repositories;

public class CityRepository : ICityRepository
{
    private readonly ApplicationDbContext db;

    // DI constructor
    public CityRepository(ApplicationDbContext db)
    {
        this.db = db;
    }



    // CREATE
    public async Task<City?> CreateAsync(City city)
    {
        await db.Cities.AddAsync(city);
        await db.SaveChangesAsync();

        return city;
    }



    // READ
    public async Task<List<City>?> GetAllAsync(CityQueryObject query)
    {
        var cities = db.Cities.AsQueryable();


        // Filter
        if (!string.IsNullOrWhiteSpace(query.Title))
            cities = cities.Where(s => s.Title.Contains(query.Title));
        // ToDO (add CreatedAt and UpdatedAt filter)


        // Sorting
        if (!string.IsNullOrWhiteSpace(query.SortBy))
        {
            if (query.SortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                cities = query.IsDescending ? cities.OrderByDescending(s => s.Title) : cities.OrderBy(s => s.Title);
            else if (query.SortBy.Equals("CreatedAt", StringComparison.OrdinalIgnoreCase))
                cities = query.IsDescending ? cities.OrderByDescending(s => s.CreatedAt) : cities.OrderBy(s => s.CreatedAt);
            else if (query.SortBy.Equals("Date", StringComparison.OrdinalIgnoreCase))
                cities = query.IsDescending ? cities.OrderByDescending(s => s.UpdatedAt) : cities.OrderBy(s => s.UpdatedAt);
        }


        // Pagination
        var skipNumber = (query.PageNumber - 1) * query.PageSize;


        return await cities.Skip(skipNumber).Take(query.PageSize).ToListAsync();
    }



    // READ
    public async Task<City?> GetByIdAsync(int id)
    {
        return await db.Cities.FirstOrDefaultAsync(c => c.Id == id);
    }



    // UPDATE
    public async Task<City?> UpdateAsync(int id, UpdateCityDTO comment)
    {
        var modelCity = await db.Cities.FindAsync(id);

        if (modelCity == null)
            return null;

        // Updating the fields
        modelCity.Title = comment.Title;
        modelCity.IsActive = comment.IsActive; 

        await db.SaveChangesAsync();

        return modelCity;
    }



    // DELETE
    public async Task<City?> DeleteAsync(int id)
    {
        var citymodel = await db.Cities.FirstOrDefaultAsync(c => c.Id == id);

        if (citymodel == null) 
            return null;

        db.Cities.Remove(citymodel);
        await db.SaveChangesAsync();

        return citymodel;
    }
}
