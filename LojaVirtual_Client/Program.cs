using Blazored.LocalStorage;
using LojaVirtual_Client;
using LojaVirtual_Client.Service;
using LojaVirtual_Client.Service.IService;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NzYzNTgwQDMyMzAyZTMzMmUzMFc3aHlSUk9yWG5aSmtiZ25hNElwU3N1ZmlnenREb1ZvWVdUMCtPYkJCZjA9");

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration.GetValue<string>("BaseAPIUrl")) });
builder.Services.AddScoped<IProdutoService, ProdutoService>();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
