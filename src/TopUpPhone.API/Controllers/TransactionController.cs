using Microsoft.AspNetCore.Mvc;
using TopUpPhone.Application.DTOs;
using TopUpPhone.Application.Services.Interfaces;

namespace TopUpPhone.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransactionController : ControllerBase
{
    private readonly ITransactionService _transactionService;

    public TransactionController(ITransactionService transactionService)
    {
        _transactionService = transactionService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateTransaction([FromBody] RequestTransactionDTO requestTransactionDTO)
    {
        var result = await _transactionService.CreateTransactionAsync(requestTransactionDTO);
        if (!result.Success) return BadRequest(result.ErrorMessage);

        return Ok(result.Data);
    }
}
