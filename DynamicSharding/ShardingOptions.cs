namespace DynamicSharding;

public class ShardingOptions
{
    public List<Tenant> ShardingConfigurations { get; set; }
}

public class Tenant
{
    public string[] TenantIds { get; set; }
    public string DbConnectionString { get; set; }
}
