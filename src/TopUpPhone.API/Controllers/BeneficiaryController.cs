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

        foreach (var beneficiary in result.Data)
        {
            _linkFactory.AddLinks(beneficiary);
        }

        return Ok(result.Data);
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateBeneficiary([FromBody] RequestBeneficiaryDTO requestBeneficiaryDTO)
    {
        var result = await _beneficiaryService.CreateBeneficiaryAsync(requestBeneficiaryDTO);
        if (!result.Success) return BadRequest(result.ErrorMessage);

        return NoContent();
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateBeneficiary(
        [FromHeader] int id,
        [FromBody] RequestBeneficiaryDTO requestBeneficiaryDTO)
    {
        var result = await _beneficiaryService.UpdateBeneficiaryAsync(id, requestBeneficiaryDTO);
        if (!result.Success) return BadRequest(result.ErrorMessage);

        return NoContent();
    }
}
