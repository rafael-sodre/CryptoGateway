using System.Collections.ObjectModel;

namespace CryptoGateway.Domain.Constants;

public class ExchangeConstants
{
    public const string BinanceBaseUrl = "https://api.binance.com";
    public const string BinancePath = "/api/v3/ticker/24hr";
    
    public const string KucoinBaseUrl = "https://api.kucoin.com/";
    public const string KucoinPath = "api/v1/market/stats";
}