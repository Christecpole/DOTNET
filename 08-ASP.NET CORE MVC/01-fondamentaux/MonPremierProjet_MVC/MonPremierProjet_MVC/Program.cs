// creer l'application : préparer la configuration
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// prépare la configuration
// fonctionnalité que l'app prépare au démarrage pour pouvoir les utiliser partout.
// L'application veut utiliser le modele MVC active moi le mvc
builder.Services.AddControllersWithViews();


//construction de l'application : assemble l'application
// après cette ligne l'application existe
var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();
// est ce l'utilisateur est autorisé à atteindre le controller
app.UseAuthorization();

// recupérer les fichier static
app.MapStaticAssets();

//déclare la route par default
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Privacy}/{id?}")
    .WithStaticAssets();
//Produit/ajout

// L'application ecoute les requete http
app.Run();
