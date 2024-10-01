using CSharpJeitoCerto.Inventory.Domain.Services;
using Serilog;
using MongoDB.Driver;
using CSharpJeitoCerto.Order.Application.Commands;
using CSharpJeitoCerto.Order.Domain.Repositories;
using CSharpJeitoCerto.Order.Infrastructure.Repositories;
using CSharpJeitoCerto.Shared.Domain;
using CSharpJeitoCerto.Shared.Infrastructure.Database;
using CSharpJeitoCerto.Shared.Infrastructure.Messaging;
using CSharpJeitoCerto.Shared.Infrastructure.Notifications;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Configurando Serilog
builder.Host.UseSerilog((ctx, lc) => lc
    .WriteTo.Console()
    .ReadFrom.Configuration(ctx.Configuration));

// Configurando MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateOrderCommand).Assembly));

// Configurando as opções do banco de dados
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

// Configurando o MongoDB
builder.Services.AddSingleton<IMongoClient, MongoClient>(sp =>
{
    var settings = MongoClientSettings.FromConnectionString(builder.Configuration.GetConnectionString("MongoDbConnection"));
    return new MongoClient(settings);
});

// Registrando o repositório genérico
builder.Services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));

// Registrando repositórios e serviços específicos
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<EmailNotificationService>();
builder.Services.AddSingleton<EventBus>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();