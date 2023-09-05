using CryptoGateway.Core.Adapters;
using CryptoGateway.Core.Adapters.Interfaces;
using CryptoGateway.Core.Factories.Interfaces;
using CryptoGateway.Core.Services.Interfaces;

namespace CryptoGateway.Core.Factories;

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