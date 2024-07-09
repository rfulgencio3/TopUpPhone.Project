using Microsoft.AspNetCore.Mvc;
using TopUpPhone.API.Utils;
using TopUpPhone.Application.DTOs;
using TopUpPhone.Application.Services.Interfaces;

namespace TopUpPhone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BeneficiaryController : ControllerBase
{
    private readonly IBeneficiaryService _beneficiaryService;
    private readonly LinkFactory _linkFactory;

    public BeneficiaryController(IBeneficiaryService beneficiaryService, LinkFactory linkFactory)
    {
        _beneficiaryService = beneficiaryService;
        _linkFactory = linkFactory;
    }

    [HttpGet("{id}", Name = "GetBeneficiaryById")]
    public async Task<IActionResult> GetBeneficiaryById([FromRoute] int id)
    {
        var result = await _beneficiaryService.GetBeneficiaryByIdAsync(id);
        if (!result.Success) return NotFound(result.ErrorMessage);

        _linkFactory.AddLinks(result.Data);

        return Ok(result.Data);
    }

    [HttpGet("user/{id}", Name = "GetBeneficiaryByUserId")]
    public async Task<IActionResult> GetBeneficiaryByUserId([FromRoute] int id)
    {
        var result = await _beneficiaryService.GetAllBeneficiariesByUserAsync(id);
        if (!result.Success) return NotFound(result.ErrorMessage);

        var beneficiaries = result.Data.Select(b =>
        {
            _linkFactory.AddLinks(b);
            return b;
        }).ToList();

        return Ok(beneficiaries);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateBeneficiary([FromBody] RequestBeneficiaryDTO requestBeneficiaryDTO)
    {
        var result = await _beneficiaryService.CreateBeneficiaryAsync(requestBeneficiaryDTO);
        if (!result.Success) return BadRequest(result.ErrorMessage);

        _linkFactory.AddLinks(result.Data);

        var response = new
        {
            Message = $"USER_CREATED_WITH_SUCCESS: {result.Data.Id}",
            result.Data
        };

        return CreatedAtAction(nameof(GetBeneficiaryById), new { id = result.Data.Id }, response);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateBeneficiary(
        [FromHeader] int id,
        [FromBody] UpdateBeneficiaryDTO updateBeneficiaryDTO)
    {
        var result = await _beneficiaryService.UpdateBeneficiaryAsync(id, updateBeneficiaryDTO);
        if (!result.Success) return BadRequest(result.ErrorMessage);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBeneficiary(int id)
    {
        var result = await _beneficiaryService.DeleteBeneficiaryAsync(id);
        if (!result.Success) return NotFound(result.ErrorMessage);

        return NoContent();
    }
}
