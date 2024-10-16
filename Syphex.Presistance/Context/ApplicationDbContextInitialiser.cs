using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Syphex.Presistance.Context;

public static class InitialiserExtensions
{
    public static async Task InitialiseDatabaseAsync(this IHost host)
    {
        using var scope = host.Services.CreateScope();

        var initialiser =
            scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();

        await initialiser.InitialiseAsync();

        await initialiser.SeedAsync();
    }
}

public class ApplicationDbContextInitialiser(
    ApplicationDbContext context,
    ILogger<ApplicationDbContextInitialiser> logger
)
{
    private readonly ApplicationDbContext _context = context;
    private readonly ILogger<ApplicationDbContextInitialiser> _logger = logger;

    public async Task InitialiseAsync()
    {
        try
        {
            await _context.Database.MigrateAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Error occured while initialising database.");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An Error occured while seeding database.");
            throw;
        }
    }

    public async Task TrySeedAsync()
    {
        if (!_context.Exchangers.Any())
        {
            var binance = Exchanger.Create("Binance");
            var mexc = Exchanger.Create("Mexc");
            var htx = Exchanger.Create("HTX");
            var bitget = Exchanger.Create("BitGet");
            var bingX = Exchanger.Create("BingX");

            await _context.Exchangers.AddRangeAsync([binance, mexc, htx, bitget, bingX]);
            await _context.SaveChangesAsync();
        }
    }
}
