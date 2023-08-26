namespace CryptoGateway.Domain.Responses;

public class CryptoResponse
{
    public CryptoResponse(string price, string symbol)
    {
        Price = price;
        Symbol = symbol;
    }
    public string Price { get; set; }
    public string Symbol { get; set; }
}