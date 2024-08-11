using BMS.Data.Persistence.Contexts.Abstraction;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BMS.Data.Persistence.Contexts;

public class MsSqlDbContext : BaseDbContext
{
    public MsSqlDbContext()
    {
            
    }
    public MsSqlDbContext(DbContextOptions<MsSqlDbContext> options, IConfiguration configuration):base(options, configuration) 
    {
        
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("MSSql"));
        }
    }
}