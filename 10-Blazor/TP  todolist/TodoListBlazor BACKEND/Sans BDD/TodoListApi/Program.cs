using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using System.Text;
using TodoListApi.Middlewares;
using TodoListApi.Repositories;
using TodoListApi.Services;

var builder = WebApplication.CreateBuilder(args);

// ===== CONFIGURATION DES SERVICES =====

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

// INJECTION DE DEPENDANCES
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddScoped<IAuthService, AuthService>();

// CONFIGURATION JWT
var secretKey = builder.Configuration["Jwt:SecretKey"];
if (string.IsNullOrEmpty(secretKey))
{
    throw new InvalidOperationException("La cle JWT n'est pas configuree dans appsettings.json");
}

builder.Services.AddAuthentication(options =>
    {
        //Jwtbearer = on utilise des tokens jwt dans le header Authorization
        // C'est le schema par défaut pour authentifier et pour "Challenger" (demander auth)
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "TodoListApi",
            ValidAudience = "TodoListApi",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            ClockSkew = TimeSpan.Zero
        };
    });


var app = builder.Build();

// ===== CONFIGURATION DU PIPELINE HTTP =====

// Le middleware d'exceptions doit etre EN PREMIER
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

// IMPORTANT : L'ordre compte !
// 1. Authentication (qui suis-je ?)
// 2. Authorization (ai-je le droit ?)
app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
