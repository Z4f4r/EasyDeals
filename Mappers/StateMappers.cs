using EasyDeals.Data.Models;
using EasyDeals.DTOs.StateDTOs;

namespace EasyDeals.Mappers;

public static class StateMappers
{
    public static StateDTO ToStateDTO(this State state)
    {
        return new StateDTO
        {
            Id = state.Id,
            Title = state.Title,
            CreatedAt = state.CreatedAt,
            UpdatedAt = state.UpdatedAt,
            Products = state.Products.Select(s => s.ToProductDTO()).ToList()
        };
    }

    public static State ToStateFromCreate(this CreateStateDTO createStateDTO)
    {
        return new State
        {
            Title = createStateDTO.Title,
        };
    }
}
