# CRUD Complet avec Repository Pattern et Service Layer

## Objectif

> **Temps estimé : 3h**
> 
> Créer une **application CRUD complète** de gestion de produits en utilisant :
> - Des **Models** pour la structure de la base de données
> - Des **ViewModels** avec Data Annotations pour la validation et l'affichage
> - Des **Extensions** pour le mapping Model ↔ ViewModel
> - Un **Repository Pattern** pour l'accès aux données
> - Un **Service Layer** pour la logique métier
> - Un **DbFake** (liste en mémoire) pour simuler une base de données
> - Un **Controller** qui utilise le Service (pas d'accès direct aux données)

---

## Introduction Théorique

### QUOI : Qu'allons-nous construire ?

Vous allez créer une **application CRUD complète** avec une **architecture en couches** :

```
Controller (Vue)
    ↓ utilise
Service (Logique métier)
    ↓ utilise
Repository (Accès aux données)
    ↓ utilise
DbFake (Liste en mémoire)
```

**Structure complète :**
- **Models** : `Produit`, `Categorie` (structure BDD)
- **ViewModels** : `ProduitFormViewModel`, `ProduitDetailsViewModel`, `ProduitListItemViewModel`
- **Repository** : Interface `IProduitRepository` + Implémentation `ProduitRepository`
- **Service** : Interface `IProduitService` + Implémentation `ProduitService`
- **DbFake** : Classe `DbFake` avec listes en mémoire
- **Extensions** : Mapping Model ↔ ViewModel
- **Controller** : Utilise le Service (pas d'accès direct aux données)

### POURQUOI : Pourquoi cette architecture ?

**Avantages du Repository Pattern :**
- **Séparation des responsabilités** : Le Controller ne connaît pas la source de données
- **Testabilité** : Facile de créer un Repository de test (mock)
- **Flexibilité** : On peut changer de BDD (SQL Server → MySQL) sans modifier le Controller
- **Réutilisabilité** : Le Repository peut être utilisé par plusieurs Services

**Avantages du Service Layer :**
- **Logique métier centralisée** : Toute la logique est dans le Service
- **Controller léger** : Le Controller ne fait que coordonner (pas de logique)
- **Réutilisabilité** : Le Service peut être utilisé par un Controller MVC, une API, etc.
- **Testabilité** : Facile de tester la logique métier isolément

**Différence avec l'exercice précédent :**
- **Exercice précédent** : Controller accède directement aux listes `_produits` et `_categories`
- **Cet exercice** : Controller → Service → Repository → DbFake (architecture en couches)

**Que se passe-t-il sans cette architecture ?**
- Code difficile à tester
- Logique métier mélangée avec l'accès aux données
- Difficile de changer de source de données
- Code dupliqué si plusieurs Controllers utilisent les mêmes données

---

## Structure du projet

### Organisation des fichiers

```
GestionProduits/
├── Models/
│   ├── Produit.cs
│   └── Categorie.cs
├── ViewModels/
│   └── Produits/
│       ├── ProduitFormViewModel.cs
│       ├── ProduitDetailsViewModel.cs
│       └── ProduitListItemViewModel.cs
├── Extensions/
│   └── ProduitMappingExtensions.cs
├── Data/
│   └── DbFake.cs                    ← Simule une base de données
├── Repositories/
│   ├── IProduitRepository.cs       ← Interface du Repository
│   └── ProduitRepository.cs         ← Implémentation du Repository
├── Services/
│   ├── IProduitService.cs           ← Interface du Service
│   └── ProduitService.cs             ← Implémentation du Service
├── Controllers/
│   └── ProduitsController.cs        ← Utilise le Service
└── Views/
    └── Produits/
        ├── Index.cshtml
        ├── Details.cshtml
        ├── Create.cshtml
        └── Edit.cshtml
```

---

## Guide Pas à Pas Détaillé

---

### Partie 1 : Créer les Models (identique à l'exercice précédent)

Les Models restent identiques. Si vous avez déjà fait l'exercice précédent, vous pouvez réutiliser les mêmes fichiers.

**Fichiers à créer :**
- `Models/Produit.cs`
- `Models/Categorie.cs`

*(Voir l'exercice précédent pour le code exact)*

---

### Partie 2 : Créer les ViewModels (identique à l'exercice précédent)

Les ViewModels restent identiques.

**Fichiers à créer :**
- `ViewModels/Produits/ProduitFormViewModel.cs`
- `ViewModels/Produits/ProduitDetailsViewModel.cs`
- `ViewModels/Produits/ProduitListItemViewModel.cs`

*(Voir l'exercice précédent pour le code exact)*

---

### Partie 3 : Créer les Extensions (identique à l'exercice précédent)

Les Extensions restent identiques.

**Fichier à créer :**
- `Extensions/ProduitMappingExtensions.cs`

*(Voir l'exercice précédent pour le code exact)*

---

### Partie 4 : Créer le DbFake (simule une base de données)

Le DbFake simule une base de données avec des listes en mémoire. Plus tard, avec Entity Framework, on remplacera ces listes par une vraie base de données.

**POURQUOI créer ce fichier ?**
- **Simule une BDD** : Centralise toutes les données en mémoire
- **Unique source de vérité** : Toutes les données viennent d'ici
- **Facile à remplacer** : Plus tard, on remplacera par Entity Framework
- **Réutilisable** : Utilisé par tous les Repositories

**Action à faire :**
1. Créez le dossier `Data/` s'il n'existe pas
2. Créez le fichier `Data/DbFake.cs`

**Contenu exact du fichier `Data/DbFake.cs` :**

```csharp
using GestionProduits.Models;

namespace GestionProduits.Data
{
    public static class DbFake
    {
        private static readonly List<Categorie> _categories = new()
        {
            new() { Id = 1, Nom = "Informatique" },
            new() { Id = 2, Nom = "Accessoires" },
            new() { Id = 3, Nom = "Périphériques" }
        };

        private static List<Produit> _produits = new()
        {
            new() 
            { 
                Id = 1, 
                Nom = "Laptop Pro", 
                Description = "Ordinateur portable haute performance avec processeur Intel i7 et 16 Go de RAM",
                Prix = 1299.99m, 
                QuantiteStock = 15,
                DateCreation = DateTime.UtcNow.AddDays(-30),
                CategorieId = 1,
                Categorie = _categories[0]
            },
            new() 
            { 
                Id = 2, 
                Nom = "Souris Gaming", 
                Description = "Souris optique avec capteur haute précision, 7 boutons programmables",
                Prix = 79.99m, 
                QuantiteStock = 50,
                DateCreation = DateTime.UtcNow.AddDays(-15),
                CategorieId = 2,
                Categorie = _categories[1]
            },
            new() 
            { 
                Id = 3, 
                Nom = "Clavier Mécanique", 
                Description = "Clavier mécanique avec switches Cherry MX Blue, rétroéclairage RGB",
                Prix = 149.99m, 
                QuantiteStock = 0,
                DateCreation = DateTime.UtcNow.AddDays(-60),
                CategorieId = 2,
                Categorie = _categories[1]
            },
            new() 
            { 
                Id = 4, 
                Nom = "Écran 27\"", 
                Description = "Écran 4K Ultra HD, 144 Hz, HDR10, temps de réponse 1ms",
                Prix = 399.99m, 
                QuantiteStock = 3,
                DateCreation = DateTime.UtcNow.AddDays(-7),
                CategorieId = 3,
                Categorie = _categories[2]
            }
        };

        public static IReadOnlyList<Categorie> Categories => _categories.AsReadOnly();
        
        public static List<Produit> Produits => _produits;
    }
}
```

**Ce que vous devez comprendre :**
- `DbFake` = simule une base de données avec des listes en mémoire
- `Categories` = propriété en lecture seule (IReadOnlyList)
- `Produits` = propriété modifiable (List) car le Repository doit pouvoir CRUD
- Plus tard, avec Entity Framework, on remplacera ces listes par une vraie BDD
- Le Repository est le seul à accéder à `DbFake` (pas le Controller directement)

---

### Partie 5 : Créer le Repository Pattern

Le Repository Pattern isole l'accès aux données. Le Controller et le Service ne savent pas d'où viennent les données (liste en mémoire, SQL Server, MySQL, etc.).

**POURQUOI créer un Repository ?**
- **Abstraction** : Cache la source de données (liste, BDD, API, etc.)
- **Testabilité** : Facile de créer un Repository de test (mock)
- **Flexibilité** : On peut changer de source de données sans modifier le Service
- **Réutilisabilité** : Le Repository peut être utilisé par plusieurs Services

#### Étape 5.1 : Créer l'interface `IProduitRepository`

**Action à faire :**
1. Créez le dossier `Repositories/` s'il n'existe pas
2. Créez le fichier `Repositories/IProduitRepository.cs`

**Contenu exact du fichier `Repositories/IProduitRepository.cs` :**

```csharp
using GestionProduits.Models;

namespace GestionProduits.Repositories
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

**Ce que vous devez comprendre :**
- Interface = contrat que doit respecter l'implémentation
- Le Service utilise l'interface (pas l'implémentation)
- On peut créer plusieurs implémentations (DbFake, Entity Framework, API, etc.)
- Toutes les opérations CRUD sont définies ici

#### Étape 5.2 : Créer l'implémentation `ProduitRepository`

**Action à faire :**
1. Créez le fichier `Repositories/ProduitRepository.cs`

**Contenu exact du fichier `Repositories/ProduitRepository.cs` :**

```csharp
using GestionProduits.Models;
using GestionProduits.Data;

namespace GestionProduits.Repositories
{
    public class ProduitRepository : IProduitRepository
    {
        public IEnumerable<Produit> GetAll()
        {
            return DbFake.Produits;
        }
        
        public Produit? GetById(int id)
        {
            return DbFake.Produits.FirstOrDefault(p => p.Id == id);
        }
        
        public void Add(Produit produit)
        {
            if (DbFake.Produits.Any())
            {
                produit.Id = DbFake.Produits.Max(p => p.Id) + 1;
            }
            else
            {
                produit.Id = 1;
            }
            
            produit.Categorie = GetCategoryById(produit.CategorieId);
            DbFake.Produits.Add(produit);
        }
        
        public void Update(Produit produit)
        {
            var index = DbFake.Produits.FindIndex(p => p.Id == produit.Id);
            
            if (index >= 0)
            {
                produit.Categorie = GetCategoryById(produit.CategorieId);
                DbFake.Produits[index] = produit;
            }
        }
        
        public bool Delete(int id)
        {
            var produit = GetById(id);
            
            if (produit != null)
            {
                DbFake.Produits.Remove(produit);
                return true;
            }
            
            return false;
        }
        
        public IEnumerable<Categorie> GetAllCategories()
        {
            return DbFake.Categories;
        }
        
        public Categorie? GetCategoryById(int id)
        {
            return DbFake.Categories.FirstOrDefault(c => c.Id == id);
        }
    }
}
```

**Ce que vous devez comprendre :**
- `ProduitRepository` implémente `IProduitRepository`
- Accède aux données via `DbFake` (liste en mémoire)
- Plus tard, on créera `ProduitRepositoryEF` qui utilise Entity Framework
- Le Service utilise l'interface, pas l'implémentation (flexibilité)

---

### Partie 6 : Créer le Service Layer

Le Service Layer contient toute la logique métier. Le Controller ne fait que coordonner, toute la logique est dans le Service.

**POURQUOI créer un Service ?**
- **Logique métier centralisée** : Toute la logique est dans le Service
- **Controller léger** : Le Controller ne fait que coordonner (pas de logique)
- **Réutilisabilité** : Le Service peut être utilisé par un Controller MVC, une API, etc.
- **Testabilité** : Facile de tester la logique métier isolément

#### Étape 6.1 : Créer l'interface `IProduitService`

**Action à faire :**
1. Créez le dossier `Services/` s'il n'existe pas
2. Créez le fichier `Services/IProduitService.cs`

**Contenu exact du fichier `Services/IProduitService.cs` :**

```csharp
using GestionProduits.ViewModels.Produits;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionProduits.Services
{
    public interface IProduitService
    {
        List<ProduitListItemViewModel> GetAll();
        
        ProduitDetailsViewModel? GetById(int id);
        
        ProduitFormViewModel GetFormViewModel(int? id);
        
        bool Create(ProduitFormViewModel viewModel);
        
        bool Update(int id, ProduitFormViewModel viewModel);
        
        bool Delete(int id);
    }
}
```

**Ce que vous devez comprendre :**
- Interface = contrat que doit respecter l'implémentation
- Le Controller utilise l'interface (pas l'implémentation)
- Le Service retourne des ViewModels (pas des Models)
- Toutes les opérations métier sont définies ici

#### Étape 6.2 : Créer l'implémentation `ProduitService`

**Action à faire :**
1. Créez le fichier `Services/ProduitService.cs`

**Contenu exact du fichier `Services/ProduitService.cs` :**

```csharp
using GestionProduits.Repositories;
using GestionProduits.Extensions;
using GestionProduits.ViewModels.Produits;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionProduits.Services
{
    public class ProduitService : IProduitService
    {
        private readonly IProduitRepository _repository;
        
        public ProduitService(IProduitRepository repository)
        {
            _repository = repository;
        }
        
        public IEnumerable<ProduitListItemViewModel> GetAll()
        {
            var produits = _repository.GetAll();
            return produits.Select(p => p.ToListItem());
        }
        
        public ProduitDetailsViewModel? GetById(int id)
        {
            var produit = _repository.GetById(id);
            
            if (produit == null)
                return null;
            
            return produit.ToDetails();
        }
        
        public ProduitFormViewModel GetFormViewModel(int? id)
        {
            if (id == null)
            {
                return new ProduitFormViewModel
                {
                    CategoriesSelectList = GetCategoriesSelectList()
                };
            }
            
            var produit = _repository.GetById(id.Value);
            
            if (produit == null)
            {
                return new ProduitFormViewModel
                {
                    CategoriesSelectList = GetCategoriesSelectList()
                };
            }
            
            var viewModel = produit.ToFormViewModel();
            viewModel.CategoriesSelectList = GetCategoriesSelectList(produit.CategorieId);
            
            return viewModel;
        }
        
        public bool Create(ProduitFormViewModel viewModel)
        {
            var produit = viewModel.ToModel();
            produit.DateCreation = DateTime.UtcNow;
            _repository.Add(produit);
            
            return true;
        }
        
        public bool Update(int id, ProduitFormViewModel viewModel)
        {
            var produitExistant = _repository.GetById(id);
            if (produitExistant == null)
                return false;
            
            var produit = viewModel.ToModel();
            produit.Id = id;
            produit.DateCreation = produitExistant.DateCreation;
            _repository.Update(produit);
            
            return true;
        }
        
        public bool Delete(int id)
        {
            return _repository.Delete(id);
        }
        
        private SelectList? GetCategoriesSelectList(int? selectedValue = null)
        {
            var categories = _repository.GetAllCategories();
            return new SelectList(categories, "Id", "Nom", selectedValue);
        }
    }
}
```

**Ce que vous devez comprendre :**
- `ProduitService` implémente `IProduitService`
- Utilise le Repository pour accéder aux données (pas directement DbFake)
- Contient toute la logique métier (transformation Model ↔ ViewModel, etc.)
- Le Repository est injecté via le constructeur (injection de dépendance)
- Retourne des ViewModels (pas des Models)

---

### Partie 7 : Créer le Controller (utilise le Service)

Le Controller est maintenant très léger. Il ne fait que coordonner : il reçoit les requêtes, appelle le Service, et retourne les vues. Toute la logique est dans le Service.

**POURQUOI le Controller est léger ?**
- **Pas de logique métier** : Toute la logique est dans le Service
- **Pas d'accès aux données** : Le Service utilise le Repository
- **Coordination uniquement** : Reçoit les requêtes, appelle le Service, retourne les vues
- **Facile à tester** : Le Controller est simple, on teste surtout le Service

**Action à faire :**
1. Créez le fichier `Controllers/ProduitsController.cs`

**Contenu exact du fichier `Controllers/ProduitsController.cs` :**

```csharp
using Microsoft.AspNetCore.Mvc;
using GestionProduits.Services;
using GestionProduits.ViewModels.Produits;

namespace GestionProduits.Controllers
{
    public class ProduitsController : Controller
    {
        private readonly IProduitService _service;
        
        public ProduitsController(IProduitService service)
        {
            _service = service;
        }
        
        public IActionResult Index()
        {
            var viewModels = _service.GetAll();
            return View(viewModels.ToList());
        }
        
        public IActionResult Details(int id)
        {
            var viewModel = _service.GetById(id);
            
            if (viewModel == null)
                return NotFound();
            
            return View(viewModel);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = _service.GetFormViewModel(null);
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProduitFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.CategoriesSelectList = _service.GetFormViewModel(null).CategoriesSelectList;
                return View(viewModel);
            }
            
            var success = _service.Create(viewModel);
            
            if (success)
            {
                TempData["Success"] = "Produit créé avec succès !";
                return RedirectToAction("Index");
            }
            
            viewModel.CategoriesSelectList = _service.GetFormViewModel(null).CategoriesSelectList;
            return View(viewModel);
        }
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var viewModel = _service.GetFormViewModel(id);
            
            if (viewModel.Id == null)
                return NotFound();
            
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProduitFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.CategoriesSelectList = _service.GetFormViewModel(id).CategoriesSelectList;
                return View(viewModel);
            }
            
            var success = _service.Update(id, viewModel);
            
            if (success)
            {
                TempData["Success"] = "Produit modifié avec succès !";
                return RedirectToAction("Index");
            }
            
            return NotFound();
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var success = _service.Delete(id);
            
            if (success)
            {
                TempData["Success"] = "Produit supprimé avec succès !";
                return RedirectToAction("Index");
            }
            
            return NotFound();
        }
    }
}
```

**Ce que vous devez comprendre :**
- Le Controller est très léger (pas de logique métier)
- Utilise le Service pour toutes les opérations
- Le Service est injecté via le constructeur (injection de dépendance)
- Pas d'accès direct aux données (pas de `DbFake` dans le Controller)
- Coordination uniquement : reçoit les requêtes, appelle le Service, retourne les vues

---

### Partie 8 : Configurer l'injection de dépendance

L'injection de dépendance permet au framework de créer automatiquement les objets (Service, Repository) et de les injecter dans le Controller. C'est une fonctionnalité intégrée d'ASP.NET Core.

**POURQUOI configurer l'injection de dépendance ?**
- **Création automatique** : Le framework crée les objets pour nous
- **Gestion du cycle de vie** : Le framework gère quand créer/détruire les objets
- **Testabilité** : Facile de remplacer par des mocks pour les tests
- **Découplage** : Le Controller ne crée pas les objets, il les reçoit

**Action à faire :**
1. Ouvrez le fichier `Program.cs` (ou `Startup.cs` selon votre version)

**Contenu à ajouter dans `Program.cs` :**

```csharp
using GestionProduits.Repositories;
using GestionProduits.Services;

// Dans la méthode Main ou ConfigureServices, ajoutez :

// Enregistrer le Repository
builder.Services.AddScoped<IProduitRepository, ProduitRepository>();

// Enregistrer le Service
builder.Services.AddScoped<IProduitService, ProduitService>();
```

**Explication :**
- `AddScoped` = une instance par requête HTTP (recommandé pour les Repositories et Services)
- Le framework crée automatiquement `ProduitRepository` et l'injecte dans `ProduitService`
- Le framework crée automatiquement `ProduitService` et l'injecte dans `ProduitsController`

---

### Partie 9 : Créer les Vues (identique à l'exercice précédent)

Les vues restent identiques. Vous pouvez réutiliser les mêmes fichiers.

**Fichiers à créer :**
- `Views/Produits/Index.cshtml`
- `Views/Produits/Details.cshtml`
- `Views/Produits/Create.cshtml`
- `Views/Produits/Edit.cshtml`

*(Voir l'exercice précédent pour le code exact)*

---

## Points clés à retenir

### Architecture en couches

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
│  DbFake / Entity Framework (Source de données)            │
│                                                            │
└────────────────────────────────────────────────────────────┘
```

### Responsabilités de chaque couche

**Controller :**
- Reçoit les requêtes HTTP
- Appelle le Service
- Retourne les vues
- Pas de logique métier
- Pas d'accès aux données

**Service :**
- Contient toute la logique métier
- Transforme Model ↔ ViewModel
- Utilise le Repository pour accéder aux données
- Ne connaît pas la source de données (liste, BDD, API, etc.)

**Repository :**
- Accède aux données (DbFake, Entity Framework, API, etc.)
- Opérations CRUD simples
- Pas de logique métier
- Ne retourne que des Models (pas de ViewModels)

**DbFake :**
- Simule une base de données avec des listes en mémoire
- Plus tard, remplacé par Entity Framework

### Avantages de cette architecture

- **Séparation des responsabilités** : Chaque couche a un rôle précis
- **Testabilité** : Facile de tester chaque couche isolément
- **Flexibilité** : On peut changer de source de données sans modifier le Service
- **Réutilisabilité** : Le Service peut être utilisé par un Controller MVC, une API, etc.
- **Maintenabilité** : Code organisé et facile à comprendre

---

## Félicitations !

Vous avez créé une application CRUD complète avec une **architecture professionnelle** :

- **Repository Pattern** : Accès aux données isolé
- **Service Layer** : Logique métier centralisée
- **Injection de dépendance** : Objets créés automatiquement
- **Architecture en couches** : Code organisé et maintenable

**Prochaine étape :** Avec Entity Framework, vous remplacerez `DbFake` par une vraie base de données, mais le reste de l'architecture restera identique !

---

Vous maîtrisez maintenant l'architecture professionnelle utilisée dans tous les projets ASP.NET Core MVC !
