namespace Syphex.Domain.Entities;

public class Pair : BaseEntity
{
    public decimal Spread { get; set; }

    public Guid BuyTickerId { get; set; }
    public Ticker BuyTicker { get; set; }

    public Guid SellTickerId { get; set; }
    public Ticker SellTicker { get; set; }

    public Guid BuyNetworkId { get; set; }
    public Network BuyNetwork { get; set; }

    public Guid SellNetworkId { get; set; }
    public Network SellNetwork { get; set; }

    private Pair(
        decimal spread,
        Guid buyTickerId,
        Guid sellTickerId,
        Guid buyNetworkId,
        Guid sellNetworkId
    )
    {
        Spread = spread;
        BuyTickerId = buyTickerId;
        SellTickerId = sellTickerId;
        BuyNetworkId = buyNetworkId;
        SellNetworkId = sellNetworkId;
    }

    public static Pair Create(
        decimal spread,
        Guid buyTickerId,
        Guid sellTickerId,
        Guid buyNetworkId,
        Guid sellNetworkId
    )
    {
        return new Pair(spread, buyTickerId, sellTickerId, buyNetworkId, sellNetworkId);
    }
}

public static class PairExtenstions
{
    public static Pair Update(this Pair pair, decimal spread)
    {
        pair.Spread = spread;
        pair.Update();

        return pair;
    }
}
