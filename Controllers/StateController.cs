using EasyDeals.DTOs.StateDTOs;
using EasyDeals.Helpers;
using EasyDeals.Interfaces;
using EasyDeals.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace EasyDeals.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StateController : ControllerBase
{
    private readonly IStateRepository stateRepository;

    // DI constructor
    public StateController(IStateRepository stateRepository)
    {
        this.stateRepository = stateRepository;
    }



    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] StateQueryObject query)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var states = await stateRepository.GetAllAsync(query);

        var statesDTO = states?.Select(c => c.ToStateDTO());

        return Ok(statesDTO);
    }



    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var state = await stateRepository.GetByIdAsync(id);

        if (state == null)
            return NotFound();

        return Ok(state.ToStateDTO());
    }



    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStateDTO stateDTO)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var stateModel = stateDTO.ToStateFromCreate();

        await stateRepository.CreateAsync(stateModel);

        return CreatedAtAction(nameof(GetById), new { id = stateModel.Id }, stateModel.ToStateDTO());
    }



    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateStateDTO stateDTO)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var stateModel = await stateRepository.UpdateAsync(id, stateDTO);

        if (stateModel == null)
            return NotFound("State not found");

        return Ok(stateModel.ToStateDTO());
    }



    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var stateModel = await stateRepository.DeleteAsync(id);

        if (stateModel == null)
            return NotFound("State not found");

        return NoContent();
    }
}
