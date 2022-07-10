namespace DynamicSharding;

public static class TenantExtensions
{
    public static void AddMultiTenant(this IServiceCollection serviceDescriptors, TenantOptions options)
    {
        if (options == null) return;

        serviceDescriptors.AddSingleton(options);
        serviceDescriptors.AddScoped<ILookupService, LookupService>();
        serviceDescriptors.AddDbContext<NormalDbContext>();
    }
}
