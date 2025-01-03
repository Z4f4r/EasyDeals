﻿using EasyDeals.DTOs.CityDTOs;
using EasyDeals.Helpers;
using EasyDeals.Interfaces;
using EasyDeals.Mappers;
using Microsoft.AspNetCore.Authorization;
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

        var citiesDTO = cities?.Select(c => c.ToCityDTO());

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
    [Authorize]
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
    [Authorize]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCityDTO cityDTO)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var cityModel = await cityRepository.UpdateAsync(id, cityDTO);

        if (cityModel == null)
            return NotFound("City not found");

        return Ok(cityModel.ToCityDTO());
    }



    [HttpDelete]
    [Route("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var cityModel = await cityRepository.DeleteAsync(id);

        if (cityModel == null)
            return NotFound("City not found");

        return NoContent();
    }
}
