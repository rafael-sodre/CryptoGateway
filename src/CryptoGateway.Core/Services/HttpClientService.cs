using System.Text.Json;
using CryptoGateway.Core.Services.Interfaces;

namespace CryptoGateway.Core.Services;

public class HttpClientService : IHttpClientService
{
    private readonly HttpClient _httpClient;

    public HttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<T?> GetAsync<T>(string url) where T : new()
    {
        var response = await _httpClient.GetAsync($"{url}");
        
        var result = new T();

        if (!response.IsSuccessStatusCode)
        {
            return result;
        }
        
        var content = await response.Content.ReadAsStringAsync();
        result = JsonSerializer.Deserialize<T>(content);
        
        return result;

    }
}