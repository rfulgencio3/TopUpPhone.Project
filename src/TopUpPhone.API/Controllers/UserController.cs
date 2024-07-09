using Microsoft.AspNetCore.Mvc;
using TopUpPhone.Application.Services.Interfaces;
using TopUpPhone.Core.Domain.DTOs.User;

namespace TopUpPhone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetUserById([FromHeader] int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        if (user == null) return NotFound();

        return Ok(user);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] RequestUserDTO createUserDTO)
    {
        await _userService.CreateUserAsync(createUserDTO);
        return NoContent();
    }

    [HttpPatch("verify")]
    public async Task<IActionResult> UpdateIsVerified([FromHeader] int id, [FromBody] bool isVerified)
    {
        var result = await _userService.UpdateIsVerifiedAsync(id, isVerified);
        if (!result) return NotFound();

        return NoContent();
    }
}
