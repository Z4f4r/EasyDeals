using EasyDeals.Data;
using EasyDeals.Data.Models;
using EasyDeals.DTOs.StateDTOs;
using EasyDeals.Helpers;
using EasyDeals.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EasyDeals.Repositories;

public class StateRepository : IStateRepository
{
    private readonly ApplicationDbContext db;

    // DI constructor
    public StateRepository(ApplicationDbContext db)
    {
        this.db = db;
    }



    // CREATE
    public async Task<State?> CreateAsync(State state)
    {
        await db.States.AddAsync(state);
        await db.SaveChangesAsync();

        return state;
    }



    // READ
    public async Task<List<State>?> GetAllAsync(StateQueryObject query)
    {
        var states = db.States.Include(x => x.Products).AsQueryable();


        // Checking IsActive (deleted or not)
        states = states.Where(s => s.IsActive == true);


        // Filter
        if (!string.IsNullOrWhiteSpace(query.Title))
            states = states.Where(s => s.Title.Contains(query.Title));
        // ToDO (add CreatedAt and UpdatedAt filter)


        // Sorting
        if (!string.IsNullOrWhiteSpace(query.SortBy))
        {
            if (query.SortBy.Equals("Title", StringComparison.OrdinalIgnoreCase))
                states = query.IsDescending ? states.OrderByDescending(s => s.Title) : states.OrderBy(s => s.Title);
            else if (query.SortBy.Equals("CreatedAt", StringComparison.OrdinalIgnoreCase))
                states = query.IsDescending ? states.OrderByDescending(s => s.CreatedAt) : states.OrderBy(s => s.CreatedAt);
            else if (query.SortBy.Equals("Date", StringComparison.OrdinalIgnoreCase))
                states = query.IsDescending ? states.OrderByDescending(s => s.UpdatedAt) : states.OrderBy(s => s.UpdatedAt);
        }


        // Pagination
        var skipNumber = (query.PageNumber - 1) * query.PageSize;


        return await states.Skip(skipNumber).Take(query.PageSize).ToListAsync();
    }



    // READ
    public async Task<State?> GetByIdAsync(int id)
    {
        var state = await db.States.Include(x => x.Products).FirstOrDefaultAsync(c => c.Id == id);

        // Checking IsActive (deleted or not)
        return state?.IsActive == true ? state : null;
    }



    // UPDATE
    public async Task<State?> UpdateAsync(int id, UpdateStateDTO stateDTO)
    {
        var modelState = await db.States.Include(x => x.Products).FirstOrDefaultAsync(c => c.Id == id);

        if (modelState == null || modelState.IsActive == false)
            return null;

        // Updating the fields
        modelState.Title = stateDTO.Title;
        modelState.UpdatedAt = DateTime.Now.ToUniversalTime();

        await db.SaveChangesAsync();

        return modelState;
    }



    // DELETE
    public async Task<State?> DeleteAsync(int id)
    {
        var modelState = await db.States.Include(x => x.Products).FirstOrDefaultAsync(c => c.Id == id);

        // Checking IsActive (deleted or not)
        modelState = modelState?.IsActive == true ? modelState : null;

        if (modelState == null)
            return null;

        modelState!.IsActive = false;
        await db.SaveChangesAsync();

        return modelState;
    }
}
