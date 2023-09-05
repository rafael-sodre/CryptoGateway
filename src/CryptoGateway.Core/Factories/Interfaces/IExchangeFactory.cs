using CryptoGateway.Core.Adapters.Interfaces;
using CryptoGateway.Core.Services.Interfaces;

namespace CryptoGateway.Core.Factories.Interfaces;

public interface IExchangeFactory
{
    IExchange CreateInstance(IHttpClientService httpClientService, Type exchangeType);
}