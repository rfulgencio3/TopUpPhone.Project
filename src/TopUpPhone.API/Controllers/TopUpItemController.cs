using Microsoft.AspNetCore.Mvc;
using TopUpPhone.Application.Services.Interfaces;
using TopUpPhone.Core.Domain.DTOs.TopUpItem;

namespace TopUpPhone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TopUpItemController : ControllerBase
{
    private readonly ITopUpItemService _topUpItemService;

    public TopUpItemController(ITopUpItemService topUpItemService)
    {
        _topUpItemService = topUpItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetTopUpItemById([FromHeader] int id)
    {
        var topUpItem = await _topUpItemService.GetTopUpItemByIdAsync(id);
        if (topUpItem == null) return NotFound();

        return Ok(topUpItem);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTopUpItem([FromBody] RequestTopUpItemDTO requestTopUpItemDTO)
    {
        await _topUpItemService.CreateTopUpItemAsync(requestTopUpItemDTO);
        return NoContent();
    }

    [HttpPatch("update")]
    public async Task<IActionResult> UpdateTopUpItem(
        [FromHeader] int id,
        [FromBody] RequestTopUpItemDTO requestTopUpItemDTO)
    {
        await _topUpItemService.UpdateTopUpItemAsync(id, requestTopUpItemDTO);
        return NoContent();
    }
}
