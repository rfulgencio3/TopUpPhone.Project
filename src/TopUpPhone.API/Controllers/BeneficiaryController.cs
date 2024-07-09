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
        var beneficiary = await _beneficiaryService.GetBeneficiaryByIdAsync(id);
        if (beneficiary == null) return NotFound();

        return Ok(beneficiary);
    }

    [HttpGet("user")]
    public async Task<IActionResult> GetBeneficiaryByUserId([FromHeader] int id)
    {
        var beneficiary = await _beneficiaryService.GetAllBeneficiariesByUserAsync(id);
        if (beneficiary == null) return NotFound();

        return Ok(beneficiary);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTopUpItem([FromBody] RequestBeneficiaryDTO requestBeneficiaryDTO)
    {
        await _beneficiaryService.CreateBeneficiaryAsync(requestBeneficiaryDTO);
        return NoContent();
    }

    [HttpPatch("update")]
    public async Task<IActionResult> UpdateTopUpItem(
        [FromHeader] int id,
        [FromBody] RequestBeneficiaryDTO requestBeneficiaryDTO)
    {
        await _beneficiaryService.UpdateBeneficiaryAsync(id, requestBeneficiaryDTO);
        return NoContent();
    }
}
