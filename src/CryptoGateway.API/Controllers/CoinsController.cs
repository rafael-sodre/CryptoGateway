using CryptoGateway.Core.Services.Interfaces;
using CryptoGateway.Domain.Constants;
using CryptoGateway.Domain.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CryptoGateway.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CoinsController : ControllerBase
{
    private readonly IHttpClientService _httpClientService;

    public CoinsController(IHttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }
    
    [HttpGet]
    public async Task<string> GetCoins()
    {
        var urls = BrokersConstants.url;
        
        foreach (var url in urls)
        {
        var coins = url switch
        {
            string str when str.Contains("kucoin") => await _httpClientService.GetAsync<KucoinResponse>(url),
            string str when str.Contains("binance") => await _httpClientService.GetAsync<BinanceResponse>(url)
        };
        
        var result = coins;
        }

        return "";

    }
    
}