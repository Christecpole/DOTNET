using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TodoListBlazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

//Rootcomponents => liste des composant racine de l'application
//Add App => ajoute le composant app.razor comme racine
// #app => selecteur css cible la balise id=app dans index.html
// => App.razor sera affiché dans <div id="app">
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
