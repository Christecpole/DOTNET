using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TodoListBlazor;
using TodoListBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddBlazoredLocalStorage();

//Rootcomponents => liste des composant racine de l'application
//Add App => ajoute le composant app.razor comme racine
// #app => selecteur css cible la balise id=app dans index.html
// => App.razor sera affiché dans <div id="app">
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ITodoService, TodoService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5173/") }); // <-URL de notre api

await builder.Build().RunAsync();
