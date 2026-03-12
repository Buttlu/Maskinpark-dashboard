using MaskinPark.Contracts;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<IUnitOfWork>();
builder.Services.AddScoped<IMachineRepository>();
builder.Services.AddScoped<IMachineService>();

await builder.Build().RunAsync();
