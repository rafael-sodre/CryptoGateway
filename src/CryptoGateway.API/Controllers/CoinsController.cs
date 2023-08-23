using System.Collections;
using System.Text.Json;
using CryptoGateway.Core.Wrapper;
using CryptoGateway.Domain.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CryptoGateway.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CoinController : ControllerBase
{
    private readonly IBinanceEndpoint _binanceEndpoint;

    public CoinController(IBinanceEndpoint binanceEndpoint)
    {
        _binanceEndpoint = binanceEndpoint;
    }
    
    [HttpGet]
    public async Task<ICollection<Coin>> GetCoins()
    {
        var str = await _binanceEndpoint.GetCoin();
        
        var coins = JsonSerializer.Deserialize<List<Coin>>(str);
        
        return coins;
    }
    
}