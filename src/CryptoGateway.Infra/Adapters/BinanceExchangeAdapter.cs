using CryptoGateway.Core.Services.Interfaces;
using CryptoGateway.Domain.Constants;
using CryptoGateway.Domain.Responses;
using CryptoGateway.Infra.Adapters.Interfaces;

namespace CryptoGateway.Infra.Adapters;

public class BinanceExchangeAdapter : IBinanceExchangeAdapter
{
    private readonly IHttpClientService _httpClientService;

    private const string ExchangeName = "Binance";

    public BinanceExchangeAdapter(IHttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    public async Task<List<ExchangeResponse>> GetCryptoPriceAsync(string? filter)
    {
        var baseUri = ExchangeConstants.BinanceBaseUrl;
        var path = ExchangeConstants.BinancePath;
        
        if(!string.IsNullOrWhiteSpace(filter))
        {
            path += $"?symbol={filter}";
        }

        var uri = new Uri(new Uri(baseUri), path);
        
        var binanceResponse = await _httpClientService.GetAsync<BinanceResponse>(uri);

        var exchangeResponses = new List<ExchangeResponse>();
        
        var criptoresponses = binanceResponse.Select(response => new CryptoResponse((response.askPrice ?? 0M).ToString("M2"), response.symbol)).ToList();

        var exchangeResponse = new ExchangeResponse(ExchangeName, criptoresponses);
        exchangeResponses.Add(exchangeResponse);
        
        return exchangeResponses;

    }
}