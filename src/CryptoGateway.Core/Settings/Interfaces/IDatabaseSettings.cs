namespace CryptoGateway.Core.Settings;

public interface IDatabaseSettings
{
    public string PostgreSQL { get; }
    public string Redis { get; }
}