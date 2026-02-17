# Comment créer une vue - Synthèse

## Contexte

Une vue est un fichier `.cshtml` qui génère du HTML pour afficher les données passées par le contrôleur. Les vues sont organisées dans des dossiers correspondant aux contrôleurs.

---

## Structure de base

### Scénario : Vue simple sans modèle
Vous créez une page statique ou une page qui n'a pas besoin de données du contrôleur.

### Pas à pas
1. Créez le fichier `.cshtml` dans le bon dossier
2. Définissez `ViewData["Title"]` pour le titre de la page
3. Ajoutez votre contenu HTML

### Syntaxe
```html
@{
    ViewData["Title"] = "Titre de la page";
}

<h1>@ViewData["Title"]</h1>
<p>Contenu de la page</p>
```

---

### Scénario : Vue avec modèle
Le contrôleur vous passe un objet unique (ex: détails d'un produit).

### Pas à pas
1. Déclarez `@model Product` en haut du fichier
2. Définissez `ViewData["Title"]`
3. Utilisez `@Model.PropertyName` pour afficher les propriétés

### Syntaxe
```html
@model Product

@{
    ViewData["Title"] = "Détails du produit";
}

<h1>@Model.Name</h1>
<p>Prix : @Model.Price €</p>
```

---

### Scénario : Vue avec liste
Le contrôleur vous passe une collection d'objets (ex: liste de produits).

### Pas à pas
1. Déclarez `@model List<Product>` en haut
2. Utilisez `@foreach` pour parcourir la liste
3. Utilisez la variable de boucle pour accéder à chaque élément

### Syntaxe
```html
@model List<Product>

@{
    ViewData["Title"] = "Liste des produits";
}

<h1>@ViewData["Title"]</h1>

@foreach (var product in Model)
{
    <p>@product.Name - @product.Price €</p>
}
```

---

## Emplacement des vues

### Scénario
ASP.NET Core cherche les vues dans des dossiers spécifiques selon le contrôleur.

### Structure
```
Views/
├── Home/
│   └── Index.cshtml
├── Product/
│   ├── Index.cshtml
│   ├── Create.cshtml
│   └── Details.cshtml
└── Shared/
    └── _Layout.cshtml
```

### Règle
- Dossier = Nom du contrôleur sans "Controller"
- Fichier = Nom de l'action du contrôleur

---

## Convention de nommage

### Scénario
Pour que ASP.NET Core trouve automatiquement votre vue, respectez les conventions.

### Règle
- Nom du fichier = Nom de l'action du contrôleur
- Dossier = Nom du contrôleur (sans "Controller")
- Exemple : `ProductController.Index()` → `Views/Product/Index.cshtml`

---

## Pas à pas : Créer une vue complète

### Scénario
Vous créez une nouvelle page pour afficher la liste des produits.

### Étape 1 : Créer le dossier
```
Views/Product/
```

### Étape 2 : Créer le fichier
```
Views/Product/Index.cshtml
```

### Étape 3 : Contenu de base
```html
@model List<Product>

@{
    ViewData["Title"] = "Liste des produits";
}

<h1>@ViewData["Title"]</h1>
```

---

## Vue avec tableau

### Scénario
Vous voulez afficher une liste de produits dans un tableau HTML professionnel.

### Pas à pas
1. Déclarez `@model List<Product>`
2. Créez un `<table>` avec `<thead>` et `<tbody>`
3. Utilisez `@foreach` pour créer une ligne par produit
4. Utilisez `.ToString("C")` pour formater le prix

### Syntaxe
```html
@model List<Product>

<table class="table">
    <thead>
        <tr>
            <th>Nom</th>
            <th>Prix</th>
        </tr>
    </thead>
    <tbody>
        @foreach (var product in Model)
        {
            <tr>
                <td>@product.Name</td>
                <td>@product.Price.ToString("C")</td>
            </tr>
        }
    </tbody>
</table>
```

---

## Vue avec conditions

### Scénario
Vous voulez afficher un message si la liste est vide, sinon afficher le tableau.

### Pas à pas
1. Vérifiez si `Model` est null ou vide avec `@if`
2. Affichez un message d'information si vide
3. Affichez le tableau sinon

### Syntaxe
```html
@model List<Product>

@if (Model == null || Model.Count == 0)
{
    <div class="alert alert-info">
        <p>Aucun produit disponible.</p>
    </div>
}
else
{
    <table class="table">
        @foreach (var product in Model)
        {
            <tr>
                <td>@product.Name</td>
            </tr>
        }
    </table>
}
```

---

## Vue avec TempData

### Scénario
Après une action (création, modification), vous voulez afficher un message de succès.

### Pas à pas
1. Vérifiez si `TempData["Success"]` existe avec `@if`
2. Affichez le message dans une alerte Bootstrap

### Syntaxe
```html
@if (TempData["Success"] != null)
{
    <div class="alert alert-success">
        @TempData["Success"]
    </div>
}
```

---

## Vue avec Layout personnalisé

### Scénario
Vous voulez utiliser un Layout différent (ex: Layout Admin) pour certaines pages.

### Pas à pas
1. Définissez `Layout = "_AdminLayout"` dans un bloc `@{}`
2. Le Layout Admin sera utilisé au lieu du Layout par défaut

### Syntaxe
```html
@{
    Layout = "_AdminLayout";
    ViewData["Title"] = "Page admin";
}

<h1>Contenu de la page</h1>
```

---

## Vue sans Layout

### Scénario
Vous créez une page qui ne doit pas utiliser de Layout (ex: page d'impression, API JSON).

### Pas à pas
1. Définissez `Layout = null` dans un bloc `@{}`
2. Écrivez votre HTML complet (avec `<html>`, `<head>`, etc.)

### Syntaxe
```html
@{
    Layout = null;
}

<h1>Page sans Layout</h1>
```

---

## Différence @model vs @Model

### Scénario
Il est important de comprendre la différence entre la déclaration et l'utilisation.

### Règle
- `@model` (minuscule) = **Déclaration du type** en haut du fichier
- `@Model` (majuscule) = **Utilisation de l'objet** dans le reste de la vue

### Syntaxe
```html
@model Product        <!-- Déclaration du type (minuscule) -->
<h1>@Model.Name</h1>  <!-- Utilisation de l'objet (majuscule) -->
```
