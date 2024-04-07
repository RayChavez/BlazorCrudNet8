using CurrieTechnologies.Razor.SweetAlert2;
using NeitekApp.Client.Pages;
using NeitekApp.Components;
using NeitekApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://neitekapi.azurewebsites.net/") });

builder.Services.AddScoped<IMetaServices, MetaServices>();
builder.Services.AddScoped<ITareaServices, TareaServices>();

builder.Services.AddSweetAlert2();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(NeitekApp.Client._Imports).Assembly);

app.Run();
