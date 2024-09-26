using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using ClassLibrary.models;
using ClassLibrary.Configurations;
namespace ClassLibrary.Data;

public class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
        // Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public DbSet<Login> Logins => Set<Login>();
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Genre> Genres => Set<Genre>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Sale> Sales => Set<Sale>();

    public static ILoggerFactory? MyloggerFactory = LoggerFactory.Create(configure =>
    {
        configure.AddConsole();
    });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
        string? connStr = config.GetConnectionString("SQLServerConnections");
        optionsBuilder.UseSqlServer(connStr);
        optionsBuilder.UseLoggerFactory(MyloggerFactory);
    }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LoginConfiguration());
        }



}
