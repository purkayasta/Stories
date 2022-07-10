namespace DynamicSharding;

public class Tenant
{
    public string[] TenantIds { get; set; }
    public string DbConnectionString { get; set; }
}

public record User(string Id, string FirstName, bool IsActive, DateTime CreatedOn);