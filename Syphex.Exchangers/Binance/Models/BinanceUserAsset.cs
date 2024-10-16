namespace Syphex.Exchangers.Binance.Models;

public class BinanceUserAsset
{
    [JsonPropertyName("coin")]
    public string Coin { get; set; }

    [JsonPropertyName("networkList")]
    public IEnumerable<BinanceNetwork> Networks { get; set; } = new List<BinanceNetwork>();
}
