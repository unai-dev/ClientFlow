using ClientFlow.UI;
using ClientFlow.UI.Auth.Utils;
using ClientFlow.UI.Features.Auth.Services;
using ClientFlow.UI.Features.Client.Interfaces;
using ClientFlow.UI.Features.Client.Services;
using ClientFlow.UI.Features.ClientNotes.Interfaces;
using ClientFlow.UI.Features.ClientNotes.Services;
using ClientFlow.UI.Shared.Services;
using ClientFlow.UI.Shared.Utils;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddAuthorizationCore();

builder.Services.AddTransient<ILocalStorageService, LocalStorageService>();
builder.Services.AddScoped<AuthHeaderHandler>();

builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7226/v1/api/");
}).AddHttpMessageHandler<AuthHeaderHandler>();

builder.Services.AddScoped(sp =>
{
    var factory = sp.GetRequiredService<IHttpClientFactory>();
    return factory.CreateClient("ApiClient");
});

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IClientService, ClientService>();
builder.Services.AddScoped<IClientNotesService, ClientNotesService>();
builder.Services.AddScoped<IJSCustomEvents, JSCustomEvents>();


await builder.Build().RunAsync();
