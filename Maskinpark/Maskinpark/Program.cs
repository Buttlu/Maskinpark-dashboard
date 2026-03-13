using Maskinpark.Components;
using MaskinPark.Contracts;
using MaskinPark.Infrastructure.Persistance;
using MaskinPark.Infrastructure.Repositories;
using MaskinPark.Infrastructure.Services;
using MaskinPark.Shared.Constants;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddHttpClient(Uris.MachineDashBoardUriName, client =>
{
    var apiBaseUri = builder.Configuration[Uris.MachineDashBoardUriName]
        ?? throw new InvalidOperationException("Base URI not found");

    client.BaseAddress = new Uri(apiBaseUri);
    client.Timeout = TimeSpan.FromSeconds(30);
    client.DefaultRequestHeaders.Clear();
    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMachineService, MachineService>();
builder.Services.AddScoped<IMachineRepository, MachineRepository>();
builder.Services.AddScoped(provider => new Lazy<IMachineRepository>(() => provider.GetRequiredService<IMachineRepository>()));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) {
    app.UseWebAssemblyDebugging();
} else {
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(Maskinpark.Client._Imports).Assembly);

app.MapControllers();

app.Run();
