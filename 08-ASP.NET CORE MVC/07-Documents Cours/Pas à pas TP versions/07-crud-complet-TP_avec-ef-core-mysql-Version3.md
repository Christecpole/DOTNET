# CRUD Complet avec Entity Framework Core et MySQL

## Objectif

> **Temps estimé : 4h**
> 
> Créer une **application CRUD complète** de gestion de produits en utilisant :
> - **Entity Framework Core** pour l'accès aux données
> - **MySQL** comme base de données
> - **MySQL Workbench** pour visualiser et gérer la base de données
> - La même **architecture en couches** (Repository Pattern + Service Layer)
> - **Migrations** pour créer et mettre à jour la base de données

---

## Introduction Théorique

### QUOI : Qu'allons-nous construire ?

Vous allez créer la **même application CRUD** que l'exercice précédent, mais cette fois avec une **vraie base de données MySQL** au lieu de listes en mémoire.

**Architecture (identique à l'exercice précédent) :**
```
Controller (Vue)
    ↓ utilise
Service (Logique métier)
    ↓ utilise
Repository (Accès aux données)
    ↓ utilise
Entity Framework Core (MySQL)
```

**Différence avec l'exercice précédent :**
- **Exercice précédent** : `DbFake` (listes en mémoire)
- **Cet exercice** : **Entity Framework Core** + **MySQL** (vraie base de données)

### POURQUOI utiliser Entity Framework Core ?

**Avantages d'EF Core :**
- **ORM (Object-Relational Mapping)** : Transforme automatiquement les objets C# en requêtes SQL
- **Code-First** : Créez vos Models en C#, EF Core crée la base de données
- **Migrations** : Gestion automatique des changements de schéma
- **LINQ** : Requêtes en C# au lieu de SQL brut
- **Type-safe** : Erreurs détectées à la compilation, pas à l'exécution

**Avantages de MySQL :**
- **Gratuit et open-source**
- **Très performant**
- **Utilisé par de nombreuses entreprises**
- **MySQL Workbench** : Interface graphique pour gérer la base de données

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

---

### Partie 1 : Créer le projet et installer les packages NuGet

#### Étape 1.1 : Créer un nouveau projet ASP.NET Core MVC

**Action à faire :**
1. Ouvrez Visual Studio
2. Créez un nouveau projet : **ASP.NET Core Web App (Model-View-Controller)**
3. Nommez-le : `GestionProduitsEF`
4. Choisissez **.NET 8.0** (ou version supérieure)
5. Cliquez sur **Créer**

#### Étape 1.2 : Installer les packages NuGet nécessaires

**Action à faire :**
1. Clic droit sur le projet → **Gérer les packages NuGet**
2. Onglet **Parcourir**
3. Installez les packages suivants :

**Package 1 : Entity Framework Core**
- Nom : `Microsoft.EntityFrameworkCore`
- Version : Dernière version stable (ex: 8.0.x)

**Package 2 : EF Core pour MySQL**
- Nom : `Pomelo.EntityFrameworkCore.MySql`
- Version : Dernière version stable (ex: 8.0.x)
- **Important** : Utilisez `Pomelo.EntityFrameworkCore.MySql` (pas `MySql.EntityFrameworkCore` qui est obsolète)

**Package 3 : Outils EF Core (pour les migrations)**
- Nom : `Microsoft.EntityFrameworkCore.Tools`
- Version : Dernière version stable (ex: 8.0.x)

**Méthode alternative (via Package Manager Console) :**
```powershell
Install-Package Microsoft.EntityFrameworkCore
Install-Package Pomelo.EntityFrameworkCore.MySql
Install-Package Microsoft.EntityFrameworkCore.Tools
```

**Méthode alternative (via CLI .NET) :**
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Pomelo.EntityFrameworkCore.MySql
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

**Ce que vous devez comprendre :**
- `Microsoft.EntityFrameworkCore` = Framework ORM de base
- `Pomelo.EntityFrameworkCore.MySql` = Provider MySQL pour EF Core
- `Microsoft.EntityFrameworkCore.Tools` = Outils pour créer les migrations

---

### Partie 2 : Créer la base de données dans MySQL Workbench

Avant de configurer Entity Framework Core, nous allons créer la base de données dans MySQL Workbench.

**POURQUOI créer la base de données maintenant ?**
- **Visualisation** : Vous pouvez voir la base de données se remplir au fur et à mesure
- **Compréhension** : Vous comprenez mieux le processus
- **Dépannage** : Plus facile de vérifier si tout fonctionne

#### Étape 2.1 : Se connecter à MySQL Workbench

**Action à faire :**
1. Ouvrez **MySQL Workbench**
2. Créez une nouvelle connexion (ou utilisez la connexion par défaut) :
   - **Hostname** : `localhost`
   - **Port** : `3306`
   - **Username** : `root`
   - **Password** : Votre mot de passe MySQL
3. Cliquez sur **Test Connection** pour vérifier
4. Cliquez sur **OK** puis double-cliquez sur la connexion pour vous connecter

#### Étape 2.2 : Créer la base de données

**Action à faire :**
1. Dans MySQL Workbench, vous verrez un onglet avec une zone de requête SQL
2. Exécutez la commande suivante pour créer la base de données :

```sql
CREATE DATABASE IF NOT EXISTS GestionProduitsDB 
CHARACTER SET utf8mb4 
COLLATE utf8mb4_unicode_ci;
```

**Explication :**
- `CREATE DATABASE` = crée une nouvelle base de données
- `IF NOT EXISTS` = ne crée la base que si elle n'existe pas déjà
- `GestionProduitsDB` = nom de la base de données
- `CHARACTER SET utf8mb4` = encodage UTF-8 (supporte les emojis et caractères spéciaux)
- `COLLATE utf8mb4_unicode_ci` = règles de comparaison de chaînes

3. Cliquez sur l'icône **⚡ Execute** (ou appuyez sur `Ctrl+Enter`) pour exécuter la requête
4. Vous devriez voir un message de succès : "1 row(s) affected"

#### Étape 2.3 : Vérifier que la base de données a été créée

**Action à faire :**
1. Dans le panneau de gauche, cliquez sur l'icône **Refresh** (ou appuyez sur `F5`)
2. Développez **Schemas**
3. Vous devriez voir la base de données `GestionProduitsDB` apparaître
4. La base de données est vide pour l'instant (pas encore de tables)

**Ce que vous devez comprendre :**
- La base de données est créée mais vide
- Les tables seront créées automatiquement par Entity Framework Core via les migrations
- Vous pouvez maintenant configurer la connexion dans votre application

---

### Partie 3 : Créer les Models (identique à l'exercice précédent)

Les Models restent identiques. Si vous avez déjà fait l'exercice précédent, vous pouvez réutiliser les mêmes fichiers.

**Fichiers à créer :**
- `Models/Produit.cs`
- `Models/Categorie.cs`

**Code de `Models/Categorie.cs` :**

```csharp
namespace GestionProduitsEF.Models
{
    public class Categorie
    {
        public int Id { get; set; }
        
        public string Nom { get; set; } = string.Empty;
        
        public virtual ICollection<Produit> Produits { get; set; } = new List<Produit>();
    }
}
```

**Code de `Models/Produit.cs` :**

```csharp
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionProduitsEF.Models
{
    public class Produit
    {
        public int Id { get; set; }
        
        public string Nom { get; set; } = string.Empty;
        
        public string? Description { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Prix { get; set; }
        
        public int QuantiteStock { get; set; }
        
        public DateTime DateCreation { get; set; } = DateTime.UtcNow;
        
        public int CategorieId { get; set; }
        
        public virtual Categorie? Categorie { get; set; }
    }
}
```

**Important :** Ajoutez `using System.ComponentModel.DataAnnotations.Schema;` en haut du fichier `Produit.cs` pour l'attribut `[Column]`.

**Ce que vous devez comprendre :**
- Les Models sont identiques à l'exercice précédent
- `virtual` sur les propriétés de navigation = permet le lazy loading (optionnel mais recommandé)
- `ICollection<T>` = collection générique (plus flexible que `List<T>`)

---

### Partie 4 : Créer le DbContext

Le DbContext est le point d'entrée principal d'Entity Framework Core. Il représente une session avec la base de données et permet d'interroger et de sauvegarder les données.

**POURQUOI créer un DbContext ?**
- **Point d'entrée** : Toutes les opérations EF Core passent par le DbContext
- **Configuration** : Définit quels Models sont mappés à quelles tables
- **Requêtes** : Permet d'interroger la base de données avec LINQ
- **Sauvegarde** : Permet de sauvegarder les modifications

**Action à faire :**
1. Créez le dossier `Data/` s'il n'existe pas
2. Créez le fichier `Data/ApplicationDbContext.cs`

**Contenu exact du fichier `Data/ApplicationDbContext.cs` :**

```csharp
using Microsoft.EntityFrameworkCore;
using GestionProduitsEF.Models;

namespace GestionProduitsEF.Data
{
    public class ApplicationDbContext : DbContext
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
- `DbContext` = point d'entrée principal d'EF Core
- `DbSet<T>` = représente une table en base de données
- `OnModelCreating` = configure les relations et contraintes
- `DeleteBehavior.Restrict` = empêche la suppression si des produits existent

---

### Partie 5 : Configurer la connexion MySQL dans Program.cs

Maintenant, configurons la connexion à MySQL. La chaîne de connexion contient toutes les informations nécessaires pour se connecter à la base de données.

**POURQUOI configurer la connexion ?**
- **Sécurité** : La chaîne de connexion est stockée dans `appsettings.json` (pas dans le code)
- **Flexibilité** : On peut changer de base de données sans modifier le code
- **Environnements** : Différentes chaînes pour développement, test, production

**Action à faire :**
1. Ouvrez le fichier `appsettings.json`
2. Ajoutez la chaîne de connexion MySQL

**Contenu à ajouter dans `appsettings.json` :**

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=GestionProduitsDB;User=root;Password=VotreMotDePasse;Port=3306;"
  }
}
```

**Important :** Remplacez `VotreMotDePasse` par votre mot de passe MySQL root.

**Format de la chaîne de connexion :**
- `Server=localhost` = serveur MySQL (localhost = votre machine)
- `Database=GestionProduitsDB` = nom de la base de données (celle que nous venons de créer)
- `User=root` = utilisateur MySQL (généralement "root")
- `Password=...` = mot de passe MySQL
- `Port=3306` = port MySQL (3306 par défaut)

**Action à faire :**
1. Ouvrez le fichier `Program.cs`
2. Ajoutez la configuration d'EF Core

**Contenu à ajouter dans `Program.cs` :**

```csharp
using Microsoft.EntityFrameworkCore;
using GestionProduitsEF.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    )
);

// ... reste du code ...
```

**Ce que vous devez comprendre :**
- `AddDbContext` = enregistre le DbContext avec les options
- `UseMySql` = configure EF Core pour utiliser MySQL
- `GetConnectionString` = récupère la chaîne depuis `appsettings.json`
- `ServerVersion.AutoDetect` = détecte automatiquement la version MySQL

---

### Partie 6 : Créer la base de données avec les Migrations

Les Migrations permettent de créer et de mettre à jour la base de données automatiquement à partir de vos Models. C'est le principe Code-First : vous créez les Models en C#, EF Core crée les tables dans la base de données.

**POURQUOI utiliser les Migrations ?**
- **Code-First** : Créez les Models en C#, EF Core crée les tables
- **Versioning** : Chaque migration est un fichier, vous pouvez suivre l'historique
- **Automatique** : EF Core génère le SQL pour vous
- **Réversible** : Vous pouvez annuler une migration

#### Étape 6.1 : Créer la première migration

**Action à faire :**
1. Ouvrez la **Console du Gestionnaire de packages** (Tools → NuGet Package Manager → Package Manager Console)
2. Exécutez la commande suivante :

```powershell
Add-Migration InitialCreate
```

**Explication de la commande :**
- `Add-Migration` = crée une nouvelle migration
- `InitialCreate` = nom de la migration (vous pouvez choisir n'importe quel nom)

**Ce qui se passe :**
- EF Core analyse vos Models (`Produit`, `Categorie`)
- Compare avec l'état actuel de la base de données (vide au début)
- Crée un fichier de migration dans `Migrations/` avec les instructions SQL

**Fichier créé : `Migrations/YYYYMMDDHHMMSS_InitialCreate.cs`**

#### Étape 6.2 : Appliquer la migration (créer les tables)

**Action à faire :**
1. Dans la **Console du Gestionnaire de packages**, exécutez :

```powershell
Update-Database
```

**Explication de la commande :**
- `Update-Database` = applique toutes les migrations en attente
- Crée les tables selon vos Models dans la base de données existante

**Ce qui se passe :**
- EF Core se connecte à MySQL
- Utilise la base de données `GestionProduitsDB` que nous avons créée
- Crée les tables `Categories` et `Produits`
- Crée les relations et contraintes

**Méthode alternative (via CLI .NET) :**
```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

**Ce que vous devez comprendre :**
- `Add-Migration` = crée le fichier de migration
- `Update-Database` = applique la migration (crée les tables)
- Les migrations sont des fichiers C# qui contiennent les instructions SQL

---

### Partie 7 : Vérifier la base de données avec MySQL Workbench

Maintenant, connectons-nous à MySQL Workbench pour visualiser les tables que nous venons de créer.

**Action à faire :**
1. Dans MySQL Workbench, cliquez sur l'icône **Refresh** (ou appuyez sur `F5`)
2. Développez **Schemas** → `GestionProduitsDB` → **Tables**
3. Vous devriez voir :
   - Table `Categories`
   - Table `Produits`
   - Table `__EFMigrationsHistory` (gérée par EF Core pour suivre les migrations)

**Inspecter les tables :**
1. Clic droit sur `Categories` → **Select Rows - Limit 1000**
2. La table est vide pour l'instant (nous ajouterons des données plus tard)
3. Vérifiez la structure : colonnes `Id`, `Nom`

**Inspecter la structure :**
1. Clic droit sur `Categories` → **Table Inspector`
2. Vérifiez que `Id` est la clé primaire et auto-incrémentée
3. Faites de même pour `Produits`

**Vérifier les relations :**
1. Clic droit sur `Produits` → **Table Inspector`
2. Allez dans l'onglet **Foreign Keys**
3. Vous devriez voir la clé étrangère `CategorieId` qui référence `Categories.Id`

**Ce que vous devez comprendre :**
- MySQL Workbench = interface graphique pour gérer MySQL
- Les tables ont été créées automatiquement par EF Core
- Les tables correspondent exactement à vos Models
- Les relations sont correctement configurées

---

### Partie 8 : Créer les ViewModels et Extensions (identique à l'exercice précédent)

Les ViewModels et Extensions restent identiques. Vous pouvez réutiliser les mêmes fichiers.

**Fichiers à créer :**
- `ViewModels/Produits/ProduitFormViewModel.cs`
- `ViewModels/Produits/ProduitDetailsViewModel.cs`
- `ViewModels/Produits/ProduitListItemViewModel.cs`
- `Extensions/ProduitMappingExtensions.cs`

*(Voir l'exercice précédent pour le code exact)*

---

### Partie 9 : Créer le Repository avec Entity Framework Core

Maintenant, créons le Repository qui utilise Entity Framework Core au lieu de DbFake. L'interface reste identique, seule l'implémentation change.

**POURQUOI garder la même interface ?**
- **Flexibilité** : On peut changer d'implémentation sans modifier le Service
- **Testabilité** : On peut créer un Repository de test (mock)
- **Cohérence** : Le Service ne change pas, seul le Repository change

#### Étape 9.1 : L'interface reste identique

**Fichier : `Repositories/IProduitRepository.cs`** (identique à l'exercice précédent)

```csharp
using GestionProduitsEF.Models;

namespace GestionProduitsEF.Repositories
{
    public interface IProduitRepository
    {
        IEnumerable<Produit> GetAll();
        Produit? GetById(int id);
        
        void Add(Produit produit);
        void Update(Produit produit);
        bool Delete(int id);
        
        IEnumerable<Categorie> GetAllCategories();
        Categorie? GetCategoryById(int id);
    }
}
```

#### Étape 9.2 : Créer l'implémentation avec EF Core

**Action à faire :**
1. Créez le dossier `Repositories/` s'il n'existe pas
2. Créez le fichier `Repositories/ProduitRepository.cs`

**Contenu exact du fichier `Repositories/ProduitRepository.cs` :**

```csharp
using GestionProduitsEF.Models;
using GestionProduitsEF.Data;
using Microsoft.EntityFrameworkCore;

namespace GestionProduitsEF.Repositories
{
    public class ProduitRepository : IProduitRepository
    {
        private readonly ApplicationDbContext _context;
        
        public ProduitRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public IEnumerable<Produit> GetAll()
        {
            return _context.Produits
                .Include(p => p.Categorie)
                .ToList();
        }
        
        public Produit? GetById(int id)
        {
            return _context.Produits
                .Include(p => p.Categorie)
                .FirstOrDefault(p => p.Id == id);
        }
        
        public void Add(Produit produit)
        {
            _context.Produits.Add(produit);
            _context.SaveChanges();
        }
        
        public void Update(Produit produit)
        {
            _context.Produits.Update(produit);
            _context.SaveChanges();
        }
        
        public bool Delete(int id)
        {
            var produit = GetById(id);
            
            if (produit == null)
                return false;
            
            _context.Produits.Remove(produit);
            _context.SaveChanges();
            
            return true;
        }
        
        public IEnumerable<Categorie> GetAllCategories()
        {
            return _context.Categories.ToList();
        }
        
        public Categorie? GetCategoryById(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }
    }
}
```

**Ce que vous devez comprendre :**
- `_context.Produits` = accès à la table Produits via EF Core
- `Include(p => p.Categorie)` = charge aussi la catégorie (eager loading)
- `Add`, `Update`, `Remove` = marquent les entités comme modifiées
- `SaveChanges()` = exécute les requêtes SQL en base de données
- L'interface reste identique, seule l'implémentation change

---

### Partie 10 : Créer le Service (identique à l'exercice précédent)

Le Service reste identique. Vous pouvez réutiliser le même fichier.

**Fichiers à créer :**
- `Services/IProduitService.cs`
- `Services/ProduitService.cs`

*(Voir l'exercice précédent pour le code exact)*

---

### Partie 11 : Créer le Controller (identique à l'exercice précédent)

Le Controller reste identique. Vous pouvez réutiliser le même fichier.

**Fichier à créer :**
- `Controllers/ProduitsController.cs`

*(Voir l'exercice précédent pour le code exact)*

---

### Partie 12 : Configurer l'injection de dépendance dans Program.cs

Maintenant, configurons l'injection de dépendance. Le Repository et le Service sont déjà configurés, mais nous devons nous assurer que tout est correct.

**Action à faire :**
1. Ouvrez le fichier `Program.cs`
2. Ajoutez l'injection de dépendance (après la configuration du DbContext)

**Contenu à ajouter dans `Program.cs` :**

```csharp
using GestionProduitsEF.Repositories;
using GestionProduitsEF.Services;

// Enregistrer le Repository
builder.Services.AddScoped<IProduitRepository, ProduitRepository>();

// Enregistrer le Service
builder.Services.AddScoped<IProduitService, ProduitService>();
```

**Ce que vous devez comprendre :**
- `AddScoped` = une instance par requête HTTP (recommandé pour les Repositories et Services)
- Le framework crée automatiquement `ApplicationDbContext` et l'injecte dans `ProduitRepository`
- Le framework crée automatiquement `ProduitRepository` et l'injecte dans `ProduitService`
- Le framework crée automatiquement `ProduitService` et l'injecte dans `ProduitsController`

---

### Partie 13 : Initialiser la base de données avec des données de test

Pour tester l'application, nous allons créer une méthode qui initialise la base de données avec des données de test au démarrage de l'application.

**POURQUOI initialiser avec des données de test ?**
- **Test rapide** : Permet de tester l'application immédiatement
- **Développement** : Facilite le développement sans avoir à créer les données manuellement
- **Démonstration** : Permet de montrer l'application avec des données

**Action à faire :**
1. Créez le fichier `Data/DbInitializer.cs`

**Contenu exact du fichier `Data/DbInitializer.cs` :**

```csharp
using GestionProduitsEF.Models;

namespace GestionProduitsEF.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
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
        }
    }
}
```

**Action à faire :**
1. Ouvrez le fichier `Program.cs`
2. Ajoutez l'appel à `DbInitializer.Initialize` (après la création de l'application)

**Contenu à ajouter dans `Program.cs` :**

```csharp
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    
    DbInitializer.Initialize(context);
}

