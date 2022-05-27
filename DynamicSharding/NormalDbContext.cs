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

        optionsBuilder.UseSqlServer(tenant.DbConnectionString);
    }

    public DbSet<User> Users { get; set; }
}


public record User(int Id, string TenantId, string FirstName, bool IsActive, DateTime CreatedOn);