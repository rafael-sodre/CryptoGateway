using CryptoGateway.Core.Services;
using CryptoGateway.Core.Services.Interfaces;
using CryptoGateway.Domain.Constants;
using CryptoGateway.Domain.Responses;
using CryptoGateway.Infra.Adapters.Interfaces;

namespace CryptoGateway.Infra.Adapters;

public class KucoinExchange : ExchangeBase, IExchange
{

    private readonly IHttpClientService _httpClientService;
    private const string ExchangeName = "Kucoin";
    
    public KucoinExchange(IHttpClientService httpClientService)
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

            var uri = GenerateUri(ExchangeConstants.KucoinBaseUrl, ExchangeConstants.KucoinPath, symbol);

            var kucoinResponse = await _httpClientService.GetAsync<KucoinResponse>(uri);
            
            return kucoinResponse?
                .Select(response => new ExchangeResponse(ExchangeName, new List<CryptoResponse>()
                {
                    new(response.data.last, response.data.symbol)
                })).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public string DefineSymbol(string? symbol)
    {
        return $"{symbol!.ToUpper()}-USDT";
    }
}