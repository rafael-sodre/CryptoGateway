using CryptoGateway.Domain.Responses;

namespace CryptoGateway.Infra.Adapters.Interfaces;

public interface IExchange
{
    Task<List<ExchangeResponse>> GetCryptoPriceAsync(string? symbol);
    
    string? DefineSymbol(string? symbol);
}