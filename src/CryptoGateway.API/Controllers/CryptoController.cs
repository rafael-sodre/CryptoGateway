using CryptoGateway.Domain.Responses;
using CryptoGateway.Infra.Adapters.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CryptoGateway.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CryptoController : ControllerBase
{
    private readonly IBinanceExchangeAdapter _binanceExchangeAdapter;

    public CryptoController(IBinanceExchangeAdapter binanceExchangeAdapter)
    {
        _binanceExchangeAdapter = binanceExchangeAdapter;
    }

    [HttpGet]
    public async Task<ICollection<ExchangeResponse>> GetCoins(string? symbol)
    {
        var exchangeResponse = await _binanceExchangeAdapter.GetCryptoPriceAsync(symbol!);

        return exchangeResponse;

    }
    
}