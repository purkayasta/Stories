namespace DynamicSharding;

public static class ShardingInjection
{
    public static void AddSharding(this IServiceCollection serviceDescriptors, ShardingOptions options)
    {
        if (options == null) return;

        serviceDescriptors.AddSingleton(options);
        serviceDescriptors.AddScoped<ILookupService, LookupService>();
        serviceDescriptors.AddDbContext<NormalDbContext>();
    }
}
