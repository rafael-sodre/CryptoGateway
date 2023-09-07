using CryptoGateway.Core.Services.Interfaces;
using StackExchange.Redis;

namespace CryptoGateway.Core.Services;

public class RedisService: IRedisService
{
    private readonly IConnectionMultiplexer _redis;
    
    public RedisService(IConnectionMultiplexer redis)
    {
        _redis = redis ?? throw new ArgumentNullException(nameof(redis));
    }

    public void SetValue(string key, string value, TimeSpan? expiry = null)
    {
        var db = _redis.GetDatabase();
        db.StringSet(key, value, expiry);
    }

    public string GetValue(string key)
    {
        var db = _redis.GetDatabase();
        return db.StringGet(key);
    }

    public bool DeleteKey(string key)
    {
        var db = _redis.GetDatabase();
        return db.KeyDelete(key);
    }
}