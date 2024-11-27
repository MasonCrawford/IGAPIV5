using DataAccess.Entities;
using DataAccess.Entities.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DataAccess;

public class TradingAppContext : DbContext
{
    private static string _connectionSting;
    private readonly ILogger<TradingAppContext> _logger;

    public TradingAppContext(DbContextOptions<TradingAppContext> options, IConfiguration configuration,
        ILogger<TradingAppContext> logger)
        : base(options)
    {
        //_logger = logger;
        if (configuration["DOTNET_ENVIRONMENT"] == "Production")
        {
            //_logger.LogInformation("connecting to server database");
            var dbPassword = configuration["dbPassword"];
            _connectionSting =
                $"Server=tcp:trading-app-db-server.database.windows.net,1433;Initial Catalog=TradingAppDb;Persist Security Info=true;User ID=trading-app-db-server-admin;Password={dbPassword};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
        else
        {
            //_logger.LogInformation("connecting to local database");
            _connectionSting =
                @"data source=LocalHost;initial catalog=TradingApp5db;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
        }
    }

    public TradingAppContext(DbContextOptions<TradingAppContext> options) : base(options)
    {
        _logger = null;
        _connectionSting =
            @"data source=LocalHost;initial catalog=TradingApp5db;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
    }

    public DbSet<ProgramEntity> Program { get; set; }
    public DbSet<TradingTargetEntity> TradingTargets { get; set; }
    public DbSet<OrdersEntity> Orders { get; set; }
    public DbSet<TradingChartEntity> TradingChart { get; set; }
    public DbSet<PricesEntity> Prices { get; set; }
    public DbSet<PriceEntity> Price { get; set; }
    public DbSet<DepositBandEntity> DepositBand { get; set; }
    public DbSet<LogEntity> ApplicationLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionSting);
        // optionsBuilder.EnableDetailedErrors();
        // optionsBuilder.EnableSensitiveDataLogging();
    }

    public override int SaveChanges()
    {
        AddAuditInfo();

        return base.SaveChanges();
    }

    private void AddAuditInfo()
    {
        var entities = ChangeTracker.Entries<IEntity>()
            .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

        var utcNow = DateTime.UtcNow;

        foreach (var entity in entities)
        {
            if (entity.State == EntityState.Added)
                //entity.Entity.Id = new Guid();
                entity.Entity.CreatedOnUtc = utcNow;
            if (entity.State == EntityState.Modified) entity.Entity.LastModifiedOnUtc = utcNow;
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Set default precision to decimal property
        foreach (var property in modelBuilder.Model.GetEntityTypes()
                     .SelectMany(t => t.GetProperties())
                     .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            property.SetColumnType("decimal(18, 6)");
    }
}

/// <summary>
///     used by ef tools to create a TradingAppContext
/// </summary>
public class TradingAppContextFactory : IDesignTimeDbContextFactory<TradingAppContext>
{
    public TradingAppContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<TradingAppContext>();
        optionsBuilder.UseSqlServer(
            @"data source=LocalHost;initial catalog=TradingApp5db;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");

        return new TradingAppContext(optionsBuilder.Options);
    }
}