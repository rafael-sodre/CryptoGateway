namespace CryptoGateway.Core.Services.Interfaces;

public interface IHttpClientService
{
    Task<List<T?>> GetAsync<T>(Uri uri) where T : new();
}