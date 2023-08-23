using CryptoGateway.Core.Services;
using CryptoGateway.Core.Services.Interfaces;

namespace CryptoGateway.API.IoC;

public static class ServiceServicesCollection
{
    public static void CryptoGatewayService(this IServiceCollection services)
    {
        services.AddSingleton<IHttpService, HttpService>();
    }
}