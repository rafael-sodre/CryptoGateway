namespace CryptoGateway.Domain.Responses;

public class ExchangeResponse
{
    public ExchangeResponse(string exchangeName, List<CryptoResponse> data)
    {
        ExchangeName = exchangeName;
        Data = data;
    }

    public string ExchangeName { get; set; }
    public List<CryptoResponse> Data { get; set; }
}