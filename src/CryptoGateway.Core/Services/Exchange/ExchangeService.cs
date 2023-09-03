using CryptoGateway.Core.Factories.Interfaces;
using CryptoGateway.Core.Services.Interfaces;
using CryptoGateway.Domain.Responses;
using CryptoGateway.Infra.Adapters.Interfaces;

namespace CryptoGateway.Core.Services.Exchange;

public class ExchangeService : IExchangeService
{
    private readonly IHttpClientService _clientService;
    private readonly IExchangeFactory _exchangeFactory;

    public ExchangeService(IHttpClientService clientService, IExchangeFactory exchangeFactory)
    {
        _clientService = clientService;
        _exchangeFactory = exchangeFactory;
    }

    public Task<List<ExchangeResponse>> GetCryptoPriceAsync(string? symbol)
    {
        var exchanges = GetExchangeTypes();
        return exchanges.Any()
            ? GetValueFromExchanges(exchanges, symbol ?? string.Empty)
            : Task.FromResult(new List<ExchangeResponse>());
    }

    private async Task<List<ExchangeResponse>> GetValueFromExchanges(IEnumerable<Type> exchangesType, string symbol)
    {
        var exchangesResponses = new List<ExchangeResponse>();
        foreach (var exchange in exchangesType)
        {
            try
            {
                var exchangeInstance = _exchangeFactory.CreateInstance(_clientService, exchange);
                var response = await exchangeInstance.GetCryptoPriceAsync(symbol);
                exchangesResponses.AddRange(response);

                Console.WriteLine($"Getting Values from {exchange.Name}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"ERROR Getting Values from {exchange.Name}: {e.Message}");
            }
        }
        return exchangesResponses;
    }

    private static List<Type> GetExchangeTypes()
    {
       return AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(s => s.GetTypes())
            .Where(p => typeof(IExchange).IsAssignableFrom(p) && p.IsClass).ToList();
        
    }
}