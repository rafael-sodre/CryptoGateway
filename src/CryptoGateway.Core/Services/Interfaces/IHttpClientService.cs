namespace CryptoGateway.Core.Services.Interfaces;

public interface IHttpClientService
{
    Task<T?> GetAsync<T>(string baseUrl) where T : new();
}