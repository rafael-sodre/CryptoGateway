using CryptoGateway.Core.Services;
using CryptoGateway.Core.Services.Interfaces;

namespace CryptoGateway.API.IoC;

public static class ServicesServiceCollection
{
    public static void AddHttpClientService(this IServiceCollection services)
    {
        services.AddHttpClient<HttpClientService>();
        services.AddScoped<IHttpClientService, HttpClientService>();
    }
}