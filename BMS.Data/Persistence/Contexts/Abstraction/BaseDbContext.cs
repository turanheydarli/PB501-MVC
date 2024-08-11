using System.Reflection;
using BMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BMS.Data.Persistence.Contexts.Abstraction;

public abstract class BaseDbContext : DbContext
{
    protected IConfiguration Configuration { get; }

    public BaseDbContext()
    {
    }

    public BaseDbContext(DbContextOptions<BaseDbContext> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }

    public BaseDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Publisher> Publishers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        Assembly assembly = Assembly.GetAssembly(typeof(BaseDbContext)) ??
                            Assembly.GetExecutingAssembly();

        modelBuilder.ApplyConfigurationsFromAssembly(assembly);
    }
}