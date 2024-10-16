namespace Syphex.Exchangers.Binance.Models;

public class BinanceNetwork {
    [JsonPropertyName("depositEnable")]
    public bool DepositEnabled {get; set;}

    [JsonPropertyName("withdrawEnable")]
    public bool WithdrawEnable {get; set;}

    [JsonPropertyName("withdrawFee")]
    public decimal Fee {get; set;}

    [JsonPropertyName("name")]
    public string Name {get; set;}

    [JsonPropertyName("network")]
    public string Network {get; set;}
}
