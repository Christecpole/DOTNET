# Exercice : CRUD Complet avec Models et ViewModels

## Objectif

> **Temps estimé : 2h30**
> 
> Créer une **application CRUD complète** de gestion de produits en utilisant :
> - Des **Models** pour la structure de la base de données
> - Des **ViewModels** avec Data Annotations pour la validation et l'affichage
> - Des **Extensions** pour le mapping Model ↔ ViewModel
> - Un **Controller complet** avec toutes les opérations CRUD

---

## Introduction Théorique

### QUOI : Qu'allons-nous construire ?

Vous allez créer une **application CRUD complète de gestion de produits** avec :
- Des **Models** (`Produit`, `Categorie`) pour la structure de la base de données
- Des **ViewModels** (`ProduitFormViewModel`, `ProduitDetailsViewModel`, `ProduitListItemViewModel`) avec Data Annotations pour la validation et l'affichage
- Une **page Index** : liste des produits dans un tableau avec boutons d'action
- Une **page Details** : affichage détaillé d'un produit
- Une **page Create** : formulaire de création avec validation
- Une **page Edit** : formulaire de modification avec validation
- Une **fonctionnalité Delete** : suppression avec popup de confirmation
- Des **Extensions de mapping** pour transformer Model ↔ ViewModel

### POURQUOI : Pourquoi cet exercice est important ?

Cet exercice vous permet de :
1. **Comprendre la différence** entre Model et ViewModel
2. **Pratiquer les Data Annotations** pour la validation
3. **Maîtriser le mapping** Model ↔ ViewModel avec des Extensions
4. **Créer un CRUD complet** avec les bonnes pratiques
5. **Appliquer la séparation des responsabilités** (Model = données, ViewModel = présentation)

**Différence avec l'exercice Views :**
- **Exercice Views** : Utilisait `IFormCollection` et objets anonymes (méthode simple)
- **Cet exercice** : Utilise des Models typés et des ViewModels (méthode professionnelle)

### COMMENT : Comment aborder cet exercice ?

**Approche recommandée :**
1. **Suivez les étapes** dans l'ordre
2. **Comprenez chaque concept** avant de passer au suivant
3. **Lisez les commentaires** dans le code pour comprendre chaque élément
4. **Comparez avec l'exercice Views** pour voir l'évolution
5. **Testez après chaque étape** pour vérifier que tout fonctionne

---

## Mise en place Solution

### Configuration nécessaire

**Prérequis :**
- .NET SDK installé (vérifiez avec `dotnet --version`)
- Visual Studio Code ou Visual Studio installé
- Connaissance de base de C# (classes, propriétés, collections, LINQ)
- Avoir terminé l'exercice Views (CRUD avec IFormCollection)

### Structure de la solution : Deux projets

**Structure de la solution à créer :**
```
Formation-ASPNET/
└── Models-MVC/                    ← Dossier de la solution
    ├── Models-MVC.sln            ← Fichier solution
    ├── Models-MVC-Demo/           ← Projet DEMO (formateur code, stagiaires regardent)
    │   ├── Controllers/
    │   ├── Models/
    │   ├── ViewModels/
    │   ├── Extensions/
    │   ├── Views/
    │   └── wwwroot/
    └── Models-MVC-Exo/            ← Projet EXO (stagiaires pratiquent)
        ├── Controllers/
        ├── Models/
        ├── ViewModels/
        ├── Extensions/
        ├── Views/
        └── wwwroot/
```


### Commandes pour créer le projet

**Commandes à exécuter :**

```bash
# 1. Créer le dossier de la solution
mkdir Models-MVC
cd Models-MVC

# 2. Créer la solution
dotnet new sln -n Models-MVC

# 3. Créer le projet EXO (celui où vous allez travailler)
dotnet new mvc -n Models-MVC-Exo

# 4. Ajouter le projet à la solution
dotnet sln add Models-MVC-Exo/Models-MVC-Exo.csproj

# 5. Créer les dossiers nécessaires
cd Models-MVC-Exo
mkdir Models
mkdir ViewModels
mkdir ViewModels\Produits
mkdir Extensions
```

**Vérification :** 
- Ouvrez le projet dans Visual Studio ou VS Code
- Vérifiez que les dossiers `Models/`, `ViewModels/Produits/`, et `Extensions/` existent

---

## Exercice Autonome - GUIDE PAS À PAS COMPLET

---

### Consigne Complète

**Consigne :** Créer une application CRUD complète de gestion de produits en utilisant des Models typés et des ViewModels.

**Partie 1 : Créer les Models (Structure BDD uniquement)**  
   - Créer `Models/Categorie.cs` avec la structure de la BDD
   - Créer `Models/Produit.cs` avec la structure de la BDD et relations
   - **PAS de Data Annotations dans les Models** (validations dans les ViewModels)

**Partie 2 : Créer les ViewModels**  
   - Créer `ViewModels/Produits/ProduitFormViewModel.cs` pour Create/Edit
   - Créer `ViewModels/Produits/ProduitDetailsViewModel.cs` pour Details
   - Créer `ViewModels/Produits/ProduitListItemViewModel.cs` pour Index (bonne pratique stricte)

**Partie 3 : Créer les Extensions de Mapping**  
   - Créer `Extensions/ProduitMappingExtensions.cs`
   - Méthodes : `ToFormViewModel()`, `ToModel()`, `ToDetails()`, `ToListItem()`

**Partie 4 : Créer le Controller avec toutes les actions CRUD**  
   - Créer `Controllers/ProduitsController.cs`
   - Actions : Index, Details, Create (GET/POST), Edit (GET/POST), Delete (GET/POST)
   - Utiliser les ViewModels et les Extensions

