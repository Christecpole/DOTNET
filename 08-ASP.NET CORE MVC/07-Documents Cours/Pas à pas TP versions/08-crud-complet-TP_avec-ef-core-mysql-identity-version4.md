# CRUD Complet avec Entity Framework Core, MySQL et ASP.NET Core Identity

## Objectif

> **Temps estimé : 5h**
> 
> Ajouter **ASP.NET Core Identity** à votre application de gestion de produits existante pour :
> - **Sécuriser l'accès** à l'application avec une page de login
> - **Protéger les pages** avec `[Authorize]`
> - **Gérer les utilisateurs** (inscription, connexion, déconnexion)
> - **Conserver la même architecture** (Repository Pattern + Service Layer)
> - **Ajouter les tables Identity** à votre base de données existante

---

## Introduction Théorique

### QUOI : Qu'allons-nous faire ?

Vous allez **ajouter ASP.NET Core Identity** à votre application de gestion de produits existante (celle créée dans l'exercice précédent avec EF Core et MySQL) pour sécuriser l'accès à l'application.

**Architecture (identique à l'exercice précédent + Identity) :**
```
Controller (Vue) avec [Authorize]
    ↓ utilise
Service (Logique métier)
    ↓ utilise
Repository (Accès aux données)
    ↓ utilise
Entity Framework Core (MySQL) + Identity
```

**Différence avec l'exercice précédent :**
- **Exercice précédent** : Application accessible à tous (pas d'authentification)
- **Cet exercice** : **ASP.NET Core Identity** + **Page de login** (accès sécurisé)

### POURQUOI utiliser ASP.NET Core Identity ?

**Avantages d'Identity :**
- **Authentification** : Gestion des utilisateurs, mots de passe, connexions
- **Autorisation** : Contrôle d'accès aux pages et fonctionnalités
- **Sécurité** : Hashage des mots de passe, protection CSRF, etc.
- **Intégration** : S'intègre parfaitement avec EF Core et MySQL
- **Personnalisable** : Vous pouvez personnaliser les modèles et les vues

**Fonctionnalités incluses :**
- Inscription (Register)
- Connexion (Login)
- Déconnexion (Logout)
- Gestion des rôles (optionnel)
- Gestion des claims (optionnel)

---

## Prérequis

### Logiciels à installer

1. **MySQL Server** (si pas déjà installé)
   - Télécharger depuis : https://dev.mysql.com/downloads/mysql/
   - Installer avec les paramètres par défaut
   - Noter le mot de passe root

2. **MySQL Workbench** (si pas déjà installé)
   - Télécharger depuis : https://dev.mysql.com/downloads/workbench/
   - Installer avec les paramètres par défaut

3. **Visual Studio** ou **Visual Studio Code** avec extension C#

---

## Guide Pas à Pas Détaillé

**IMPORTANT :** Ce guide part du principe que vous avez déjà terminé l'exercice précédent (CRUD avec EF Core et MySQL) et que vous avez une application fonctionnelle. Nous allons **ajouter** Identity à ce projet existant, sans rien casser.

**Ce que vous allez faire :**
- Ajouter le package Identity
- Créer le modèle ApplicationUser
- Modifier le DbContext existant pour hériter de IdentityDbContext
- Modifier Program.cs pour configurer Identity
- Ajouter [Authorize] au Controller Produits existant
- Créer le Controller Account (nouveau)
- Créer les ViewModels Account (nouveaux)
- Créer les vues Account (nouvelles)
- Modifier _Layout pour ajouter le menu de connexion
- Créer une migration pour ajouter les tables Identity

---

### Partie 1 : Préparer le projet existant

#### Étape 1.1 : Ouvrir le projet existant

**Action à faire :**
1. Ouvrez Visual Studio
2. Ouvrez votre projet existant de gestion de produits (celui créé dans l'exercice précédent avec EF Core et MySQL)
3. Vérifiez que le projet fonctionne correctement avant de continuer

#### Étape 1.2 : Installer le package ASP.NET Core Identity

**Action à faire :**
1. Clic droit sur le projet → **Gérer les packages NuGet**
2. Onglet **Parcourir**
3. Installez le package suivant :

**Package : ASP.NET Core Identity**
- Nom : `Microsoft.AspNetCore.Identity.EntityFrameworkCore`
- Version : Dernière version stable (ex: 8.0.x)

**Note :** Les autres packages (EF Core, Pomelo, Tools) sont déjà installés dans votre projet existant.

**Méthode alternative (via Package Manager Console) :**
```powershell
Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore
```

**Méthode alternative (via CLI .NET) :**
```bash
dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore
```

**Ce que vous devez comprendre :**
- `Microsoft.AspNetCore.Identity.EntityFrameworkCore` = Identity avec EF Core
- Identity utilise EF Core pour stocker les utilisateurs en base de données
- Les autres packages sont déjà installés dans votre projet existant

---

### Partie 2 : Utiliser la base de données existante ou en créer une nouvelle

Vous avez deux options :

**Option 1 : Utiliser la base de données existante**
- Si vous voulez ajouter les tables Identity à votre base de données existante (`GestionProduitsDB`)
- Les tables Identity seront ajoutées aux tables existantes (`Categories`, `Produits`)
- Vos données existantes seront conservées

**Option 2 : Créer une nouvelle base de données**
- Si vous voulez repartir de zéro avec une nouvelle base de données
- Créez une nouvelle base de données dans MySQL Workbench (voir ci-dessous)

#### Étape 2.1 : Option 1 - Utiliser la base de données existante

Si vous choisissez d'utiliser votre base de données existante :
- Aucune action nécessaire dans MySQL Workbench
- Les tables Identity seront ajoutées lors de la migration
- Passez directement à la Partie 3

#### Étape 2.2 : Option 2 - Créer une nouvelle base de données (optionnel)

Si vous préférez créer une nouvelle base de données :

**Action à faire :**
1. Ouvrez **MySQL Workbench**
2. Connectez-vous à MySQL
3. Exécutez la commande suivante :

```sql
CREATE DATABASE IF NOT EXISTS GestionProduitsIdentityDB 
CHARACTER SET utf8mb4 
COLLATE utf8mb4_unicode_ci;
```

4. Cliquez sur l'icône **⚡ Execute** (ou appuyez sur `Ctrl+Enter`) pour exécuter la requête

**Important :** Si vous créez une nouvelle base de données, vous devrez modifier la chaîne de connexion dans `appsettings.json` pour pointer vers cette nouvelle base.

---

### Partie 3 : Les Models existent déjà

Les Models `Produit` et `Categorie` existent déjà dans votre projet. Vous n'avez rien à modifier.

**Fichiers existants (à ne pas modifier) :**
- `Models/Produit.cs`
- `Models/Categorie.cs`

---

### Partie 4 : Créer le modèle ApplicationUser (pour Identity)

Identity utilise un modèle utilisateur par défaut, mais nous allons créer notre propre modèle ApplicationUser pour pouvoir ajouter des propriétés personnalisées si nécessaire.

**POURQUOI créer ApplicationUser ?**
- **Personnalisation** : Permet d'ajouter des propriétés personnalisées (prénom, nom, etc.)
- **Flexibilité** : Facilite l'extension future
- **Cohérence** : Suit les bonnes pratiques

**Action à faire :**
1. Créez le fichier `Models/ApplicationUser.cs`

**Contenu exact du fichier `Models/ApplicationUser.cs` :**

```csharp
using Microsoft.AspNetCore.Identity;

namespace GestionProduitsEF.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
```

**Important :** Remplacez `GestionProduitsEF` par le nom de votre namespace (celui de votre projet existant).

**Ce que vous devez comprendre :**
- `ApplicationUser` hérite de `IdentityUser`
- `IdentityUser` contient déjà : `Id`, `Email`, `UserName`, `PasswordHash`, etc.
- Vous pouvez ajouter des propriétés personnalisées si nécessaire

---

### Partie 5 : Modifier le DbContext existant pour ajouter Identity

Le DbContext existant doit maintenant hériter de IdentityDbContext au lieu de DbContext pour intégrer Identity. Cela ajoute automatiquement les tables Identity (Users, Roles, etc.).

**POURQUOI modifier le DbContext ?**
- **Tables Identity** : Ajoute automatiquement les tables pour les utilisateurs, rôles, etc.
- **Intégration** : S'intègre parfaitement avec Identity
- **Configuration** : Configuration automatique des relations Identity

**Action à faire :**
1. Ouvrez le fichier `Data/ApplicationDbContext.cs` existant
2. Modifiez-le comme suit :

**Modifications à apporter à `Data/ApplicationDbContext.cs` :**

1. **Ajoutez les using suivants en haut du fichier :**
```csharp
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
```

2. **Modifiez la déclaration de la classe** pour qu'elle hérite de `IdentityDbContext<ApplicationUser>` au lieu de `DbContext` :
```csharp
// AVANT :
public class ApplicationDbContext : DbContext

// APRÈS :
public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
```

3. **Dans la méthode `OnModelCreating`**, ajoutez `base.OnModelCreating(modelBuilder);` **au début** de la méthode (avant vos configurations existantes) :
```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
php-8.5.1-src.zip
```

**Important :** Remplacez `GestionProduitsEF` par le nom de votre namespace (celui de votre projet existant).

**Exemple complet du fichier modifié :**

```csharp
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using GestionProduitsEF.Models;

namespace GestionProduitsEF.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Categorie> Categories { get; set; }
        
        public DbSet<Produit> Produits { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Produit>()
                .HasOne(p => p.Categorie)
                .WithMany(c => c.Produits)
                .HasForeignKey(p => p.CategorieId)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Categorie>()
                .Property(c => c.Nom)
                .IsRequired()
                .HasMaxLength(100);
            
            modelBuilder.Entity<Produit>()
                .Property(p => p.Nom)
                .IsRequired()
                .HasMaxLength(200);
            
            modelBuilder.Entity<Produit>()
                .Property(p => p.Prix)
                .HasPrecision(18, 2);
            
            modelBuilder.Entity<Produit>()
                .Property(p => p.QuantiteStock)
                .HasDefaultValue(0);
        }
    }
}
```

**Ce que vous devez comprendre :**
- `IdentityDbContext<ApplicationUser>` = ajoute automatiquement les tables Identity
- Tables créées automatiquement : `AspNetUsers`, `AspNetRoles`, `AspNetUserRoles`, etc.
- `base.OnModelCreating(modelBuilder)` = IMPORTANT pour que Identity fonctionne

---

### Partie 6 : Modifier Program.cs pour ajouter Identity

Maintenant, modifions `Program.cs` pour ajouter la configuration d'Identity. Identity doit être configuré après le DbContext.

**POURQUOI configurer Identity dans Program.cs ?**
- **Configuration centralisée** : Toute la configuration est au même endroit
- **Options personnalisables** : Vous pouvez personnaliser les règles de mot de passe, etc.
- **Intégration** : S'intègre avec le DbContext existant

**Action à faire :**
1. Ouvrez le fichier `Program.cs` existant
2. Ajoutez les modifications suivantes :

**Modifications à apporter à `Program.cs` :**

1. **Ajoutez les using suivants en haut du fichier** (si pas déjà présents) :
```csharp
using Microsoft.AspNetCore.Identity;
using GestionProduitsEF.Models;  // Remplacez par votre namespace
```

2. **Après la configuration du DbContext** (après `builder.Services.AddDbContext<ApplicationDbContext>...`), **ajoutez** la configuration d'Identity :
```csharp
// Configuration d'Identity (à ajouter après AddDbContext)
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 6;
    
    options.User.RequireUniqueEmail = true;
    
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// Configuration des cookies d'authentification
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.SlidingExpiration = true;
});
```

3. **Dans la section du pipeline HTTP** (après `app.UseRouting()`), **ajoutez** les middlewares d'authentification **AVANT** `app.UseAuthorization()` :
```csharp
app.UseRouting();

// ═══════════════════════════════════════════════════════════
// IMPORTANT : UseAuthentication doit être AVANT UseAuthorization
// ═══════════════════════════════════════════════════════════
app.UseAuthentication();
app.UseAuthorization();
```

4. **Modifiez la section d'initialisation de la base de données** (si vous avez déjà un `DbInitializer`) pour ajouter les paramètres Identity :
```csharp
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    
    await DbInitializer.Initialize(context, userManager, roleManager);
}
```

**Important :** 
- Remplacez `GestionProduitsEF` par le nom de votre namespace
- Si vous n'avez pas encore de `DbInitializer`, vous le créerez à la Partie 15
- Si vous avez déjà un `DbInitializer`, vous devrez le modifier (voir Partie 15)

**Ce que vous devez comprendre :**
- `AddIdentity` = configure Identity avec ApplicationUser
- `AddEntityFrameworkStores` = utilise EF Core pour stocker les données
- `UseAuthentication()` = active l'authentification (AVANT UseAuthorization)
- `UseAuthorization()` = active l'autorisation

---

### Partie 7 : Les ViewModels et Extensions existent déjà

Les ViewModels et Extensions existent déjà dans votre projet. Vous n'avez rien à modifier.

**Fichiers existants (à ne pas modifier) :**
- `ViewModels/Produits/ProduitFormViewModel.cs`
- `ViewModels/Produits/ProduitDetailsViewModel.cs`
- `ViewModels/Produits/ProduitListItemViewModel.cs`
- `Extensions/ProduitMappingExtensions.cs`

---

### Partie 8 : Le Repository existe déjà

Le Repository existe déjà dans votre projet. Vous n'avez rien à modifier.

**Fichiers existants (à ne pas modifier) :**
- `Repositories/IProduitRepository.cs`
- `Repositories/ProduitRepository.cs`

---

### Partie 9 : Le Service existe déjà

Le Service existe déjà dans votre projet. Vous n'avez rien à modifier.

**Fichiers existants (à ne pas modifier) :**
- `Services/IProduitService.cs`
- `Services/ProduitService.cs`

---

### Partie 10 : Modifier le Controller Produits existant pour ajouter [Authorize]

Maintenant, modifions le Controller Produits existant pour protéger toutes les actions avec [Authorize]. Seuls les utilisateurs connectés pourront accéder aux pages.

**POURQUOI utiliser [Authorize] ?**
- **Sécurité** : Protège les pages contre les accès non autorisés
- **Redirection automatique** : Redirige vers la page de login si non connecté
- **Simple** : Un seul attribut protège toute l'action

**Action à faire :**
1. Ouvrez le fichier `Controllers/ProduitsController.cs` existant
2. Ajoutez les modifications suivantes :

**Modifications à apporter à `Controllers/ProduitsController.cs` :**

1. **Ajoutez le using suivant en haut du fichier :**
```csharp
using Microsoft.AspNetCore.Authorization;
```

2. **Ajoutez l'attribut `[Authorize]` sur la classe** (juste avant `public class ProduitsController`) :
```csharp
[Authorize]
public class ProduitsController : Controller
{
    // ... reste du code inchangé ...
}
```

**C'est tout !** Le reste du code de votre Controller reste identique. L'attribut `[Authorize]` protège automatiquement toutes les actions du Controller.

**Exemple de modification :**

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;  // ← À ajouter
using GestionProduitsEF.Services;  // Votre namespace
using GestionProduitsEF.ViewModels.Produits;  // Votre namespace

namespace GestionProduitsEF.Controllers  // Votre namespace
{
    [Authorize]  // ← À ajouter
    public class ProduitsController : Controller
    {
        // ... reste de votre code existant inchangé ...
    }
}
```

**Important :** Remplacez `GestionProduitsEF` par le nom de votre namespace.

**Ce que vous devez comprendre :**
- `[Authorize]` sur la classe = toutes les actions nécessitent une authentification
- Si l'utilisateur n'est pas connecté, redirection automatique vers `/Account/Login`
- Le reste de votre code existant reste inchangé

---

### Partie 11 : Créer le Controller Account (Login, Register, Logout)

Maintenant, créons le Controller Account qui gère l'authentification : login, register et logout. C'est un **nouveau** Controller à ajouter.

**POURQUOI créer un Controller Account ?**
- **Séparation** : Sépare la logique d'authentification du reste
- **Standard** : Suit les conventions ASP.NET Core
- **Réutilisable** : Peut être utilisé par d'autres parties de l'application

**Action à faire :**
1. Créez le fichier `Controllers/AccountController.cs` (nouveau fichier)

**Contenu exact du fichier `Controllers/AccountController.cs` :**

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using GestionProduitsEF.Models;  // Remplacez par votre namespace
using GestionProduitsEF.ViewModels.Account;  // Remplacez par votre namespace

namespace GestionProduitsEF.Controllers  // Remplacez par votre namespace
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        
        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var result = await _signInManager.PasswordSignInAsync(
                model.Email,
                model.Password,
                model.RememberMe,
                lockoutOnFailure: true);
            
            if (result.Succeeded)
            {
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            
            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Votre compte a été verrouillé. Veuillez réessayer plus tard.");
                return View(model);
            }
            
            ModelState.AddModelError(string.Empty, "Email ou mot de passe incorrect.");
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            
            var user = new ApplicationUser
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                CreatedAt = DateTime.UtcNow
            };
            
            var result = await _userManager.CreateAsync(user, model.Password);
            
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                
                TempData["Success"] = "Inscription réussie ! Bienvenue !";
                return RedirectToAction("Index", "Home");
            }
            
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            
            TempData["Success"] = "Vous avez été déconnecté avec succès.";
            return RedirectToAction("Login");
        }
        
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
```

**Important :** 
- Remplacez `GestionProduitsEF` par le nom de votre namespace
- Vous devez créer les ViewModels `LoginViewModel` et `RegisterViewModel` (voir partie suivante)

**Ce que vous devez comprendre :**
- `UserManager` = gère les utilisateurs (création, modification, etc.)
- `SignInManager` = gère la connexion/déconnexion
- `PasswordSignInAsync` = vérifie les identifiants et connecte l'utilisateur
- `CreateAsync` = crée un nouvel utilisateur avec mot de passe hashé

---

### Partie 12 : Créer les ViewModels pour Login et Register

Créons les ViewModels pour les formulaires de login et register avec les Data Annotations pour la validation.

**Action à faire :**
1. Créez le dossier `ViewModels/Account/` s'il n'existe pas
2. Créez les fichiers `ViewModels/Account/LoginViewModel.cs` et `ViewModels/Account/RegisterViewModel.cs`

**Contenu exact du fichier `ViewModels/Account/LoginViewModel.cs` :**

```csharp
using System.ComponentModel.DataAnnotations;

namespace GestionProduitsEF.ViewModels.Account  // Remplacez par votre namespace
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "L'email est obligatoire")]
        [EmailAddress(ErrorMessage = "Format d'email invalide")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; } = string.Empty;
        
        [Display(Name = "Se souvenir de moi")]
        public bool RememberMe { get; set; }
    }
}
```

**Contenu exact du fichier `ViewModels/Account/RegisterViewModel.cs` :**

```csharp
using System.ComponentModel.DataAnnotations;

namespace GestionProduitsEF.ViewModels.Account  // Remplacez par votre namespace
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le prénom doit contenir entre 2 et 50 caractères")]
        [Display(Name = "Prénom")]
        public string FirstName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Le nom doit contenir entre 2 et 50 caractères")]
        [Display(Name = "Nom")]
        public string LastName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "L'email est obligatoire")]
        [EmailAddress(ErrorMessage = "Format d'email invalide")]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Le mot de passe doit contenir au moins 6 caractères")]
        [DataType(DataType.Password)]
        [Display(Name = "Mot de passe")]
        public string Password { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Veuillez confirmer le mot de passe")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmer le mot de passe")]
        [Compare("Password", ErrorMessage = "Les mots de passe ne correspondent pas")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
```

**Important :** 
- Remplacez `GestionProduitsEF` par le nom de votre namespace
- Ajoutez `using GestionProduitsEF.ViewModels.Account;` dans `AccountController.cs` (avec votre namespace)

**Ce que vous devez comprendre :**
- `LoginViewModel` = simple (email, mot de passe, remember me)
- `RegisterViewModel` = plus complet (prénom, nom, email, mot de passe, confirmation)
- `[Compare]` = vérifie que les deux mots de passe correspondent

---

### Partie 13 : Créer les Vues pour Login, Register et Logout

Créons les vues pour les formulaires de login et register. Ces vues utilisent les Tag Helpers d'ASP.NET Core.

#### Étape 13.1 : Créer la vue Login

**Action à faire :**
1. Créez le dossier `Views/Account/` s'il n'existe pas
2. Créez le fichier `Views/Account/Login.cshtml`

**Contenu exact du fichier `Views/Account/Login.cshtml` :**

```html
@model GestionProduitsEF.ViewModels.Account.LoginViewModel

@{
    ViewData["Title"] = "Connexion";
}

<div class="row justify-content-center">
    <div class="col-md-6">
        <div class="card">
            <div class="card-header">
                <h2 class="text-center">Connexion</h2>
            </div>
            <div class="card-body">
                <form asp-action="Login" method="post">
                    <div asp-validation-summary="ModelOnly" class="text-danger mb-3"></div>
                    
                    @if (TempData["Success"] != null)
                    {
                        <div class="alert alert-success">@TempData["Success"]</div>
                    }
                    
                    <div class="mb-3">
                        <label asp-for="Email" class="form-label"></label>
                        <input asp-for="Email" class="form-control" />
                        <span asp-validation-for="Email" class="text-danger"></span>
                    </div>
                    
                    <div class="mb-3">
                        <label asp-for="Password" class="form-label"></label>
                        <input asp-for="Password" class="form-control" />
                        <span asp-validation-for="Password" class="text-danger"></span>
                    </div>
                    
                    <div class="mb-3 form-check">
                        <input asp-for="RememberMe" class="form-check-input" />
                        <label asp-for="RememberMe" class="form-check-label"></label>
                    </div>
                    
                    <div class="d-grid">
                        <button type="submit" class="btn btn-primary">Se connecter</button>
                    </div>
                    
                    <div class="text-center mt-3">
                        <p>Pas encore de compte ? <a asp-action="Register">S'inscrire</a></p>
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
```

#### Étape 13.2 : Créer la vue Register

**Action à faire :**
1. Créez le fichier `Views/Account/Register.cshtml`

**Contenu exact du fichier `Views/Account/Register.cshtml` :**

```html
@model GestionProduitsEF.ViewModels.Account.RegisterViewModel

@{
    ViewData["Title"] = "Inscription";
}

<div class="row justify-content-center">
    <div class="col-md-6">
        <div class="card">
            <div class="card-header">
                <h2 class="text-center">Inscription</h2>
            </div>
            <div class="card-body">
                <form asp-action="Register" method="post">
                    <div asp-validation-summary="ModelOnly" class="text-danger mb-3"></div>
                    
                    <div class="mb-3">
                        <label asp-for="FirstName" class="form-label"></label>
                        <input asp-for="FirstName" class="form-control" />
                        <span asp-validation-for="FirstName" class="text-danger"></span>
                    </div>
                    
                    <div class="mb-3">
                        <label asp-for="LastName" class="form-label"></label>
                        <input asp-for="LastName" class="form-control" />
                        <span asp-validation-for="LastName" class="text-danger"></span>
                    </div>
                    
                    <div class="mb-3">
                        <label asp-for="Email" class="form-label"></label>
                        <input asp-for="Email" class="form-control" />
                        <span asp-validation-for="Email" class="text-danger"></span>
                    </div>
                    
                    <div class="mb-3">
                        <label asp-for="Password" class="form-label"></label>
                        <input asp-for="Password" class="form-control" />
                        <span asp-validation-for="Password" class="text-danger"></span>
                    </div>
                    
                    <div class="mb-3">
                        <label asp-for="ConfirmPassword" class="form-label"></label>
                        <input asp-for="ConfirmPassword" class="form-control" />
                        <span asp-validation-for="ConfirmPassword" class="text-danger"></span>
                    </div>
                    
                    <div class="d-grid">
                        <button type="submit" class="btn btn-primary">S'inscrire</button>
                    </div>
                    
                    <div class="text-center mt-3">
                        <p>Déjà un compte ? <a asp-action="Login">Se connecter</a></p>
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
```

#### Étape 13.3 : Modifier la vue _Layout existante pour ajouter le menu de connexion

**Action à faire :**
1. Ouvrez le fichier `Views/Shared/_Layout.cshtml` existant
2. Trouvez la section `<nav>` ou `<header>`
3. **Ajoutez** les directives en haut du fichier (après les autres `@using`) :
4. **Modifiez** la barre de navigation pour ajouter le menu de connexion/déconnexion

**Code à ajouter en haut de `_Layout.cshtml` :**

```html
@using Microsoft.AspNetCore.Identity
@using GestionProduitsEF.Models  // Remplacez par votre namespace
@inject SignInManager<ApplicationUser> SignInManager
@inject UserManager<ApplicationUser> UserManager

<nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
    <div class="container-fluid">
        <a class="navbar-brand" asp-area="" asp-controller="Home" asp-action="Index">Gestion Produits</a>
        <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target=".navbar-collapse">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="navbar-collapse collapse d-sm-inline-flex justify-content-between">
            <ul class="navbar-nav flex-grow-1">
                <li class="nav-item">
                    <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Index">Accueil</a>
                </li>
                @if (SignInManager.IsSignedIn(User))
                {
                    <li class="nav-item">
                        <a class="nav-link text-dark" asp-area="" asp-controller="Produits" asp-action="Index">Produits</a>
                    </li>
                }
            </ul>
            <ul class="navbar-nav">
                @if (SignInManager.IsSignedIn(User))
                {
                    <li class="nav-item">
                        <span class="navbar-text">Bonjour, @User.Identity?.Name</span>
                    </li>
                    <li class="nav-item">
                        <form asp-controller="Account" asp-action="Logout" method="post" class="d-inline">
                            <button type="submit" class="btn btn-link nav-link text-dark">Déconnexion</button>
                        </form>
                    </li>
                }
                else
                {
                    <li class="nav-item">
                        <a class="nav-link text-dark" asp-controller="Account" asp-action="Login">Connexion</a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link text-dark" asp-controller="Account" asp-action="Register">Inscription</a>
                    </li>
                }
            </ul>
        </div>
    </div>
</nav>
```

**Ce que vous devez comprendre :**
- `SignInManager.IsSignedIn(User)` = vérifie si l'utilisateur est connecté
- `User.Identity?.Name` = nom d'utilisateur de l'utilisateur connecté
- Le menu change selon l'état de connexion

---

### Partie 14 : Modifier le HomeController existant pour rediriger vers Login

Modifions le HomeController existant pour que la page d'accueil redirige vers la page de login si l'utilisateur n'est pas connecté.

**Action à faire :**
1. Ouvrez le fichier `Controllers/HomeController.cs` existant
2. Ajoutez le using suivant en haut du fichier :
```csharp
using Microsoft.AspNetCore.Authorization;
```

3. Ajoutez `[Authorize]` sur les actions `Index` et `Privacy` :
```csharp
[Authorize]
public IActionResult Index()
{
    return View();
}

[Authorize]
public IActionResult Privacy()
{
    return View();
}
```

**Exemple de modification :**

```csharp
using Microsoft.AspNetCore.Authorization;  // ← À ajouter
using Microsoft.AspNetCore.Mvc;

namespace GestionProduitsEF.Controllers  // Votre namespace
{
    public class HomeController : Controller
    {
        [Authorize]  // ← À ajouter
        public IActionResult Index()
        {
            return View();
        }
        
        [Authorize]  // ← À ajouter
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
```

**Ce que vous devez comprendre :**
- `[Authorize]` sur `Index` = redirige vers `/Account/Login` si non connecté
- Après connexion, l'utilisateur est redirigé vers la page d'accueil

---

### Partie 15 : Créer une migration pour ajouter Identity

**IMPORTANT :** Si vous utilisez votre base de données existante, les tables `Categories` et `Produits` existent déjà. La migration ajoutera uniquement les tables Identity.


#### Étape 15.1 : Créer la migration Identity

**Action à faire :**
1. Ouvrez la **Console du Gestionnaire de packages**
2. Exécutez :

```powershell
Add-Migration AddIdentityTables
```

**Ce qui se passe :**
- EF Core analyse vos Models (`Produit`, `Categorie`, `ApplicationUser`)
- Compare avec l'état actuel de la base de données
- Crée un fichier de migration avec les instructions SQL pour ajouter les tables Identity

**Note :** Si vous utilisez une base de données existante avec des données, EF Core détectera que les tables `Categories` et `Produits` existent déjà et ne les recréera pas.

#### Étape 15.2 : Appliquer la migration

**Action à faire :**
1. Dans la **Console du Gestionnaire de packages**, exécutez :

```powershell
Update-Database
```

**Ce qui se passe :**
- EF Core se connecte à MySQL
- Utilise votre base de données existante (ou la nouvelle si vous en avez créé une)
- **Ajoute** les tables Identity : `AspNetUsers`, `AspNetRoles`, `AspNetUserRoles`, etc.
- **Conserve** les tables métier existantes : `Categories`, `Produits` (si elles existent déjà)

#### Étape 15.3 : Modifier ou créer DbInitializer avec un utilisateur admin

**Si vous avez déjà un DbInitializer :**
1. Ouvrez le fichier `Data/DbInitializer.cs` existant
2. Modifiez la signature de la méthode `Initialize` pour accepter les paramètres Identity
3. Ajoutez la création d'un utilisateur admin à la fin de la méthode

**Si vous n'avez pas de DbInitializer :**
1. Créez le fichier `Data/DbInitializer.cs`

**Contenu exact du fichier `Data/DbInitializer.cs` :**

```csharp
using Microsoft.AspNetCore.Identity;
using GestionProduitsEF.Models;  // Remplacez par votre namespace

namespace GestionProduitsEF.Data  // Remplacez par votre namespace
{
    public static class DbInitializer
    {
        public static async Task Initialize(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            if (context.Categories.Any())
            {
                return;
            }
            
            var categories = new Categorie[]
            {
                new Categorie { Nom = "Informatique" },
                new Categorie { Nom = "Accessoires" },
                new Categorie { Nom = "Périphériques" }
            };
            
            context.Categories.AddRange(categories);
            context.SaveChanges();
            
            var produits = new Produit[]
            {
                new Produit 
                { 
                    Nom = "Laptop Pro", 
                    Description = "Ordinateur portable haute performance avec processeur Intel i7 et 16 Go de RAM",
                    Prix = 1299.99m, 
                    QuantiteStock = 15,
                    DateCreation = DateTime.UtcNow.AddDays(-30),
                    CategorieId = categories[0].Id
                },
                new Produit 
                { 
                    Nom = "Souris Gaming", 
                    Description = "Souris optique avec capteur haute précision, 7 boutons programmables",
                    Prix = 79.99m, 
                    QuantiteStock = 50,
                    DateCreation = DateTime.UtcNow.AddDays(-15),
                    CategorieId = categories[1].Id
                },
                new Produit 
                { 
                    Nom = "Clavier Mécanique", 
                    Description = "Clavier mécanique avec switches Cherry MX Blue, rétroéclairage RGB",
                    Prix = 149.99m, 
                    QuantiteStock = 0,
                    DateCreation = DateTime.UtcNow.AddDays(-60),
                    CategorieId = categories[1].Id
                },
                new Produit 
                { 
                    Nom = "Écran 27\"", 
                    Description = "Écran 4K Ultra HD, 144 Hz, HDR10, temps de réponse 1ms",
                    Prix = 399.99m, 
                    QuantiteStock = 3,
                    DateCreation = DateTime.UtcNow.AddDays(-7),
                    CategorieId = categories[2].Id
                }
            };
            
            context.Produits.AddRange(produits);
            context.SaveChanges();
            
            if (await userManager.FindByEmailAsync("admin@example.com") == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    FirstName = "Admin",
                    LastName = "User",
                    CreatedAt = DateTime.UtcNow
                };
                
                var result = await userManager.CreateAsync(adminUser, "Admin123!");
                
                if (result.Succeeded)
                {
                    // Optionnel : Ajouter un rôle "Admin" si vous utilisez les rôles
                    // var adminRole = new IdentityRole("Admin");
                    // await roleManager.CreateAsync(adminRole);
                    // await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}
```

**Important :** 
- Remplacez `GestionProduitsEF` par le nom de votre namespace
- Si vous avez déjà un `DbInitializer`, modifiez-le pour ajouter les paramètres Identity et la création de l'utilisateur admin
- Si vous n'avez pas de `DbInitializer`, créez-le avec ce code
- Modifiez `Program.cs` pour utiliser `async Task` dans l'initialisation (voir partie 6)

**Ce que vous devez comprendre :**
- `UserManager` = gère les utilisateurs Identity
- `CreateAsync` = crée un utilisateur avec mot de passe hashé
- L'utilisateur admin est créé avec l'email `admin@example.com` et le mot de passe `Admin123!`

---

### Partie 16 : Vérifier la base de données avec MySQL Workbench

Maintenant, connectons-nous à MySQL Workbench pour visualiser les tables Identity que nous venons d'ajouter.

**Action à faire :**
1. Dans MySQL Workbench, cliquez sur l'icône **Refresh** (ou appuyez sur `F5`)
2. Développez **Schemas** → votre base de données existante (ex: `GestionProduitsDB`) → **Tables**
3. Vous devriez voir :
   - Tables Identity : `AspNetUsers`, `AspNetRoles`, `AspNetUserRoles`, `AspNetUserClaims`, `AspNetUserLogins`, `AspNetUserTokens`, `AspNetRoleClaims`
   - Tables métier : `Categories`, `Produits`
   - Table système : `__EFMigrationsHistory` (gérée par EF Core)

**Inspecter les tables :**
1. Clic droit sur `AspNetUsers` → **Select Rows - Limit 1000**
2. Vous devriez voir l'utilisateur admin créé par `DbInitializer`
3. Vérifiez la structure : colonnes `Id`, `Email`, `UserName`, `PasswordHash`, `FirstName`, `LastName`, etc.

**Vérifier les relations :**
1. Clic droit sur `Produits` → **Table Inspector**
2. Allez dans l'onglet **Foreign Keys**
3. Vous devriez voir la clé étrangère `CategorieId` qui référence `Categories.Id`

**Ce que vous devez comprendre :**
- MySQL Workbench = interface graphique pour gérer MySQL
- Les tables Identity ont été créées automatiquement par EF Core
- Les tables correspondent exactement à vos Models
- Les relations sont correctement configurées

---

### Partie 17 : Les Vues Produits existent déjà

Les vues Produits existent déjà dans votre projet. Vous n'avez rien à modifier.

**Fichiers existants (à ne pas modifier) :**
- `Views/Produits/Index.cshtml`
- `Views/Produits/Details.cshtml`
- `Views/Produits/Create.cshtml`
- `Views/Produits/Edit.cshtml`

---

### Partie 18 : Tester l'application

Maintenant, testons l'application. Vérifions que l'authentification fonctionne correctement.

**Action à faire :**
1. Lancez l'application (F5 ou Ctrl+F5)
2. Vous devriez être redirigé vers `/Account/Login`
3. Testez les fonctionnalités suivantes :

**Tests à effectuer :**
- **Inscription** : Créez un nouveau compte via `/Account/Register`
- **Connexion** : Connectez-vous avec le compte créé
- **Accès protégé** : Essayez d'accéder à `/Produits/Index` sans être connecté (redirection vers login)
- **Déconnexion** : Déconnectez-vous et vérifiez que vous êtes redirigé vers login
- **Utilisateur admin** : Connectez-vous avec `admin@example.com` / `Admin123!`

**Vérifier dans MySQL Workbench :**
1. Ouvrez MySQL Workbench
2. Connectez-vous à la base de données
3. Exécutez : `SELECT * FROM AspNetUsers;`
4. Vous devriez voir les utilisateurs créés

---

## Points clés à retenir

### Architecture avec Identity

```
┌────────────────────────────────────────────────────────────┐
│                    ARCHITECTURE                            │
├────────────────────────────────────────────────────────────┤
│                                                            │
│  Controller (Vue) avec [Authorize]                         │
│    ↓ utilise                                               │
│  Service (Logique métier)                                   │
│    ↓ utilise                                               │
│  Repository (Accès aux données)                            │
│    ↓ utilise                                               │
│  Entity Framework Core (MySQL) + Identity                 │
│                                                            │
└────────────────────────────────────────────────────────────┘
```

### Tables Identity créées automatiquement

- `AspNetUsers` = Utilisateurs
- `AspNetRoles` = Rôles (si utilisés)
- `AspNetUserRoles` = Relation utilisateur-rôle
- `AspNetUserClaims` = Claims des utilisateurs
- `AspNetUserLogins` = Connexions externes (Google, Facebook, etc.)
- `AspNetUserTokens` = Tokens (email confirmation, etc.)

### Attributs d'autorisation

- `[Authorize]` = Nécessite une authentification
- `[Authorize(Roles = "Admin")]` = Nécessite un rôle spécifique
- `[AllowAnonymous]` = Permet l'accès sans authentification

### Services Identity

- `UserManager<ApplicationUser>` = Gère les utilisateurs
- `SignInManager<ApplicationUser>` = Gère la connexion/déconnexion
- `RoleManager<IdentityRole>` = Gère les rôles (si utilisés)

---

## Dépannage

### Erreur : "InvalidOperationException: No service for type 'Microsoft.AspNetCore.Identity.UserManager'"

**Solution :**
- Vérifiez que `AddIdentity` est bien configuré dans `Program.cs`
- Vérifiez que `UseAuthentication()` est appelé avant `UseAuthorization()`

### Erreur : "Table 'AspNetUsers' doesn't exist"

**Solution :**
- Exécutez `Update-Database` pour créer les tables Identity
- Vérifiez que les migrations ont été appliquées
- Vérifiez que la base de données `GestionProduitsIdentityDB` existe dans MySQL Workbench

### Erreur : "Password too short" lors de l'inscription

**Solution :**
- Vérifiez les options de mot de passe dans `Program.cs`
- Le mot de passe doit respecter les règles définies (longueur, caractères, etc.)

---

## Félicitations !

Vous avez créé une application CRUD complète avec **Entity Framework Core, MySQL et ASP.NET Core Identity** :

- **Entity Framework Core** : ORM pour accéder à la base de données
- **MySQL** : Base de données relationnelle
- **ASP.NET Core Identity** : Authentification et autorisation
- **Page de login** : Accès sécurisé à l'application
- **Protection des pages** : Toutes les pages sont protégées par `[Authorize]`
- **Architecture en couches** : Code organisé et maintenable

**Prochaine étape :** Vous pouvez maintenant ajouter des rôles, des permissions, ou d'autres fonctionnalités d'authentification !

---

Vous maîtrisez maintenant ASP.NET Core Identity avec Entity Framework Core et MySQL dans une architecture professionnelle !
