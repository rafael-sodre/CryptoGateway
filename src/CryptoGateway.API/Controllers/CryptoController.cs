using CryptoGateway.Domain.Responses;
using CryptoGateway.Infra.Adapters.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CryptoGateway.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CryptoController : ControllerBase
{
    private readonly IEnumerable<IExchange> _exchanges;

    public CryptoController(IEnumerable<IExchange> exchanges)
    {
        _exchanges = exchanges;
    }

    [HttpGet]
    public async Task<ICollection<ExchangeResponse>> GetCoins(string? symbol)
    {

        var exchangesResponses = new List<ExchangeResponse>();
        foreach (var exchange in _exchanges)
        {
            var response = await exchange.GetCryptoPriceAsync(symbol);
            exchangesResponses.AddRange(response);

        }
        
        return exchangesResponses;

    }
    
}