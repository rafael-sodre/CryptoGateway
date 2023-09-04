using CryptoGateway.Core.Factories.Exchange;
using CryptoGateway.Core.Factories.Interfaces;
using CryptoGateway.Core.Services;
using CryptoGateway.Core.Services.Exchange;
using CryptoGateway.Core.Services.Interfaces;
using CryptoGateway.Infra.Adapters;
using CryptoGateway.Infra.Adapters.Interfaces;

namespace CryptoGateway.API.IoC;

public static class ServicesServiceCollection
{
    public static void AddHttpClientService(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddScoped<IHttpClientService, HttpClientService>();
        services.AddScoped<IExchangeService, ExchangeService>();
    }

    public static void AddAdapters(this IServiceCollection services)
    {
        services.AddScoped<IExchange, BinanceExchange>();
        services.AddScoped<IExchange, KucoinExchange>();
    }

    public static void AddFactories(this IServiceCollection services)
    {
        services.AddScoped<IExchangeFactory, ExchangeFactory>();
    }
}