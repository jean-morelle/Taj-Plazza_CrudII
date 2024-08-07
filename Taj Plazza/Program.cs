using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Taj_Plazza;
using Taj_Plazza.HtppInterface;
using Taj_Plazza.HttpServices;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<IClientHttpServices,ClientHttpServices>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7136/") });
 
await builder.Build().RunAsync();
