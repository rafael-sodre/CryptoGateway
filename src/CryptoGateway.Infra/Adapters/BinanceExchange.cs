using CryptoGateway.Core.Services.Interfaces;
using CryptoGateway.Domain.Constants;
using CryptoGateway.Domain.Responses;
using CryptoGateway.Infra.Adapters.Interfaces;

namespace CryptoGateway.Infra.Adapters;

public class BinanceExchange : ExchangeBase, IExchange
{
    private readonly IHttpClientService _httpClientService;

    private const string ExchangeName = "Binance";

    public BinanceExchange(IHttpClientService httpClientService)
    {
        _httpClientService = httpClientService;
    }

    public async Task<List<ExchangeResponse>> GetCryptoPriceAsync(string? symbol)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(symbol))
            {
                symbol = DefineSymbol(symbol);
            }

            var uri = GenerateUri(ExchangeConstants.BinanceBaseUrl, ExchangeConstants.BinancePath, symbol);

            var binanceResponse = await _httpClientService.GetAsync<BinanceResponse>(uri);

            var exchangeResponses = new List<ExchangeResponse>();

            var criptoresponses = binanceResponse.Select(response =>
                new CryptoResponse(response?.askPrice, response.symbol)).ToList();

            var exchangeResponse = new ExchangeResponse(ExchangeName, criptoresponses);
            exchangeResponses.Add(exchangeResponse);
        
            return exchangeResponses;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }

    }
    
    public string? DefineSymbol(string? symbol)
    {
        return $"{symbol}USDT";
    }
}