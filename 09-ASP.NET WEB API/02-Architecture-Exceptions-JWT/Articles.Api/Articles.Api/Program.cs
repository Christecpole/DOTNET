using Articles.Api.Middlewares;
using Articles.Api.Repositories;
using Articles.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    //Information de base de l'API
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Articles",
        Version = "v1",
        Description = "Api de gestion des articles avec authentification JWT"
    });

    // configuration du bouton AUthorize dans swagger
    //Permet de tester les routes protégées directement dans swagger
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        //Nom du header HTTP où envoyer le token
        Name = "Authorization",

        // Type Http = on utilise le schéma bearer (standart OAuth2/JWT)
        Type = SecuritySchemeType.Http,

        // "Bearer" = le prefixe du token dans le header
        Scheme = "Bearer",

        // Format du token (informatif)
        BearerFormat = "JWT",

        // Le token dasn le Header Http (pas dans l'url ou dans le body)
        In = ParameterLocation.Header,

        //Description affichée dans la popup Swagger
        Description = "Entrez votre token JWT. \nExemple : eyJHjhfgjhdfOSDGJ...."
    });

    // Applique cette sécurité à TOUTES les routes par défaut
    // (les routes sans [Authorize] fonctionneront quand même sans token)
    // AddSecurityRequirement dit à Swagger :
    //"Pour TOUTES les routes, ajoute un cadenas qui demande Bearer token"
    // Cette configuration permet d'afficher le bouton "Authorize" dans Swagger
    // et d'ajouter automatiquement le cadenas sur les routes protégées ([Authorize])
    options.AddSecurityRequirement(document =>
    {
        // OpenApiSecurityRequirement = règle de sécurité appliquée aux routes Swagger
        // C'est une sorte de dictionnaire :
        //  - CLÉ   : le schéma de sécurité utilisé (ici Bearer / JWT)
        //  - VALEUR: les scopes requis (vide car on n'utilise pas OAuth avec scopes)

        var requirement = new OpenApiSecurityRequirement
        {
            // OpenApiSecuritySchemeReference fait référence au schéma "Bearer"
            // défini plus haut avec AddSecurityDefinition("Bearer", ...)
            // 
            // "Bearer" : nom exact du schéma
            // document : permet à Swagger de retrouver ce schéma au moment du rendu
            [new OpenApiSecuritySchemeReference("Bearer", document)] = new List<string>()
        };

        // On retourne cette règle pour l'appliquer à TOUTES les routes Swagger
        return requirement;
    });

});

// enregistrer les repo
builder.Services.AddScoped<IArticleRepository, ArticleRepository>();
builder.Services.AddScoped<IAuteurRepository, AuteurRepository>();

//enregistrer les services
builder.Services.AddScoped<IArticleService, ArticleService>();
builder.Services.AddScoped<IAuteurService, AuteurService>();
builder.Services.AddScoped<IAuthService, AuthService>();


// Configuration de l'authentification JWT
//--------------------

//Récupération de la clé secrète depuis appsettings
//C'est la MEME clé que celle utilisé pour signer les tokens
var secretKey = builder.Configuration["jwtSettings:SecretKey"]
                ?? throw new InvalidOperationException("jwtSettings:SecretKey manquant.");

//conversion de la clé en tableau de bytes
var key = Encoding.ASCII.GetBytes(secretKey);

//Configuration du systeme d'authentification ASP.NEt
builder.Services.AddAuthentication(options =>
{
    //Jwtbearer = on utilise des tokens jwt dans le header Authorization
    // C'est le schema par défaut pour authentifier et pour "Challenger" (demander auth)
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    // false : accepter les requete http(pas https)
    // en prod : toujours true
    options.RequireHttpsMetadata = false;

    //stocker le token dans le httpcontext pour y acceder si besoin plus tard
    options.SaveToken = true;

    //PARAMETRE DE VALIDATION DU TOKEN
    //A chque requete avec [Authorize] ASP.NET vérifie automatiquement
    options.TokenValidationParameters = new TokenValidationParameters
    {
        //verifie que la signature correspond à notre clé secrète
        // Si quelqu'un modifie le token, la signature ne correspondra plus => rejeté
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),

        //On ne vérifie pas l'emmetru pour simplifier le cours
        // En prod ; validateissuer = true + ValidIssuer = "MONAPI"
        //L'issuer garantit que le token vient bien du bon serveur d'authentification
        ValidateIssuer = false,

        //On ne verifie par l'audience pour simplifier le cours
        // en prod : ValidateAudience = true + ValideAUdience = "Mes clients"
        // Token pour app mobile est différent du token pour app web
        //Chacun verifie son audience
        ValidateAudience = false,

        // On veut pas de tolérance sur l'expiration du token
        // Par defaut : 5minutes de marge
        //Ici on met 0 pour dire que une fois le token expiré alors il est rejeté immédiatement
        ClockSkew = TimeSpan.Zero

    };

});

var app = builder.Build();

app.UseMiddleware<GlobalExceptionHandler>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        // Spécifie EXACTEMENT où Swagger doit chercher le JSON
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API Articles V1");
    });

    app.MapGet("/", () => Results.Redirect("/swagger"));
}

// Configure the HTTP request pipeline.
// Qui est tu ?
// Lit le header Authorization , valide le token JWT
// Remplire HttpContext.User avec les claims du token 
app.UseAuthentication(); 

// As tu le droit?
//Verifie les attributs [Authorize] et [Authorize(Roles="...")]
app.UseAuthorization();

app.MapControllers();

app.Run();
