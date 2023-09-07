namespace CryptoGateway.Core.Settings;

public class DatabaseSettings: IDatabaseSettings
{
    public string PostgreSQL { get; set; }

    public string Redis { get; set; }

    public string RabbitMq { get; set; }

}