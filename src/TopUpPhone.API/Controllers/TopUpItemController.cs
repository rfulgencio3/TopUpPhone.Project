using Microsoft.AspNetCore.Mvc;
using TopUpPhone.API.Utils;
using TopUpPhone.Application.DTOs;
using TopUpPhone.Application.Services.Interfaces;
using TopUpPhone.Core.Domain.Enums;

namespace TopUpPhone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TopUpItemController : ControllerBase
{
    private readonly ITopUpItemService _topUpItemService;
    private readonly LinkFactory _linkFactory;

    public TopUpItemController(ITopUpItemService topUpItemService, LinkFactory linkFactory)
    {
        _topUpItemService = topUpItemService;
        _linkFactory = linkFactory;
    }

    [HttpGet("{id}", Name = "GetTopUpItemById")]
    public async Task<IActionResult> GetTopUpItemById([FromRoute] int id)
    {
        var result = await _topUpItemService.GetTopUpItemByIdAsync(id);
        if (!result.Success) return NotFound(result.ErrorMessage);

        _linkFactory.AddLinks(result.Data);

        return Ok(result.Data);
    }

    [HttpGet("all", Name = "GetAllTopUpItems")]
    public async Task<IActionResult> GetAllTopUpItems()
    {
        var result = await _topUpItemService.GetAllTopUpItemsAsync();
        if (!result.Success) return BadRequest(result.ErrorMessage);

        foreach (var topUpItem in result.Data)
        {
            _linkFactory.AddLinks(topUpItem);
        }

        return Ok(result.Data);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTopUpItem([FromBody] RequestTopUpItemDTO requestTopUpItemDTO)
    {
        var result = await _topUpItemService.CreateTopUpItemAsync(requestTopUpItemDTO);
        if (!result.Success) return BadRequest(result.ErrorMessage);

        return NoContent();
    }

    [HttpPatch("update-status")]
    public async Task<IActionResult> UpdateTopUpItemStatus(
        [FromHeader] int id,
        [FromBody] Status status)
    {
        var result = await _topUpItemService.UpdateTopUpItemStatusAsync(id, status);
        if (!result.Success) return NotFound(result.ErrorMessage);

        return NoContent();
    }
}
