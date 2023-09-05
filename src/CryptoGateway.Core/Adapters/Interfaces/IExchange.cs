using CryptoGateway.Domain.Responses;

namespace CryptoGateway.Core.Adapters.Interfaces;

public interface IExchange
{
    Task<List<ExchangeResponse>> GetCryptoPriceAsync(string? symbol);
    
    string? DefineSymbol(string? symbol);
}