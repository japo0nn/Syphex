namespace Syphex.Domain.Entities;

public class Ticker : BaseEntity
{
    public string Symbol { get; set; }
    public decimal BuyPrice { get; set; }
    public decimal SellPrice { get; set; }

    public Guid ExchangerId { get; set; }

    public ICollection<Network> Networks { get; set; } = new List<Network>();

    private Ticker(string symbol, decimal buyPrice, decimal sellPrice, Guid exchangerId)
    {
        Symbol = symbol;
        BuyPrice = buyPrice;
        SellPrice = sellPrice;
        ExchangerId = exchangerId;
    }

    public static Ticker Create(
        string symbol,
        decimal buyPrice,
        decimal sellPrice,
        Guid exchangerId
    )
    {
        return new Ticker(symbol, buyPrice, sellPrice, exchangerId);
    }
}

public static class TickerExtensions
{
    public static Ticker Update(this Ticker ticker, decimal buyPrice, decimal sellPrice)
    {
        ticker.BuyPrice = buyPrice;
        ticker.SellPrice = sellPrice;
        ticker.Update();
        return ticker;
    }
}
