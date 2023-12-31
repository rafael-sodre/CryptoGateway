namespace CryptoGateway.Domain.Responses;

public class KucoinResponse
{
    public KucoinData data { get; set; }
}

public class KucoinData
{
    public string symbol { get; set; }
    public string last { get; set; }
}