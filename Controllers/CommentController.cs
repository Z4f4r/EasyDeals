using EasyDeals.Data.Models;
using EasyDeals.DTOs.CommentDTOs;
using EasyDeals.Extensions;
using EasyDeals.Interfaces;
using EasyDeals.Mappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyDeals.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentController : ControllerBase
{
    private readonly ICommentRepository commentRepository;
    private readonly IProductRepository productRepository;
    private readonly UserManager<AppUser> userManager;

    // DI constructor
    public CommentController(ICommentRepository commentRepository,
        IProductRepository productRepository, UserManager<AppUser> userManager)
    {
        this.userManager = userManager;
        this.commentRepository = commentRepository;
        this.productRepository = productRepository;
    }



    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var comments = await commentRepository.GetAllAsync();

        var commentsDTO = comments.Select(s => s.ToCommentDTO());

        return Ok(commentsDTO);
    }



    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var comment = await commentRepository.GetByIdAsync(id);

        if (comment == null)
            return NotFound();

        return Ok(comment.ToCommentDTO());
    }



    [HttpPost]
    [Route("{productId:int}")]
    [Authorize]
    public async Task<IActionResult> Create([FromRoute] int productId, [FromBody] CreateCommentDTO commentDTO)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        // Checking if the product exists
        if (await productRepository.GetByIdAsync(productId) == null)
            return BadRequest("Product does not exist");

        // Find the user who wrote this comment
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        // Create a comment
        var comment = commentDTO.ToCommentFromCreate(productId);
        comment.UserId = appUser!.Id;
        await commentRepository.CreateAsync(comment);

        return CreatedAtAction(nameof(GetById), new { id = comment.Id }, comment.ToCommentDTO());
    }



    [HttpPut]
    [Route("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCommentDTO updateCommentDTO)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var comment = await commentRepository.UpdateAsync(id, updateCommentDTO);

        if (comment == null)
            return NotFound("Comment not found");

        return Ok(comment.ToCommentDTO());
    }



    [HttpDelete]
    [Route("{id:int}")]
    [Authorize]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
        // Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var commentModel = await commentRepository.DeleteAsync(id);

        if (commentModel == null)
            return NotFound("Comment does not exist");

        return Ok(commentModel);
    }
}
