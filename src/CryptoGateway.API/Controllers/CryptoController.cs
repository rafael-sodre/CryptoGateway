using CryptoGateway.Core.Services.Interfaces;
using CryptoGateway.Domain.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CryptoGateway.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CryptoController : ControllerBase
{
    private readonly IExchangeService _exchangeService;

    public CryptoController(IExchangeService exchangeService)
    {
        _exchangeService = exchangeService;
    }

    [HttpGet]
    public async Task<ICollection<ExchangeResponse>> GetCoins(string? symbol)
    {
        return await _exchangeService.GetCryptoPriceAsync(symbol);;
    }
}