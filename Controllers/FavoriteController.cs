using EasyDeals.Data.Models;
using EasyDeals.Extensions;
using EasyDeals.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EasyDeals.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FavoriteController : ControllerBase
{
    private readonly UserManager<AppUser> userManager;
    private readonly IProductRepository productRepository;
    private readonly IFavoriteRepository favoriteRepository;

    // DI constructor
    public FavoriteController(UserManager<AppUser> userManager,
        IProductRepository productRepository, IFavoriteRepository favoriteRepository)
    {
        this.favoriteRepository = favoriteRepository;
        this.userManager = userManager;
        this.productRepository = productRepository;
    }



    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetUserFavorite()
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);
        var userFavorite = await favoriteRepository.GetUserFavorite(appUser!);

        return Ok(userFavorite);
    }



    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddFavorite(string title)
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);
        var product = await productRepository.GetByTitleAsync(title);

        if (product == null) 
            return BadRequest("Product not found");

        var userFavorite = await favoriteRepository.GetUserFavorite(appUser!);

        if (userFavorite.Any(e => e.Title.ToLower() == title.ToLower())) 
            return BadRequest("Cannot add same product to portfolio");

        var favoriteModel = new Favorite
        {
            ProductId = product.Id,
            AppUserId = appUser!.Id
        };

        await favoriteRepository.CreateAsync(favoriteModel);

        return favoriteModel == null ? StatusCode(500, "Could not create") : Created();
    }



    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> DeleteFavorite(string title)
    {
        var username = User.GetUsername();
        var appUser = await userManager.FindByNameAsync(username);

        var userFavorite = await favoriteRepository.GetUserFavorite(appUser!);

        var filteredProduct = userFavorite.Where(s => s.Title.ToLower() == title.ToLower());

        if (filteredProduct.Count() == 1)
            await favoriteRepository.DeleteFavorite(appUser!, title);
        else
            return BadRequest("Stock not in your portfolio");

        return Ok();
    }
}
