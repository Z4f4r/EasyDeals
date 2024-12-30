using EasyDeals.DTOs.CategoryDTOs;
using EasyDeals.Helpers;
using EasyDeals.Interfaces;
using EasyDeals.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EasyDeals.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository categoryRepository;

    // DI constructor
    public CategoryController(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }



    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] CategoryQueryObject query)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var categories = await categoryRepository.GetAllAsync(query);

        var categoryDTO = categories?.Select(x => x.ToCategoryDTO());

        return Ok(categoryDTO);
    }



    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var category = await categoryRepository.GetByIdAsync(id);

        if (category == null)
            return NotFound("Category not found");

        return Ok(category.ToCategoryDTO());
    }



    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDTO categoryDTO)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var categoryModel = categoryDTO.ToCategoryFromCreate();

        if (categoryModel.ParentCategoryId != null &&
            !await categoryRepository.CategoryExists(categoryModel.ParentCategoryId ?? -1))
            return NotFound($"Parent Category with ID {categoryModel.ParentCategoryId} not found.");

        await categoryRepository.CreateAsync(categoryModel);

        return CreatedAtAction(nameof(GetById), new { id = categoryModel.Id }, categoryModel.ToCategoryDTO());
    }



    [HttpPut]
    [Route("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryDTO categoryDTO)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (categoryDTO.ParentCategoryId != null && 
            !await categoryRepository.CategoryExists(categoryDTO.ParentCategoryId ?? -1))
            return NotFound($"Parent Category with ID {categoryDTO.ParentCategoryId} not found.");

        var categoryModel = await categoryRepository.UpdateAsync(id, categoryDTO);

        if (categoryModel == null)
            return NotFound("Category not found");

        return Ok(categoryModel.ToCategoryDTO());
    }



    [HttpDelete]
    [Route("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var categoryModel = await categoryRepository.DeleteAsync(id);

        if (categoryModel == null)
            return NotFound("Category not found");

        return NoContent();
    }
}