// ... reste du code ...
```

**Important :** Ajoutez `using GestionProduitsEF.Data;` en haut du fichier `Program.cs`.

**Ce que vous devez comprendre :**
- `DbInitializer.Initialize` = initialise la base de données avec des données de test
- `CreateScope()` = crée un scope pour accéder aux services
- `GetRequiredService<ApplicationDbContext>()` = récupère le DbContext
- Cette méthode est appelée une seule fois au démarrage de l'application

---

### Partie 14 : Créer les Vues (identique à l'exercice précédent)

Les vues restent identiques. Vous pouvez réutiliser les mêmes fichiers.

**Fichiers à créer :**
- `Views/Produits/Index.cshtml`
- `Views/Produits/Details.cshtml`
- `Views/Produits/Create.cshtml`
- `Views/Produits/Edit.cshtml`

*(Voir l'exercice précédent pour le code exact)*

---

### Partie 15 : Tester l'application

Maintenant, testons l'application. Lancez l'application et vérifiez que tout fonctionne correctement.

**Action à faire :**
1. Lancez l'application (F5 ou Ctrl+F5)
2. Allez sur `/Produits/Index`
3. Vous devriez voir la liste des produits avec les données de test

**Vérifications :**
- La liste des produits s'affiche
- Les catégories sont chargées correctement
- Vous pouvez créer un nouveau produit
- Vous pouvez modifier un produit
- Vous pouvez supprimer un produit
- Les données persistent après redémarrage de l'application

**Vérifier dans MySQL Workbench :**
1. Ouvrez MySQL Workbench
2. Connectez-vous à la base de données
3. Exécutez : `SELECT * FROM Produits;`
4. Vous devriez voir les produits que vous avez créés

**Vérifier les relations :**
1. Exécutez : `SELECT p.*, c.Nom as CategorieNom FROM Produits p JOIN Categories c ON p.CategorieId = c.Id;`
2. Vous devriez voir les produits avec leurs catégories

---

## Points clés à retenir

### Architecture en couches (identique à l'exercice précédent)

```
┌────────────────────────────────────────────────────────────┐
│                    ARCHITECTURE                            │
├────────────────────────────────────────────────────────────┤
│                                                            │
│  Controller (Vue)                                          │
│    ↓ utilise                                               │
│  Service (Logique métier)                                   │
│    ↓ utilise                                               │
│  Repository (Accès aux données)                            │
│    ↓ utilise                                               │
│  Entity Framework Core (MySQL)                            │
│                                                            │
└────────────────────────────────────────────────────────────┘
```

### Différences avec DbFake

**DbFake (exercice précédent) :**
- Données en mémoire (perdues au redémarrage)
- Pas de persistance
- Pas de requêtes SQL

**Entity Framework Core (cet exercice) :**
- Données en base de données MySQL (persistantes)
- Persistance automatique
- Requêtes SQL générées automatiquement
- Migrations pour gérer le schéma

### Commandes importantes

**Migrations :**
- `Add-Migration NomMigration` = crée une nouvelle migration
- `Update-Database` = applique les migrations
- `Remove-Migration` = supprime la dernière migration (si pas encore appliquée)

**Méthodes EF Core importantes :**
- `Include()` = charge les relations (eager loading)
- `Add()`, `Update()`, `Remove()` = marque les entités comme modifiées
- `SaveChanges()` = exécute les requêtes SQL

### Avantages d'EF Core

- **Code-First** : Créez les Models en C#, EF Core crée la base de données
- **LINQ** : Requêtes en C# au lieu de SQL brut
- **Type-safe** : Erreurs détectées à la compilation
- **Migrations** : Gestion automatique des changements de schéma
- **Performance** : Optimisations automatiques (requêtes préparées, etc.)

---

## Dépannage

### Erreur : "Unable to connect to any of the specified MySQL hosts"

**Solution :**
- Vérifiez que MySQL Server est démarré
- Vérifiez la chaîne de connexion dans `appsettings.json`
- Vérifiez le port (3306 par défaut)
- Vérifiez le mot de passe

### Erreur : "Table 'GestionProduitsDB.Categories' doesn't exist"

**Solution :**
- Exécutez `Update-Database` pour créer les tables
- Vérifiez que les migrations ont été appliquées
- Vérifiez que la base de données `GestionProduitsDB` existe dans MySQL Workbench

### Erreur : "Cannot add migration because the project targets .NET Framework"

**Solution :**
- Utilisez `.NET Core` ou `.NET 8.0` (pas .NET Framework)
- Vérifiez la version du projet dans le fichier `.csproj`

### Erreur : "The Pomelo.EntityFrameworkCore.MySql package is not installed"

**Solution :**
- Installez le package `Pomelo.EntityFrameworkCore.MySql` via NuGet
- Vérifiez que la version est compatible avec votre version d'EF Core

---

## Félicitations !

Vous avez créé une application CRUD complète avec **Entity Framework Core et MySQL** :

- **Entity Framework Core** : ORM pour accéder à la base de données
- **MySQL** : Base de données relationnelle
- **MySQL Workbench** : Interface graphique pour gérer la base de données
- **Migrations** : Gestion automatique du schéma
- **Architecture en couches** : Code organisé et maintenable

**Prochaine étape :** Vous pouvez maintenant ajouter d'autres fonctionnalités (authentification, pagination, recherche, etc.) en utilisant la même architecture !

---

Vous maîtrisez maintenant Entity Framework Core avec MySQL dans une architecture professionnelle !
