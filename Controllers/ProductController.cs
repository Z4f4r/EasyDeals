using EasyDeals.Data.Models;
using EasyDeals.DTOs.ProductDTOs;
using EasyDeals.Extensions;
using EasyDeals.Helpers;
using EasyDeals.Interfaces;
using EasyDeals.Mappers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyDeals.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IProductRepository productRepository;
    private readonly UserManager<AppUser> userManager;

    // DI conctructor
    public ProductController(IProductRepository productRepository,
        UserManager<AppUser> userManager)
    {
        this.productRepository = productRepository;
        this.userManager = userManager;
    }



    [HttpGet]
    public async Task<IActionResult> GetAll([FromQuery] ProductQueryObject query)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var products = await productRepository.GetAllAsync(query);

        var productsDTO = products?.Select(s => s.ToProductDTO());

        return Ok(productsDTO);
    }



    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var product = await productRepository.GetByIdAsync(id);

        if (product == null)
            return NotFound("Product not found");

        return Ok(product);
    }



    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProductDTO productDTO)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Find the user who create this product
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        var product = productDTO.ToProductFromCreate();
        product.UserId = appUser!.Id;
        await productRepository.CreateAsync(product);

        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product.ToProductDTO());
    }



    [HttpPut]
    [Route("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateProductDTO productDTO)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var product = await productRepository.UpdateAsync(id, productDTO);

        if (product == null)
            return NotFound("Product not found");

        return Ok(product.ToProductDTO());
    }



    [HttpDelete]
    [Route("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var productModel = await productRepository.DeleteAsync(id);

        if (productModel == null)
            return NotFound("Product not found");

        return NoContent();
    }
}
