using System.Net;
using CryptoGateway.Core.Adapters;
using CryptoGateway.Core.Adapters.Interfaces;
using CryptoGateway.Core.Factories;
using CryptoGateway.Core.Factories.Interfaces;
using CryptoGateway.Core.Services;
using CryptoGateway.Core.Services.Interfaces;
using Polly;
using Polly.Extensions.Http;
using Polly.Timeout;

namespace CryptoGateway.API.IoC;

public static class ServicesServiceCollection
{
    public static void AddHttpClientService(this IServiceCollection services)
    {
        var timeoutPolicy = Policy.TimeoutAsync<HttpResponseMessage>(10);
        
        services.AddHttpClient<IHttpClientService, HttpClientService>()
            .AddPolicyHandler(GetRetryPolicy())
            .AddPolicyHandler(timeoutPolicy);
    }

    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(msg => msg.StatusCode == HttpStatusCode.NotFound)
            .OrResult(msg => msg.StatusCode == HttpStatusCode.Unauthorized)
            .OrResult(msg => msg.StatusCode == HttpStatusCode.OK)
            .Or<TimeoutRejectedException>()
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (result, timeSpan, retryCount, context) =>
            {
                Console.WriteLine($"Attempt {retryCount} of 3. The request failed after {timeSpan.TotalSeconds} seconds. Message error: {result.Exception?.Message}");
            });
    }

    public static void AddServices(this IServiceCollection services)
    {
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