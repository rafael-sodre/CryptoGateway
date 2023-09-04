using CryptoGateway.Domain.Responses;

namespace CryptoGateway.Core.Services.Interfaces;

public interface IExchangeService
{
    Task<List<ExchangeResponse>> GetCryptoPriceAsync(string? symbol);
}