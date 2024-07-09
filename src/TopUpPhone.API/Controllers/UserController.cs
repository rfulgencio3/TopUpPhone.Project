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
        var result = await _userService.GetUserByIdAsync(id);
        if (!result.Success) return NotFound(result.ErrorMessage);

        return Ok(result.Data);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] RequestUserDTO createUserDTO)
    {
        var result = await _userService.CreateUserAsync(createUserDTO);
        if (!result.Success) return BadRequest(result.ErrorMessage);

        return NoContent();
    }

    [HttpPatch("verify")]
    public async Task<IActionResult> UpdateIsVerified([FromHeader] int id, [FromBody] bool isVerified)
    {
        var result = await _userService.UpdateIsVerifiedAsync(id, isVerified);
        if (!result.Success) return NotFound(result.ErrorMessage);

        return NoContent();
    }
}
