// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using UltraTuneTest.Server.Abstractions;
using UltraTuneTest.Server.Operations;
using UltraTuneConsole;

Console.WriteLine("Hello, World!");

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddScoped<IShoppingCart, ShoppingCart>();
builder.Services.AddScoped<IOrder, Order>();
builder.Services.AddScoped<IDiscountManager, DiscountManager>();


using IHost host = builder.Build();
Start();



await host.RunAsync();


static void Start()
{
    IShoppingCart _cart = new ShoppingCart();
    IOrder _order = new Order(_cart);
    IDiscountManager _discount = new DiscountManager(_cart);
    var service = new UltraTuneExternalService(_cart, _order, _discount);
}

