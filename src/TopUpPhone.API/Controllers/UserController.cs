using Microsoft.AspNetCore.Mvc;
using TopUpPhone.API.Utils;
using TopUpPhone.Application.DTOs;
using TopUpPhone.Application.Services.Interfaces;

namespace TopUpPhone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly LinkFactory _linkFactory;

    public UserController(IUserService userService, LinkFactory linkFactory)
    {
        _userService = userService;
        _linkFactory = linkFactory;
    }

    [HttpGet("{id}", Name = "GetUserById")]
    public async Task<IActionResult> GetUserById([FromRoute] int id)
    {
        var result = await _userService.GetUserByIdAsync(id);
        if (!result.Success) return NotFound(result.ErrorMessage);

        _linkFactory.AddLinks(result.Data);

        return Ok(result.Data);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser([FromBody] RequestUserDTO createUserDTO)
    {
        var result = await _userService.CreateUserAsync(createUserDTO);
        if (!result.Success) return BadRequest(result.ErrorMessage);

        _linkFactory.AddLinks(result.Data);

        var response = new
        {
            Message = $"USER_CREATED_WITH_SUCCESS: {result.Data.Id}",
            Data = result.Data
        };

        return CreatedAtAction(nameof(GetUserById), new { id = result.Data.Id }, response);
    }

    [HttpPatch("verify-user")]
    public async Task<IActionResult> UpdateIsVerified([FromHeader] int id, [FromBody] bool isVerified)
    {
        var result = await _userService.UpdateIsVerifiedAsync(id, isVerified);
        if (!result.Success) return NotFound(result.ErrorMessage);

        return NoContent();
    }

    [HttpPatch("increment-balance")]
    public async Task<IActionResult> IncrementBalance([FromHeader] int id, [FromBody] decimal amount)
    {
        var result = await _userService.IncrementBalanceAsync(id, amount);
        if (!result.Success) return BadRequest(result.ErrorMessage);

        return NoContent();
    }
}
