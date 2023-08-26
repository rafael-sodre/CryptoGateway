using CryptoGateway.Domain.Responses;

namespace CryptoGateway.Infra.Adapters.Interfaces;

public interface IBinanceExchangeAdapter
{
    Task<List<ExchangeResponse>> GetCryptoPriceAsync(string filter = null);
}