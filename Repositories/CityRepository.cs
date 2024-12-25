using EasyDeals.Data;
using EasyDeals.Data.Models;
using EasyDeals.DTOs.CityDTOs;
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
    public async Task<List<City>?> GetAllAsync()
    {
        return await db.Cities.ToListAsync();
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
