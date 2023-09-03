using CryptoGateway.Core.Services.Interfaces;
using CryptoGateway.Infra.Adapters.Interfaces;

namespace CryptoGateway.Core.Factories.Interfaces;

public interface IExchangeFactory
{
    IExchange CreateInstance(IHttpClientService httpClientService, Type exchangeType);
}