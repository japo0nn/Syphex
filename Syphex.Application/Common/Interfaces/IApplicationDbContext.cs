namespace Syphex.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Ticker> Tickers { get; }
    DbSet<Network> Networks { get; }
    DbSet<Exchanger> Exchangers { get; }
    DbSet<Pair> Pairs { get; }
}
