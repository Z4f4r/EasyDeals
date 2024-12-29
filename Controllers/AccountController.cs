using EasyDeals.Data.Models;
using EasyDeals.Interfaces;
using FinShark.DTOs.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EasyDeals.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly SignInManager<AppUser> signInManager;
    private readonly UserManager<AppUser> userManager;
    private readonly ITokenService tokenService;
    
    // DI constructor
    public AccountController(UserManager<AppUser> userManager,
        ITokenService tokenService, SignInManager<AppUser> signInManager)
    {
        this.signInManager = signInManager;
        this.userManager = userManager;
        this.tokenService = tokenService;
    }



    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
    {
        try
        {
            // Validation
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var appUser = new AppUser
            {
                UserName = registerDTO.UserName,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                Age = registerDTO.Age,
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.PhoneNumber,
                Avatar = registerDTO.Avatar
            };

            var createdUser = await userManager.CreateAsync(appUser, registerDTO.Password!);

            if (createdUser.Succeeded)
            {
                var roleResult = await userManager.AddToRoleAsync(appUser, "User");

                if (roleResult.Succeeded)
                    return Ok(
                        new NewUserDTO
                        {
                            UserName = appUser.UserName,
                            FirstName = appUser.FirstName,
                            LastName = appUser.LastName,
                            Age = appUser.Age,
                            Email = appUser.Email,
                            PhoneNumber = appUser.PhoneNumber,
                            Avatar = appUser.Avatar,
                            CreatedAt = appUser.CreatedAt,
                            Token = tokenService.CreateToken(appUser)
                        }
                    );
                else
                    return StatusCode(500, roleResult.Errors);
            }
            else
            {
                return StatusCode(500, createdUser.Errors);
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex);
        }
    }



    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginDTO loginDTO)
    {
        // DTO Validation
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var user = await userManager.Users.FirstOrDefaultAsync(x => x.UserName!.ToLower() == loginDTO.UserName!.ToLower());

        if (user == null)
            return Unauthorized("Invalid username!");

        // Lock out on failure: false
        var result = await signInManager.CheckPasswordSignInAsync(user, loginDTO.Password!, false);

        if (!result.Succeeded)
            return Unauthorized("Username not found and/or password incorrect");

        return Ok(
            new NewUserDTO
            {
                UserName = user.UserName!,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Age = user.Age,
                Email = user.Email!,
                PhoneNumber = user.PhoneNumber,
                Avatar = user.Avatar,
                CreatedAt = user.CreatedAt,
                Token = tokenService.CreateToken(user)
            }
        );
    }
}