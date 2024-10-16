namespace Syphex.Infrastructure;

public static class DependecyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        string connectionString = configuration.GetConnectionString("DevConnection");

        services.AddDbContext<ApplicationDbContext>(
            (sp, opt) =>
            {
                opt.AddInterceptors(sp.GetService<ISaveChangesInterceptor>());

                opt.UseNpgsql(connectionString, b => b.MigrationsAssembly("Syphex.Presistance"));
            }
        );

        services.AddScoped<IApplicationDbContext>(provider =>
            provider.GetRequiredService<ApplicationDbContext>()
        );

        services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddSingleton(TimeProvider.System);
        return services;
    }
}
