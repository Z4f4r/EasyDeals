using EasyDeals.Data;
using EasyDeals.Data.Models;
using EasyDeals.DTOs.CityDTOs;
using EasyDeals.Helpers;
using EasyDeals.Interfaces;
using EasyDeals.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyDeals.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CityController : ControllerBase
{
    private readonly ICityRepository cityRepository;

    // DI constructor
    public CityController(ICityRepository cityRepository) 
    {
        this.cityRepository = cityRepository;
    }



    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] CityQueryObject query)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var cities = await cityRepository.GetAllAsync(query);

        var citiesDTO = cities?.Select(c => c.ToCityDTO()).ToList();

        return Ok(citiesDTO);
    }



    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var city = await cityRepository.GetByIdAsync(id);

        if (city == null)
            return NotFound();

        return Ok(city.ToCityDTO());
    }



    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCityDTO cityDTO)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var cityModel = cityDTO.ToCityFromCreate();

        await cityRepository.CreateAsync(cityModel);

        return CreatedAtAction(nameof(GetById), new { id = cityModel.Id }, cityModel.ToCityDTO());
    }



    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCityDTO cityDTO)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var stockModel = await cityRepository.UpdateAsync(id, cityDTO);

        if (stockModel == null)
            return NotFound();

        return Ok(stockModel.ToCityDTO());
    }



    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var stockModel = await cityRepository.DeleteAsync(id);

        if (stockModel == null)
            return NotFound();

        return NoContent();
    }
}
