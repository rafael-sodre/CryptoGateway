using StackExchange.Redis;

namespace CryptoGateway.Core.Services.Interfaces;

public interface IRedisService
{
    void SetValue(string key, string value, TimeSpan? expiry = null);
    string GetValue(string key);
    bool DeleteKey(string key);
}