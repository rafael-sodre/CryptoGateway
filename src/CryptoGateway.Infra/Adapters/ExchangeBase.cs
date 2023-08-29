namespace CryptoGateway.Infra.Adapters;

public abstract class ExchangeBase
{
    protected static Uri GenerateUri(string baseUrl, string basePath, string? symbol = null)
    {
        var path = basePath;

        if (!string.IsNullOrWhiteSpace(symbol))
        {
            return new Uri(new Uri(baseUrl), path);
        }
        
        path += $"/api/v1/market/stats?symbol={symbol}";

        return new Uri(new Uri(baseUrl), path);
    }
}