using Microsoft.AspNetCore.Mvc;
using TopUpPhone.Application.Services.Interfaces;
using TopUpPhone.Core.Domain.DTOs.Beneficiary;

namespace TopUpPhone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BeneficiaryController : ControllerBase
{
    private readonly IBeneficiaryService _beneficiaryService;

    public BeneficiaryController(IBeneficiaryService beneficiaryService)
    {
        _beneficiaryService = beneficiaryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetBeneficiaryById([FromHeader] int id)
    {
        var result = await _beneficiaryService.GetBeneficiaryByIdAsync(id);
        if (!result.Success) return NotFound(result.ErrorMessage);

        return Ok(result.Data);
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetBeneficiaryByUserId([FromHeader] int id)
    {
        var result = await _beneficiaryService.GetAllBeneficiariesByUserAsync(id);
        if (!result.Success) return NotFound(result.ErrorMessage);

        return Ok(result.Data);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateBeneficiary([FromBody] RequestBeneficiaryDTO requestBeneficiaryDTO)
    {
        var result = await _beneficiaryService.CreateBeneficiaryAsync(requestBeneficiaryDTO);
        if (!result.Success) return BadRequest(result.ErrorMessage);

        return NoContent();
    }

    [HttpPatch("update")]
    public async Task<IActionResult> UpdateBeneficiary(
        [FromHeader] int id,
        [FromBody] RequestBeneficiaryDTO requestBeneficiaryDTO)
    {
        var result = await _beneficiaryService.UpdateBeneficiaryAsync(id, requestBeneficiaryDTO);
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
