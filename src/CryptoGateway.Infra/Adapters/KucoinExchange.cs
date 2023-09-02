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

            var exchangResponses = new List<ExchangeResponse>();
        
            foreach (var response in kucoinResponse)
            {
                exchangResponses
                    .AddRange(response?.data
                        .Select(kucoinData => new List<CryptoResponse> { new(kucoinData.symbol, kucoinData.last) })
                        .Select(cryptoResponse => new ExchangeResponse(ExchangeName, cryptoResponse)) ?? Array.Empty<ExchangeResponse>());
            }

            return exchangResponses;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            throw;
        }
    }

    public string DefineSymbol(string? symbol)
    {
        return $"{symbol}-USDT";
    }
}