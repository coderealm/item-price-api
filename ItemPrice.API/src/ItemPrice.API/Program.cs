using ItemPrice.API;
using ItemPrice.Data;
using ItemPrice.Hub;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();

builder.Services.AddSingleton<IItemPriceUpdateService, ItemPriceUpdateService>();
builder.Services.AddSingleton<IItemPriceHub, ItemPriceHub>();
builder.Services.AddSingleton<IItemDataSource, ItemDataSource>();

builder.Services.AddHostedService<ItemPriceUpdateService>();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:3005")
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()
              .SetIsOriginAllowed(_ => true);
    });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Item Price API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.MapHub<ItemPriceHub>("/itempriceshub");

await app.RunAsync();
