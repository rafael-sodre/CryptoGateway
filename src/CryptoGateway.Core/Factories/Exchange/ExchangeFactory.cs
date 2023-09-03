using CryptoGateway.Core.Factories.Interfaces;
using CryptoGateway.Core.Services.Interfaces;
using CryptoGateway.Infra.Adapters;
using CryptoGateway.Infra.Adapters.Interfaces;

namespace CryptoGateway.Core.Factories.Exchange;

public class ExchangeFactory: IExchangeFactory
{
    public IExchange CreateInstance(IHttpClientService httpClientService, Type exchangeType)
    {
        if (exchangeType == typeof(BinanceExchange))
        {
            return new BinanceExchange(httpClientService);
        }
        if (exchangeType == typeof(KucoinExchange))
        {
            return new KucoinExchange(httpClientService);
        }
        else
        {
            throw new ArgumentException("Exchange type not supported.");
        }
    }
}