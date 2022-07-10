using DynamicSharding;
using DynamicSharding.Brokers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var options = builder.Configuration.Get<TenantOptions>();

builder.Services.AddMultiTenant(options);

builder.Services.AddScoped<IUserBroker, UserBroker>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/hello/", () =>
{
    return "Hello World From Dynamic Sharding";
});


app.MapPost("/users/", (User user, string tenantId, IUserBroker userBroker, ILookupService lookupService) =>
{
    if (user is null) return Results.BadRequest("Error Occurred");

    lookupService.SetTenant(tenantId);

    var result = userBroker.Insert(user);

    return result > 0 ? Results.Ok() : Results.BadRequest("Cannot create user");
});

app.MapGet("/users/{id}", (string id, string tenantId, IUserBroker userBroker, ILookupService lookupService) =>
{
    lookupService.SetTenant(tenantId);

    return Results.Ok(userBroker.GetUser(id));
});


app.Run();
