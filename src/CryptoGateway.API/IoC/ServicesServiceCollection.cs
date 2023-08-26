using CryptoGateway.Core.Services;
using CryptoGateway.Core.Services.Interfaces;
using CryptoGateway.Infra.Adapters;
using CryptoGateway.Infra.Adapters.Interfaces;

namespace CryptoGateway.API.IoC;

public static class ServicesServiceCollection
{
    public static void AddHttpClientService(this IServiceCollection services)
    {
        services.AddHttpClient();
        services.AddTransient<IHttpClientService, HttpClientService>();
    }

    public static void AddBinanceAdapter(this IServiceCollection services)
    {
        services.AddTransient<IBinanceExchangeAdapter, BinanceExchangeAdapter>();
    }
}