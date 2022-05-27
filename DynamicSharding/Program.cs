var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapGet("/intro/", () =>
{
    return "Hello World From Dynamic Sharding";
});


app.MapGet("/users/", () =>
{
    return "User List";
});

app.MapGet("/users/{id}", (string id) =>
{
    return id;
});


app.Run();
