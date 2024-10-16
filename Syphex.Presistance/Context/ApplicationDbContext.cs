namespace Syphex.Presistance.Context;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Exchanger> Exchangers => Set<Exchanger>();
    public DbSet<Ticker> Tickers => Set<Ticker>();
    public DbSet<Network> Networks => Set<Network>();
    public DbSet<Pair> Pairs => Set<Pair>();
}
