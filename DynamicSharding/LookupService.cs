namespace DynamicSharding;

public class LookupService : ILookupService
{
    private readonly ShardingOptions _options;
    private string _tenantId;

    public LookupService(ShardingOptions options)
    {
        _options = options;
    }

    public Tenant GetTenant()
    {
        if (string.IsNullOrEmpty(_tenantId)) return null;
        if (_options == null) return null;

        Tenant appropiateTenant = _options.ShardingConfigurations
            .FirstOrDefault(x => x.TenantIds.Any(x => x.Equals(_tenantId)));
        return appropiateTenant;
    }

    public void SetTenant(string tenantId)
    {
        if (string.IsNullOrEmpty(tenantId)) return;
        _tenantId = tenantId;
    }
}

public interface ILookupService
{
    Tenant GetTenant();
    void SetTenant(string tenantId);
}