**Partie 5 : Créer les Vues**  
   - Créer `Views/Produits/Index.cshtml` avec tableau (utilise `ProduitListItemViewModel`)
   - Créer `Views/Produits/Details.cshtml` avec ViewModel
   - Créer `Views/Produits/Create.cshtml` avec formulaire et validation
   - Créer `Views/Produits/Edit.cshtml` avec formulaire et validation
   - Ajouter un modal Bootstrap dans `Views/Produits/Details.cshtml` pour la suppression
   - (La vue `Delete.cshtml` n'est pas nécessaire avec les modals)

---

### Objectifs à Atteindre

Avant de commencer le pas à pas, voici ce que vous devez savoir faire à la fin de cet exercice :

**Objectifs techniques :**
1. Créer des **Models** pour la structure de la base de données (sans validations)
2. Créer des **ViewModels** avec Data Annotations pour la validation et l'affichage
3. Créer des **Extensions de mapping** pour transformer Model ↔ ViewModel
4. Utiliser `ModelState.IsValid` pour valider les données
5. Utiliser les **Tag Helpers** `asp-for` et `asp-validation-for`
6. Utiliser `SelectList` pour les dropdowns de catégories
7. Comprendre la différence entre Model et ViewModel

**Objectifs fonctionnels :**
1. **Page Index** : Liste des produits dans un tableau avec boutons d'action
2. **Page Details** : Affichage détaillé d'un produit avec ViewModel
3. **Page Create** : Formulaire de création avec validation (côté serveur et client)
4. **Page Edit** : Formulaire de modification avec validation
5. **Fonctionnalité Delete** : Suppression avec popup de confirmation
6. **Validation** : Messages d'erreur affichés sous chaque champ
7. **Messages** : Affichage de messages de succès après chaque action
8. **CRUD complet** : Toutes les opérations fonctionnent avec Models et ViewModels

**Résultat attendu :**
- **Application CRUD complète** avec Models typés et ViewModels
- **Validation** fonctionnelle côté serveur (Data Annotations) et côté client (jQuery)
- **Code propre** avec séparation des responsabilités (Model = données, ViewModel = présentation)
- **Mapping** centralisé dans les Extensions

---

## Structure du projet

### Organisation des fichiers

```
GestionProduits/
├── Models/
│   ├── Produit.cs
│   └── Categorie.cs
├── ViewModels/
│   ├── Produits/
│   │   ├── ProduitFormViewModel.cs
│   │   ├── ProduitDetailsViewModel.cs
│   │   └── ProduitListItemViewModel.cs
│   └── Shared/
│       └── (aucun pour cet exercice simple)
├── Extensions/
│   └── ProduitMappingExtensions.cs
├── Controllers/
│   └── ProduitsController.cs
└── Views/
    └── Produits/
        ├── Index.cshtml
        ├── Details.cshtml
        ├── Create.cshtml
        └── Edit.cshtml
        (Note : Delete.cshtml n'est pas nécessaire, on utilise des modals Bootstrap)
```

---

## Guide Pas à Pas Détaillé - CRUD Complet avec Models et ViewModels

---

### Partie 1 : Créer les Models (Structure BDD uniquement)

**IMPORTANT :** Les Models contiennent **UNIQUEMENT la structure de la BDD**, pas les validations !
- Les validations seront dans les ViewModels (Partie 2)

**POURQUOI créer ces fichiers ?**
- **Structure des données** : définissent les propriétés de nos entités (types, relations)
- **Mapping BDD** : attributs pour la structure SQL (`[Column]`, `[NotMapped]`)
- **Relations** : navigation properties pour les relations entre entités
- **Réutilisables** : utilisés partout dans l'application (services, API, etc.)
- **Base solide** : fondation pour tout le reste
- **PAS de validations** : Les validations sont dans les ViewModels !

#### Étape 1.1 : Créer le Model `Categorie`

**Action à faire :**
1. Créez le fichier `Models/Categorie.cs`

**Contenu exact du fichier `Models/Categorie.cs` :**

```csharp
namespace GestionProduits.Models
{
    public class Categorie
    {
        public int Id { get; set; }

        public string Nom { get; set; } = string.Empty;

        public string? Description { get; set; }

        public virtual ICollection<Produit> Produits { get; set; } = new List<Produit>();
    }
}
```

**Ce que vous devez comprendre :**
- **Le Model contient UNIQUEMENT la structure BDD** (types, relations)
- **PAS de validations** (`[Required]`, `[StringLength]`) dans le Model
- `virtual ICollection<Produit>` = relation 1-N (une catégorie a plusieurs produits)
- `= string.Empty` = initialisation par défaut (évite les erreurs null)
- **Toutes les validations seront dans le ViewModel !**

#### Étape 1.2 : Créer le Model `Produit`

**Action à faire :**
1. Créez le fichier `Models/Produit.cs`

**Contenu exact du fichier `Models/Produit.cs` :**

```csharp
using System.ComponentModel.DataAnnotations.Schema;

namespace GestionProduits.Models
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

        [NotMapped]
        public bool EstEnStock => QuantiteStock > 0;
    }
}
```

**Ce que vous devez comprendre :**
- **Le Model contient UNIQUEMENT la structure BDD** (types, relations, mapping SQL)
- **PAS de validations** (`[Required]`, `[StringLength]`, `[Range]`) dans le Model
- **PAS d'attributs d'affichage** (`[Display]`) dans le Model
- `[Column(TypeName = "decimal(18,2)")]` = uniquement pour la structure BDD (type SQL)
- `[NotMapped]` = pour les propriétés calculées qui n'existent pas en BDD
- `virtual Categorie?` = relation N-1 (plusieurs produits ont une catégorie)
- `EstEnStock` = propriété calculée (pas stockée en BDD)
- **Toutes les validations seront dans le ViewModel !**

**Explication détaillée : `[Column(TypeName = "decimal(18,2)")]`**

Quand Entity Framework crée la table SQL, cette propriété devient :

```sql
CREATE TABLE Produits (
    Id INT PRIMARY KEY,
    Nom NVARCHAR(MAX),
    Prix DECIMAL(18,2),  -- ← Ici ! Type SQL précis
    QuantiteStock INT,
    DateCreation DATETIME2,
    CategorieId INT,
    ...
)
```

**Que signifie `decimal(18,2)` ?**
- **18** = nombre total de chiffres (avant + après la virgule)
- **2** = nombre de décimales (chiffres après la virgule)
- **Exemple de valeur** : `9999999999999999.99` (16 chiffres avant + 2 après = 18 total)
- **Plage de valeurs** : de `-9999999999999999.99` à `9999999999999999.99`

**Pourquoi c'est important ?**
- **Précision garantie** : Les prix auront toujours exactement 2 décimales
- **Type SQL explicite** : Sans cet attribut, Entity Framework pourrait utiliser un type différent (comme `FLOAT` ou `MONEY`)
- **Calculs financiers fiables** : Évite les erreurs d'arrondi dans les calculs
- **Compatibilité** : Fonctionne avec toutes les bases de données SQL (SQL Server, MySQL, PostgreSQL, etc.)

---

### Partie 2 : Créer les ViewModels (Validation + Affichage)

**POURQUOI créer ces fichiers ?**
- **Validation** : **TOUTES les Data Annotations de validation** (`[Required]`, `[StringLength]`, `[Range]`, etc.)
- **Affichage** : Attributs d'affichage (`[Display]`, `[DataType]`) pour les formulaires
- **Sécurité** : expose uniquement les données nécessaires
- **Performance** : évite le chargement de données inutiles
- **Flexibilité** : propriétés formatées pour l'affichage
- **Séparation** : Model = structure BDD, ViewModel = validation + présentation

#### Question importante : Pourquoi des Data Annotations dans le ViewModel et PAS dans le Model ?

**Vous vous demandez peut-être :** *"Pourquoi le Model n'a pas de Data Annotations alors que le ViewModel en a ?"*

**Réponse :** C'est la **bonne séparation des responsabilités** ! Voici pourquoi :

**Model = Structure de la BDD uniquement**

Le **Model** contient **UNIQUEMENT** :
- Les types de données (string, int, decimal, DateTime, etc.)
- Les relations entre entités (navigation properties)
- Les attributs de mapping BDD (`[Column]`, `[NotMapped]`)
- **PAS de validations** (`[Required]`, `[StringLength]`, `[Range]`)
- **PAS d'attributs d'affichage** (`[Display]`, `[DataType]`)

**Pourquoi ?** Le Model représente la structure de la base de données, pas les règles de validation des formulaires.

**ViewModel = Validation + Affichage**

Le **ViewModel** contient **TOUTES** les Data Annotations pour :

1. **Validation du formulaire** (le plus important) :
   - Quand l'utilisateur soumet un formulaire, c'est le **ViewModel** qui est lié au formulaire via **Model Binding**
   - `ModelState.IsValid` vérifie les Data Annotations du **ViewModel**, pas du Model
   - Les erreurs de validation sont affichées directement dans le formulaire
   - **Sans Data Annotations dans le ViewModel, la validation ne fonctionnerait pas !**

2. **Affichage dans le formulaire** :
   - `[Display(Name = "...")]` = libellé affiché dans le formulaire (label)
   - `[DataType(DataType.MultilineText)]` = type de champ HTML (textarea au lieu d'input)
   - Ces attributs sont **spécifiques au formulaire** et n'existent pas dans le Model

**Exemple concret :**
```csharp
// BON : Model = structure BDD uniquement
public class Produit
{
    public int Id { get; set; }
    public string Nom { get; set; } = string.Empty;  // Pas de [Required] !
    public decimal Prix { get; set; }  // Pas de [Range] !
}

// BON : ViewModel = validation + affichage
public class ProduitFormViewModel
{
    [Required(ErrorMessage = "Le nom est obligatoire")]  // Validation ici !
    [StringLength(100, MinimumLength = 2)]
    [Display(Name = "Nom du produit")]  // Affichage ici !
    public string Nom { get; set; } = string.Empty;
    
    [Required(ErrorMessage = "Le prix est obligatoire")]
    [Range(0.01, 999999.99)]
    [Display(Name = "Prix (€)")]
    public decimal Prix { get; set; }
}

// MAUVAIS : Si on n'avait PAS de Data Annotations dans le ViewModel :
[HttpPost]
public IActionResult Create(ProduitFormViewModel viewModel)
{
    // ModelState.IsValid serait toujours true, même si Nom est vide !
    if (!ModelState.IsValid)  // Ne fonctionnerait pas
    {
        return View(viewModel);
    }
    // Le produit serait créé avec un nom vide → ERREUR !
}
```

**Pourquoi cette séparation est importante ?**
- **Séparation des responsabilités** : Model = structure BDD, ViewModel = validation formulaire
- **Flexibilité** : Le ViewModel peut avoir des validations différentes du Model
- **Réutilisabilité** : Le Model peut être utilisé dans différents contextes (API, services, etc.)
- **Maintenabilité** : Les règles de validation sont centralisées dans le ViewModel

**En résumé :**
- **Model** : Structure de la BDD uniquement (types, relations, mapping SQL)
- **ViewModel** : Validation du formulaire + affichage (labels, types de champs, règles de validation)

**C'est la bonne pratique : Data Annotations UNIQUEMENT dans le ViewModel !**

---

#### Étape 2.1 : Créer le ViewModel `ProduitFormViewModel`

**POURQUOI créer ce ViewModel ?**
- **Formulaire** : utilisé pour Create et Edit
- **Validation** : Data Annotations pour valider les données du formulaire
- **SelectList** : contient la liste des catégories pour le dropdown
- **Mode** : permet de savoir si on est en création ou édition

**Action à faire :**
1. Créez le dossier `ViewModels/Produits/` s'il n'existe pas
2. Créez le fichier `ViewModels/Produits/ProduitFormViewModel.cs`

**Contenu exact du fichier `ViewModels/Produits/ProduitFormViewModel.cs` :**

```csharp
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GestionProduits.ViewModels.Produits
{
    public class ProduitFormViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(100, MinimumLength = 2)]
        [Display(Name = "Nom du produit")]
        public string Nom { get; set; } = string.Empty;

        [StringLength(500)]
        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Le prix est obligatoire")]
        [Range(0.01, 999999.99)]
        [Display(Name = "Prix (€)")]
        [DataType(DataType.Currency)]
        public decimal Prix { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Quantité en stock")]
        public int QuantiteStock { get; set; }

        [Required(ErrorMessage = "Veuillez sélectionner une catégorie")]
        [Display(Name = "Catégorie")]
        public int CategorieId { get; set; }

        public SelectList? CategoriesSelectList { get; set; }

        public bool EstEdition => Id.HasValue;
        
        public string TitreFormulaire => EstEdition ? "Modifier le produit" : "Nouveau produit";
    }
}
```

**Ce que vous devez comprendre :**
- `int? Id` = nullable pour distinguer création (null) et édition (valeur)
- `[Display]` = libellé affiché dans le formulaire
- `SelectList?` = liste déroulante pour les catégories
- `EstEdition` = propriété calculée pour savoir si on est en mode édition
- `TitreFormulaire` = titre dynamique selon le mode

#### Étape 2.2 : Créer le ViewModel `ProduitDetailsViewModel`

**POURQUOI créer ce ViewModel ?**
- **Affichage** : contient uniquement les données nécessaires pour la page Details
- **Formatage** : propriétés formatées pour l'affichage (prix, dates)
- **Sécurité** : n'expose pas toutes les propriétés du Model

**Action à faire :**
1. Créez le fichier `ViewModels/Produits/ProduitDetailsViewModel.cs`

**Contenu exact du fichier `ViewModels/Produits/ProduitDetailsViewModel.cs` :**

```csharp
namespace GestionProduits.ViewModels.Produits
{
    public class ProduitDetailsViewModel
    {
        public int Id { get; set; }
        
        public string Nom { get; set; } = string.Empty;
        
        public string? Description { get; set; }
        
        public decimal Prix { get; set; }
        
        public int QuantiteStock { get; set; }
        
        public DateTime DateCreation { get; set; }

        public int CategorieId { get; set; }
        
        public string NomCategorie { get; set; } = string.Empty;

        public bool EstEnStock => QuantiteStock > 0;
        
        public string PrixFormate => Prix.ToString("C", new System.Globalization.CultureInfo("fr-FR"));
        
        public string DisponibiliteMessage
        {
            get
            {
                if (QuantiteStock == 0) return "Rupture de stock";
                if (QuantiteStock < 5) return $"Plus que {QuantiteStock} en stock !";
                return "En stock";
            }
        }
        
        public string DisponibiliteCssClass
        {
            get
            {
                if (QuantiteStock == 0) return "text-danger";
                if (QuantiteStock < 5) return "text-warning";
                return "text-success";
            }
        }
    }
}
```

**Ce que vous devez comprendre :**
- `PrixFormate` = propriété calculée pour formater le prix en monnaie
- `DisponibiliteMessage` = message dynamique selon le stock
- `DisponibiliteCssClass` = classe CSS pour le style (rouge/orange/vert)
- `NomCategorie` = nom de la catégorie (pas l'objet complet)

#### Étape 2.3 : Créer le ViewModel `ProduitListItemViewModel`

**POURQUOI créer ce ViewModel ?**
- **Bonne pratique stricte** : Ne jamais passer un Model directement à une vue
- **Liste simplifiée** : contient uniquement les données nécessaires pour la liste
- **Formatage** : propriétés formatées pour l'affichage (prix formaté)
- **Sécurité** : n'expose pas toutes les propriétés du Model

**Action à faire :**
1. Créez le fichier `ViewModels/Produits/ProduitListItemViewModel.cs`

**Contenu exact du fichier `ViewModels/Produits/ProduitListItemViewModel.cs` :**

```csharp
namespace GestionProduits.ViewModels.Produits
{
    public class ProduitListItemViewModel
    {
        public int Id { get; set; }
        
        public string Nom { get; set; } = string.Empty;
        
        public decimal Prix { get; set; }
        
        public int QuantiteStock { get; set; }
        
        public string NomCategorie { get; set; } = string.Empty;

        public string PrixFormate => Prix.ToString("C", new System.Globalization.CultureInfo("fr-FR"));
        
        public bool EstEnStock => QuantiteStock > 0;
    }
}
```

**Ce que vous devez comprendre :**
- `PrixFormate` = propriété calculée pour formater le prix en monnaie
- `EstEnStock` = propriété calculée pour savoir si le produit est en stock
- `NomCategorie` = nom de la catégorie (pas l'objet complet)
- **Bonne pratique** : Utiliser un ViewModel même pour les listes simples

---

### Partie 3 : Créer les Extensions de Mapping

**POURQUOI créer ces Extensions ?**
- **Réutilisabilité** : logique de mapping centralisée
- **Maintenabilité** : un seul endroit pour modifier le mapping
- **Lisibilité** : code plus propre dans le Controller
- **Testabilité** : facile à tester

#### Étape 3.1 : Créer l'Extension `ProduitMappingExtensions`

**Action à faire :**
1. Créez le dossier `Extensions/` s'il n'existe pas
2. Créez le fichier `Extensions/ProduitMappingExtensions.cs`

**Contenu exact du fichier `Extensions/ProduitMappingExtensions.cs` :**

```csharp
using GestionProduits.Models;
using GestionProduits.ViewModels.Produits;

namespace GestionProduits.Extensions
{
    public static class ProduitMappingExtensions
    {
        public static ProduitFormViewModel ToFormViewModel(this Produit produit)
        {
            return new ProduitFormViewModel
            {
                Id = produit.Id,
                Nom = produit.Nom,
                Description = produit.Description,
                Prix = produit.Prix,
                QuantiteStock = produit.QuantiteStock,
                CategorieId = produit.CategorieId
            };
        }

        public static Produit ToModel(this ProduitFormViewModel viewModel)
        {
            return new Produit
            {
                Id = viewModel.Id ?? 0,
                Nom = viewModel.Nom,
                Description = viewModel.Description,
                Prix = viewModel.Prix,
                QuantiteStock = viewModel.QuantiteStock,
                CategorieId = viewModel.CategorieId
            };
        }

        public static ProduitDetailsViewModel ToDetails(this Produit produit)
        {
            return new ProduitDetailsViewModel
            {
                Id = produit.Id,
                Nom = produit.Nom,
                Description = produit.Description,
                Prix = produit.Prix,
                QuantiteStock = produit.QuantiteStock,
                DateCreation = produit.DateCreation,
                CategorieId = produit.CategorieId,
                NomCategorie = produit.Categorie?.Nom ?? "Sans catégorie"
            };
        }

        public static ProduitListItemViewModel ToListItem(this Produit produit)
        {
            return new ProduitListItemViewModel
            {
                Id = produit.Id,
                Nom = produit.Nom,
                Prix = produit.Prix,
                QuantiteStock = produit.QuantiteStock,
                NomCategorie = produit.Categorie?.Nom ?? "Sans catégorie"
            };
        }
    }
}
```

**Ce que vous devez comprendre :**
- `this Produit produit` = méthode d'extension (syntaxe spéciale)
- `??` = null-coalescing operator (si null, utilise la valeur par défaut)
- `ToFormViewModel()` = transforme Model → ViewModel (formulaire)
- `ToModel()` = transforme ViewModel → Model
- `ToDetails()` = transforme Model → ViewModel Details
- `ToListItem()` = transforme Model → ViewModel Liste

---

### Partie 4 : Créer le Controller avec toutes les actions CRUD

**POURQUOI créer ce fichier ?**
- **Gère toutes les opérations CRUD** : Create, Read (Index/Details), Update (Edit), Delete
- **Utilise les ViewModels** : passe les ViewModels aux vues
- **Utilise les Extensions** : transforme Model ↔ ViewModel
- **Logique métier** : gère l'ajout, modification, suppression des produits

#### Étape 4.1 : Créer le Controller `ProduitsController`

**Action à faire :**
1. Créez le fichier `Controllers/ProduitsController.cs`

**Contenu exact du fichier `Controllers/ProduitsController.cs` :**

```csharp
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using GestionProduits.Models;
using GestionProduits.ViewModels.Produits;
using GestionProduits.Extensions;

namespace GestionProduits.Controllers
{
    public class ProduitsController : Controller
    {
        private static readonly List<Categorie> _categories = new()
        {
            new() { Id = 1, Nom = "Informatique" },
            new() { Id = 2, Nom = "Accessoires" },
            new() { Id = 3, Nom = "Périphériques" }
        };

        private static readonly List<Produit> _produits = new()
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

        public IActionResult Index()
        {
            var viewModels = _produits.Select(p => p.ToListItem()).ToList();
            return View(viewModels);
        }

        public IActionResult Details(int id)
        {
            var produit = _produits.FirstOrDefault(p => p.Id == id);
            
            if (produit == null)
            {
                return NotFound();
            }
            
            var viewModel = produit.ToDetails();
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new ProduitFormViewModel
            {
                CategoriesSelectList = new SelectList(_categories, "Id", "Nom")
            };
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProduitFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.CategoriesSelectList = new SelectList(_categories, "Id", "Nom");
                return View(viewModel);
            }
            
            var nouveauProduit = viewModel.ToModel();
            nouveauProduit.Id = _produits.Count > 0 ? _produits.Max(p => p.Id) + 1 : 1;
            nouveauProduit.DateCreation = DateTime.UtcNow;
            nouveauProduit.Categorie = _categories.FirstOrDefault(c => c.Id == nouveauProduit.CategorieId);
            _produits.Add(nouveauProduit);
            
            TempData["Success"] = "Produit créé avec succès !";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var produit = _produits.FirstOrDefault(p => p.Id == id);
            
            if (produit == null)
            {
                return NotFound();
            }
            
            var viewModel = produit.ToFormViewModel();
            viewModel.CategoriesSelectList = new SelectList(_categories, "Id", "Nom", produit.CategorieId);
            
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProduitFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                //ce qui nous permet de selectionner.
                viewModel.CategoriesSelectList = new SelectList(_categories, "Id", "Nom", viewModel.CategorieId);
                return View(viewModel);
            }
            
            var produit = _produits.FirstOrDefault(p => p.Id == id);
            
            if (produit == null)
            {
                return NotFound();
            }
            
            var index = _produits.FindIndex(p => p.Id == id);
            var produitModifie = viewModel.ToModel();
            produitModifie.Id = id;
            produitModifie.DateCreation = produit.DateCreation;
            produitModifie.Categorie = _categories.FirstOrDefault(c => c.Id == produitModifie.CategorieId);
            _produits[index] = produitModifie;
            
            TempData["Success"] = "Produit modifié avec succès !";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var produit = _produits.FirstOrDefault(p => p.Id == id);
            
            if (produit == null)
            {
                return NotFound();
            }
            
            var viewModel = produit.ToDetails();
            return View(viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var produit = _produits.FirstOrDefault(p => p.Id == id);
            
            if (produit == null)
            {
                return NotFound();
            }
            
            _produits.RemoveAll(p => p.Id == id);
            TempData["Success"] = "Produit supprimé avec succès !";
            return RedirectToAction("Index");
        }
    }
}
```

**Ce que vous devez comprendre :**
- `ModelState.IsValid` = vérifie la validation des Data Annotations
- `viewModel.ToModel()` = transforme ViewModel → Model avec l'extension
- `produit.ToFormViewModel()` = transforme Model → ViewModel (formulaire) avec l'extension
- `produit.ToDetails()` = transforme Model → ViewModel (détails) avec l'extension
- `produit.ToListItem()` = transforme Model → ViewModel (liste) avec l'extension
- `SelectList` = crée un dropdown pour les catégories
- `TempData` = messages qui persistent entre deux requêtes (redirections)

---

### Partie 5 : Créer les Vues

**Différence avec l'exercice Views :**
- **Exercice Views** : `@model dynamic` ou `@model List<dynamic>`
- **Cet exercice** : `@model ProduitFormViewModel`, `@model ProduitDetailsViewModel`, `@model List<ProduitListItemViewModel>`, etc.
- **Bonne pratique stricte** : Toutes les vues utilisent des ViewModels, même pour les listes simples

#### Étape 5.1 : Créer la vue Index

**Action à faire :**
1. Créez le dossier `Views/Produits/` s'il n'existe pas
2. Créez le fichier `Views/Produits/Index.cshtml`

**Contenu exact du fichier `Views/Produits/Index.cshtml` :**

```html
@model List<GestionProduits.ViewModels.Produits.ProduitListItemViewModel>

@{
    ViewData["Title"] = "Liste des produits";
}

@if (TempData["Success"] != null)
{
    <div class="alert alert-success alert-dismissible fade show" role="alert">
        <strong>Succès !</strong> @TempData["Success"]
        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
    </div>
}

<div class="d-flex justify-content-between align-items-center mb-4">
    <h1>Liste des produits</h1>
    <a asp-controller="Produits" asp-action="Create" class="btn btn-primary">
        Nouveau produit
    </a>
</div>

@if (Model != null && Model.Count > 0)
{
    <table class="table table-striped table-hover table-bordered">
        <thead class="table-dark">
            <tr>
                <th>ID</th>
                <th>Nom</th>
                <th>Prix</th>
                <th>Catégorie</th>
                <th>Stock</th>
                <th>Actions</th>
            </tr>
        </thead>
        <tbody>
            @foreach (var produit in Model)
            {
                <tr>
                    <td>@produit.Id</td>
                    <td>@produit.Nom</td>
                    <td>@produit.PrixFormate</td>
                    <td>@produit.NomCategorie</td>
                    <td>
                        @if (produit.EstEnStock)
                        {
                            <span class="badge bg-success">En stock</span>
                        }
                        else
                        {
                            <span class="badge bg-danger">Rupture</span>
                        }
                    </td>
                    <td>
                        <div class="btn-group" role="group">
                            <a asp-action="Details" asp-route-id="@produit.Id" class="btn btn-sm btn-info">
                                Voir
                            </a>
                            <a asp-action="Edit" asp-route-id="@produit.Id" class="btn btn-sm btn-warning">
                                Modifier
                            </a>
                            <button type="button" class="btn btn-sm btn-danger" data-bs-toggle="modal" data-bs-target="#deleteModal@(produit.Id)">
                                Supprimer
                            </button>
                        </div>
                    </td>
                </tr>
            }
        </tbody>
    </table>
}
else
{
    <div class="alert alert-info">
        <p>Aucun produit disponible. <a asp-action="Create">Créez-en un maintenant !</a></p>
    </div>
}

@foreach (var produit in Model)
{
    <div class="modal fade" id="deleteModal@(produit.Id)" tabindex="-1" aria-labelledby="deleteModalLabel@(produit.Id)" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header bg-danger text-white">
                    <h5 class="modal-title" id="deleteModalLabel@(produit.Id)">
                        Confirmer la suppression
                    </h5>
                    <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body">
                    <p>Êtes-vous sûr de vouloir supprimer le produit <strong>@produit.Nom</strong> ?</p>
                    <p class="text-danger"><strong>Cette action est irréversible.</strong></p>
                </div>
                <div class="modal-footer">
                    <form asp-action="Delete" asp-route-id="@produit.Id" method="post" style="display: inline;">
                        @Html.AntiForgeryToken()
                        <button type="submit" class="btn btn-danger">
                            Oui, supprimer
                        </button>
                    </form>
                    <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">
                        Annuler
                    </button>
                </div>
            </div>
        </div>
    </div>
}
```

**Ce que vous devez comprendre :**
- `@model List<ProduitListItemViewModel>` = déclare le type de ViewModel (bonne pratique stricte)
- `@produit.PrixFormate` = propriété calculée du ViewModel (prix formaté)
- `@produit.NomCategorie` = nom de la catégorie depuis le ViewModel (relation résolue)
- `@produit.EstEnStock` = propriété calculée du ViewModel
- **Bonne pratique** : Même pour les listes simples, utiliser un ViewModel au lieu du Model

---

#### Étape 5.2 : Créer la vue Details

**Action à faire :**
1. Créez le fichier `Views/Produits/Details.cshtml`

**Contenu exact du fichier `Views/Produits/Details.cshtml` :**

```html
@model GestionProduits.ViewModels.Produits.ProduitDetailsViewModel

@{
    ViewData["Title"] = $"Détails - {Model.Nom}";
}

<div class="d-flex justify-content-between align-items-center mb-4">
    <h1>Détails du produit</h1>
    <div>
        <a asp-action="Index" class="btn btn-secondary">Retour à la liste</a>
        <a asp-action="Edit" asp-route-id="@Model.Id" class="btn btn-warning">Modifier</a>
        <button type="button" class="btn btn-danger" data-bs-toggle="modal" data-bs-target="#deleteModal">
            Supprimer
        </button>
    </div>
</div>

<div class="card">
    <div class="card-header bg-primary text-white">
        <h2 class="mb-0">@Model.Nom</h2>
    </div>
    <div class="card-body">
        <div class="row">
            <div class="col-md-6">
                <dl class="row">
                    <dt class="col-sm-4">ID :</dt>
                    <dd class="col-sm-8">@Model.Id</dd>
                    
                    <dt class="col-sm-4">Nom :</dt>
                    <dd class="col-sm-8">@Model.Nom</dd>
                    
                    <dt class="col-sm-4">Prix :</dt>
                    <dd class="col-sm-8"><strong class="text-success">@Model.PrixFormate</strong></dd>
                    
                    <dt class="col-sm-4">Catégorie :</dt>
                    <dd class="col-sm-8"><span class="badge bg-info">@Model.NomCategorie</span></dd>
                </dl>
            </div>
            <div class="col-md-6">
                <dl class="row">
                    <dt class="col-sm-4">Stock :</dt>
                    <dd class="col-sm-8">
                        @if (Model.EstEnStock)
                        {
                            <span class="badge bg-success">En stock</span>
                        }
                        else
                        {
                            <span class="badge bg-danger">Rupture de stock</span>
                        }
                    </dd>
                    
                    <dt class="col-sm-4">Disponibilité :</dt>
                    <dd class="col-sm-8">
                        <span class="@Model.DisponibiliteCssClass">@Model.DisponibiliteMessage</span>
                    </dd>
                    
                    <dt class="col-sm-4">Description :</dt>
                    <dd class="col-sm-8">
                        @if (!string.IsNullOrEmpty(Model.Description))
                        {
                            @Model.Description
                        }
                        else
                        {
                            <span class="text-muted">Aucune description</span>
                        }
                    </dd>
                    
                    <dt class="col-sm-4">Date de création :</dt>
                    <dd class="col-sm-8">@Model.DateCreation.ToString("dd/MM/yyyy")</dd>
                </dl>
            </div>
        </div>
    </div>
</div>

<div class="modal fade" id="deleteModal" tabindex="-1" aria-labelledby="deleteModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header bg-danger text-white">
                <h5 class="modal-title" id="deleteModalLabel">
                    Confirmer la suppression
                </h5>
                <button type="button" class="btn-close btn-close-white" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <p>Êtes-vous sûr de vouloir supprimer le produit <strong>@Model.Nom</strong> ?</p>
                <p class="text-danger"><strong>Cette action est irréversible.</strong></p>
            </div>
            <div class="modal-footer">
                <form asp-action="Delete" asp-route-id="@Model.Id" method="post" style="display: inline;">
                    @Html.AntiForgeryToken()
                    <button type="submit" class="btn btn-danger">
                        Oui, supprimer
                    </button>
                </form>
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">
                    Annuler
                </button>
            </div>
        </div>
    </div>
</div>
```

**Ce que vous devez comprendre :**
- `@model ProduitDetailsViewModel` = déclare le ViewModel typé
- `@Model.PrixFormate` = propriété calculée du ViewModel (formatée)
- `@Model.DisponibiliteMessage` = message dynamique selon le stock
- `@Model.DisponibiliteCssClass` = classe CSS pour le style
- `data-bs-toggle="modal"` = active la popup Bootstrap au clic
- `data-bs-target="#deleteModal"` = pointe vers la popup spécifique
- Le formulaire dans la popup soumet directement la suppression (pas besoin de page séparée)

---

#### Étape 5.3 : Créer la vue Create

**Action à faire :**
1. Créez le fichier `Views/Produits/Create.cshtml`

**Contenu exact du fichier `Views/Produits/Create.cshtml` :**

```html
@model GestionProduits.ViewModels.Produits.ProduitFormViewModel

@{
    ViewData["Title"] = "Nouveau produit";
}

<h1>Créer un nouveau produit</h1>

<div class="row">
    <div class="col-md-8">
        <form asp-action="Create" method="post">
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(true, "", new { @class = "text-danger" })
            
            <div class="mb-3">
                <label asp-for="Nom" class="form-label"></label>
                <input asp-for="Nom" class="form-control" />
                <span asp-validation-for="Nom" class="text-danger"></span>
            </div>
            
            <div class="mb-3">
                <label asp-for="Description" class="form-label"></label>
                <textarea asp-for="Description" class="form-control" rows="4"></textarea>
                <span asp-validation-for="Description" class="text-danger"></span>
            </div>
            
            <div class="mb-3">
                <label asp-for="Prix" class="form-label"></label>
                <input asp-for="Prix" class="form-control" type="number" step="0.01" min="0.01" />
                <span asp-validation-for="Prix" class="text-danger"></span>
            </div>
            
            <div class="mb-3">
                <label asp-for="QuantiteStock" class="form-label"></label>
                <input asp-for="QuantiteStock" class="form-control" type="number" min="0" />
                <span asp-validation-for="QuantiteStock" class="text-danger"></span>
            </div>
            
            <div class="mb-3">
                <label asp-for="CategorieId" class="form-label"></label>
                <select asp-for="CategorieId" asp-items="Model.CategoriesSelectList" class="form-select">
                    <option value="">Sélectionnez une catégorie</option>
                </select>
                <span asp-validation-for="CategorieId" class="text-danger"></span>
            </div>
            
            <div class="mt-4">
                <button type="submit" class="btn btn-primary">Créer le produit</button>
                <a asp-action="Index" class="btn btn-secondary">Annuler</a>
            </div>
        </form>
    </div>
</div>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
```

**Ce que vous devez comprendre :**
- `@model ProduitFormViewModel` = déclare le ViewModel typé
- `asp-for="Nom"` = Tag Helper qui génère automatiquement le name et l'id
- `asp-validation-for="Nom"` = affiche les erreurs de validation
- `asp-items="Model.CategoriesSelectList"` = utilise le SelectList du ViewModel
- `_ValidationScriptsPartial` = scripts jQuery pour la validation côté client

---

#### Étape 5.4 : Créer la vue Edit

**Action à faire :**
1. Créez le fichier `Views/Produits/Edit.cshtml`

**Contenu exact du fichier `Views/Produits/Edit.cshtml` :**

```html
@model GestionProduits.ViewModels.Produits.ProduitFormViewModel

@{
    ViewData["Title"] = $"Modifier - {Model.Nom}";
}

<h1>Modifier le produit</h1>

<div class="row">
    <div class="col-md-8">
        <form asp-action="Edit" asp-route-id="@Model.Id" method="post">
            @Html.AntiForgeryToken()
            @Html.ValidationSummary(true, "", new { @class = "text-danger" })
            
            <div class="mb-3">
                <label asp-for="Nom" class="form-label"></label>
                <input asp-for="Nom" class="form-control" />
                <span asp-validation-for="Nom" class="text-danger"></span>
            </div>
            
            <div class="mb-3">
                <label asp-for="Description" class="form-label"></label>
                <textarea asp-for="Description" class="form-control" rows="4"></textarea>
                <span asp-validation-for="Description" class="text-danger"></span>
            </div>
            
            <div class="mb-3">
                <label asp-for="Prix" class="form-label"></label>
                <input asp-for="Prix" class="form-control" type="number" step="0.01" min="0.01" />
                <span asp-validation-for="Prix" class="text-danger"></span>
            </div>
            
            <div class="mb-3">
                <label asp-for="QuantiteStock" class="form-label"></label>
                <input asp-for="QuantiteStock" class="form-control" type="number" min="0" />
                <span asp-validation-for="QuantiteStock" class="text-danger"></span>
            </div>
            
            <div class="mb-3">
                <label asp-for="CategorieId" class="form-label"></label>
                <select asp-for="CategorieId" asp-items="Model.CategoriesSelectList" class="form-select">
                    <option value="">Sélectionnez une catégorie</option>
                </select>
                <span asp-validation-for="CategorieId" class="text-danger"></span>
            </div>
            
            <div class="mt-4">
                <button type="submit" class="btn btn-warning">Enregistrer les modifications</button>
                <a asp-action="Index" class="btn btn-secondary">Annuler</a>
            </div>
        </form>
    </div>
</div>

@section Scripts {
    @{await Html.RenderPartialAsync("_ValidationScriptsPartial");}
}
```

**Ce que vous devez comprendre :**
- Même structure que Create, mais avec `asp-route-id="@Model.Id"`
- Les champs sont pré-remplis automatiquement grâce au Model Binding
- La validation fonctionne de la même manière

---

#### Étape 5.5 : Note sur la suppression avec Modal Bootstrap

**POURQUOI utiliser un modal au lieu d'une page séparée ?**
- **Meilleure UX** : pas besoin de changer de page pour supprimer
- **Plus rapide** : popup instantanée
- **Moderne** : interface professionnelle avec Bootstrap Modal
- **Cohérent** : même approche dans Index et Details

**Où sont les modals ?**
- **Dans Index.cshtml** : modal pour chaque produit
- **Dans Details.cshtml** : modal unique pour le produit affiché

**Note importante :**
- La vue `Delete.cshtml` n'est **pas nécessaire** avec cette approche
- Le Controller garde l'action `DeleteConfirmed` (POST) qui traite la suppression
- L'action `Delete` (GET) peut être supprimée du Controller si vous n'utilisez que les modals

---

### Critères de validation

Après avoir terminé toutes les parties, vérifiez que :

- Les Models contiennent uniquement la structure BDD (sans Data Annotations de validation)
- Les ViewModels sont bien structurés avec les propriétés nécessaires et toutes les Data Annotations
- Les Extensions de mapping fonctionnent (Model ↔ ViewModel)
- Le Controller utilise les ViewModels et les Extensions
- La page Index affiche les produits dans un tableau (utilise `ProduitListItemViewModel`)
- La page Details affiche tous les détails avec le ViewModel
- La page Create permet de créer un nouveau produit avec validation
- La page Edit permet de modifier un produit avec validation
- La fonctionnalité Delete fonctionne avec modal Bootstrap de confirmation (dans Index et Details)
- La validation côté serveur fonctionne (Data Annotations)
- La validation côté client fonctionne (jQuery unobtrusive)
- Tous les liens de navigation fonctionnent
- Les messages de succès s'affichent après chaque action

**Si vous avez des erreurs :**
- Vérifiez que tous les using sont présents
- Vérifiez que les ViewModels sont bien dans le bon namespace
- Vérifiez que les Extensions sont bien dans le bon namespace
- Vérifiez que `_ValidationScriptsPartial` est présent dans `Views/Shared/`

---

## Félicitations !

Vous avez créé une application CRUD complète avec Models et ViewModels ! Vous maîtrisez maintenant :

- **Models** : Structure métier / BDD (sans validation formulaire)
- **ViewModels** : Validation + affichage (Data Annotations pour les formulaires)
- **Extensions** : Mapping Model ↔ ViewModel
- **CRUD complet** : Create, Read (Index/Details), Update (Edit), Delete
- **Validation** : Côté serveur (Data Annotations) et côté client (jQuery)
- **Séparation des responsabilités** : Model = données, ViewModel = présentation

**Différence avec l'exercice Views :**
- **Exercice Views** : `IFormCollection` et objets anonymes (méthode simple)
- **Cet exercice** : Models typés et ViewModels (méthode professionnelle)

**Prochaine étape :** Vous pouvez maintenant passer au module suivant sur les Formulaires pour approfondir la validation et les Tag Helpers !

---

## Points clés à retenir

```
┌────────────────────────────────────────────────────────────┐
│                    À RETENIR                               │
├────────────────────────────────────────────────────────────┤
│                                                            │
│  • Model = Structure métier / BDD                         │
│    (sans Data Annotations de validation)                  │
│                                                            │
│  • ViewModel = Validation + affichage                     │
│    (Data Annotations pour formulaires, propriétés          │
│     formatées, SelectList, etc.)                          │
│                                                            │
│  • Extension = Méthodes de mapping Model ↔ ViewModel      │
│    (centralise la logique de transformation)              │
│                                                            │
│  • ModelState.IsValid = vérifie la validation            │
│    (Data Annotations)                                      │
│                                                            │
│  • asp-for = Tag Helper pour générer les champs           │
│    (avec validation automatique)                           │
│                                                            │
│  • asp-validation-for = affiche les erreurs               │
│    (validation côté client et serveur)                    │
│                                                            │
│  • SelectList = dropdown pour les catégories              │
│    (rempli dans le Controller)                             │
│                                                            │
└────────────────────────────────────────────────────────────┘
```

---

Vous avez terminé l'exercice complet sur les Models et ViewModels ! Vous maîtrisez maintenant la séparation des responsabilités et les bonnes pratiques ASP.NET Core MVC !
