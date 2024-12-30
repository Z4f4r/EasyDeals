using EasyDeals.Data.Models;
using EasyDeals.DTOs.StateDTOs;
using EasyDeals.Helpers;

namespace EasyDeals.Interfaces;

public interface IStateRepository
{
    Task<List<State>?> GetAllAsync(StateQueryObject query);

    Task<State?> GetByIdAsync(int id);

    Task<State?> CreateAsync(State state);

    Task<State?> UpdateAsync(int id, UpdateStateDTO state);

    Task<State?> DeleteAsync(int id);

    Task<bool> StateExists(int id);
}
