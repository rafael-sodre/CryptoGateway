using CryptoGateway.Domain.Responses;
using CryptoGateway.Infra.Adapters.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CryptoGateway.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CryptoController : ControllerBase
{
    private readonly IExchange _exchange;

    public CryptoController(IExchange exchange)
    {
        _exchange = exchange;
    }

    [HttpGet]
    public async Task<ICollection<ExchangeResponse>> GetCoins(string? symbol)
    {
        // TODO: Criar uma nova camada de serviço que faça a chamada de todos os Adapters
        var exchangeResponse = await _exchange.GetCryptoPriceAsync(symbol!);

        return exchangeResponse;

    }
    
}