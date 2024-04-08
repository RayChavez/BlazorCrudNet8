
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using NeitekApp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<IMetaService, MetaService>();
builder.Services.AddScoped<ITareaServices, TareaServices>();

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri("https://neitekapi.azurewebsites.net/")
});


builder.Services.AddBlazorBootstrap();

await builder.Build().RunAsync();
