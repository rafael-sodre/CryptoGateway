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

    public async Task<List<T?>> GetAsync<T>(Uri uri) where T : new()
    {
        try
        {
            var response = await _httpClient.GetAsync(uri);
        
            var result = new List<T?>();

            if (!response.IsSuccessStatusCode)
            {
                return result;
            }
        
            var content = await response.Content.ReadAsStringAsync();

            //TODO: criar uma sobrecarga neste método. Um retornando uma lista outro retornando um elemento
            try
            {
                var contentDeserialized = JsonSerializer.Deserialize<T>(content);
                result.Add(contentDeserialized);
            }
            catch (JsonException)
            {
                var contentDeserialized = JsonSerializer.Deserialize<List<T>>(content);
                result.AddRange(contentDeserialized);
            }
        
            return result;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}