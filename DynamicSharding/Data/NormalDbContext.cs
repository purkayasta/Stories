using Microsoft.EntityFrameworkCore;

namespace DynamicSharding;

public class NormalDbContext : DbContext
{
    private readonly ILookupService _lookupService;

    public NormalDbContext(
        DbContextOptions<NormalDbContext> options,
        ILookupService lookupService) : base(options)
    {
        _lookupService = lookupService;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        Tenant tenant = _lookupService.GetTenant();
        if (tenant == null || string.IsNullOrEmpty(tenant.DbConnectionString)) return;

        /*
        We can use what ever provider ef core support, just pass the appropiate connection string
        like if we want to use sql server here then we will replace the line with this -> optionsBuilder.UseSqlServer(tenant.DbConnectionString);
        */
        optionsBuilder.UseInMemoryDatabase(tenant.DbConnectionString);
    }

    public DbSet<User> Users { get; set; }
}