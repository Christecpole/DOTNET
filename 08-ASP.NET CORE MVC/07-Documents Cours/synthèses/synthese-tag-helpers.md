# Tag Helpers - Synthèse

## Contexte

Les Tag Helpers sont des attributs HTML spéciaux (commençant par `asp-`) qui génèrent automatiquement le HTML correct. Ils simplifient la création de liens, formulaires et autres éléments interactifs en générant automatiquement les URLs, les attributs `id`, `name`, etc.

---

## Activation

### Scénario
Pour utiliser les Tag Helpers, vous devez les activer dans `_ViewImports.cshtml`.

### Pas à pas
1. Ouvrez `Views/_ViewImports.cshtml`
2. Ajoutez `@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers`
3. Les Tag Helpers sont maintenant disponibles dans toutes les vues

### Syntaxe
```html
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers
```

---

## Liens (Anchor Tag Helper)

### Scénario : Lien simple
Vous voulez créer un lien vers une page de votre application.

### Pas à pas
1. Utilisez `<a>` avec `asp-controller` et `asp-action`
2. Le Tag Helper génère automatiquement l'URL correcte

### Syntaxe
```html
<a asp-controller="Product" asp-action="Index">Produits</a>
```

---

### Scénario : Lien avec paramètre
Vous voulez passer un paramètre dans l'URL (ex: ID d'un produit).

### Pas à pas
1. Utilisez `asp-route-id="5"` pour passer le paramètre `id`
2. Le nom après `asp-route-` doit correspondre au paramètre de route

### Syntaxe
```html
<a asp-controller="Product" asp-action="Details" asp-route-id="5">
    Voir détails
</a>
```

---

### Scénario : Lien avec plusieurs paramètres
Vous voulez passer plusieurs paramètres dans l'URL.

### Pas à pas
1. Utilisez plusieurs `asp-route-*` (remplacez * par le nom du paramètre)
2. Chaque paramètre sera ajouté à l'URL

### Syntaxe
```html
<a asp-controller="Product" 
   asp-action="List" 
   asp-route-category="Electronics" 
   asp-route-sort="price">
    Produits Électroniques
</a>
```

---

### Scénario : Lien avec variable
Vous voulez utiliser une variable C# dans l'URL.

### Pas à pas
1. Déclarez la variable dans un bloc `@{}`
2. Utilisez `@variable` dans `asp-route-id`

### Syntaxe
```html
@{
    var productId = 5;
}
<a asp-controller="Product" asp-action="Details" asp-route-id="@productId">
    Voir détails
</a>
```

---

## Formulaires (Form Tag Helper)

### Scénario : Formulaire de base
Vous créez un formulaire qui envoie des données au serveur.

### Pas à pas
1. Utilisez `<form>` avec `asp-controller` et `asp-action`
2. Ajoutez `method="post"`
3. Le Tag Helper génère automatiquement l'attribut `action`

### Syntaxe
```html
<form asp-controller="Product" asp-action="Create" method="post">
    @Html.AntiForgeryToken()
    <!-- champs -->
</form>
```

---

### Scénario : Formulaire avec route
Vous créez un formulaire d'édition qui doit passer l'ID du produit.

### Pas à pas
1. Utilisez `asp-route-id="@Model.Id"` dans le formulaire
2. L'ID sera inclus dans l'URL

### Syntaxe
```html
<form asp-action="Edit" asp-route-id="@Model.Id" method="post">
    @Html.AntiForgeryToken()
    <!-- champs -->
</form>
```

---

## Input Tag Helper

### Scénario : Input texte
Vous créez un champ de saisie texte lié à une propriété du modèle.

### Pas à pas
1. Utilisez `<input asp-for="Name">`
2. Le Tag Helper génère automatiquement `id`, `name`, `type` et `value`

### Syntaxe
```html
<input asp-for="Name" class="form-control" />
```

Génère :
```html
<input type="text" id="Name" name="Name" value="@Model.Name" class="form-control" />
```

---

### Scénario : Input nombre
Vous créez un champ numérique (prix, quantité, etc.).

### Pas à pas
1. Utilisez `<input asp-for="Price">`
2. Si la propriété est `decimal` ou `int`, le Tag Helper génère automatiquement `type="number"`

### Syntaxe
```html
<input asp-for="Price" class="form-control" />
```

---

### Scénario : Input email
Vous créez un champ email.

### Pas à pas
1. Utilisez `<input asp-for="Email">`
2. Si la propriété s'appelle `Email`, le Tag Helper génère automatiquement `type="email"`

### Syntaxe
```html
<input asp-for="Email" class="form-control" />
```

---

### Scénario : Input avec valeur
Vous voulez pré-remplir un champ (formulaire d'édition).

### Pas à pas
1. Utilisez `asp-for` avec un modèle qui a déjà une valeur
2. Le Tag Helper génère automatiquement `value="@Model.Name"`

### Syntaxe
```html
<input asp-for="Name" class="form-control" value="@Model.Name" />
```

---

## Label Tag Helper

### Scénario
Vous créez une étiquette pour un champ de formulaire.

### Pas à pas
1. Utilisez `<label asp-for="Name">`
2. Le Tag Helper génère automatiquement le texte du label et l'attribut `for`

### Syntaxe
```html
<label asp-for="Name" class="form-label"></label>
```

---

## Textarea Tag Helper

### Scénario
Vous créez un champ multiligne pour une description.

### Pas à pas
1. Utilisez `<textarea asp-for="Description">`
2. Le Tag Helper génère automatiquement `id`, `name` et le contenu

### Syntaxe
```html
<textarea asp-for="Description" class="form-control"></textarea>
```

---

## Select Tag Helper

### Scénario : Select avec ViewBag
Vous créez une liste déroulante remplie depuis le contrôleur.

### Pas à pas
1. Dans le contrôleur, remplissez `ViewBag.Categories` avec une liste de `SelectListItem`
2. Dans la vue, utilisez `asp-items="ViewBag.Categories"`
3. Ajoutez une option par défaut

### Syntaxe
```html
<select asp-for="Category" asp-items="ViewBag.Categories" class="form-select">
    <option value="">-- Choisir --</option>
</select>
```

---

### Scénario : Remplir ViewBag dans le contrôleur
Vous préparez les options de la liste déroulante.

### Pas à pas
1. Créez une liste de `SelectListItem`
2. Assignez-la à `ViewBag.Categories`
3. Chaque `SelectListItem` a une `Value` et un `Text`

### Syntaxe
```csharp
ViewBag.Categories = new List<SelectListItem>
{
    new SelectListItem { Value = "FR", Text = "France" },
    new SelectListItem { Value = "BE", Text = "Belgique" }
};
```

---

### Scénario : Select avec enum
Vous voulez remplir une liste déroulante avec les valeurs d'un enum.

### Pas à pas
1. Utilisez `Html.GetEnumSelectList<Status>()`
2. Le Tag Helper génère automatiquement les options

### Syntaxe
```html
<select asp-for="Status" asp-items="Html.GetEnumSelectList<Status>()" class="form-select">
    <option value="">-- Choisir --</option>
</select>
```

---

## Image Tag Helper

### Scénario
Vous voulez afficher une image avec cache busting (forcer le rechargement si l'image change).

### Pas à pas
1. Utilisez `asp-append-version="true"`
2. Le Tag Helper ajoute un hash au nom du fichier

### Syntaxe
```html
<img src="~/images/logo.png" asp-append-version="true" alt="Logo" />
```

---

## Environment Tag Helper

### Scénario
Vous voulez charger des fichiers différents selon l'environnement (développement ou production).

### Pas à pas
1. Utilisez `<environment include="Development">` pour le développement
2. Utilisez `<environment exclude="Development">` pour la production

### Syntaxe
```html
<environment include="Development">
    <link rel="stylesheet" href="~/css/site.css" />
</environment>

<environment exclude="Development">
    <link rel="stylesheet" href="~/css/site.min.css" />
</environment>
```

---

## Partial Tag Helper

### Scénario : Appeler une Partial View
Vous voulez inclure une Partial View dans votre vue.

### Pas à pas
1. Utilisez `<partial name="_ProductCard" model="product" />`
2. `name` = nom de la Partial View (sans extension)
3. `model` = données à passer (optionnel)

### Syntaxe
```html
<partial name="_ProductCard" model="product" />
```

---

### Scénario : Sans modèle
La Partial View n'a pas besoin de données.

### Pas à pas
1. Omettez l'attribut `model`

### Syntaxe
```html
<partial name="_NavigationMenu" />
```

---

## Validation Tag Helper

### Scénario : Afficher les erreurs
Vous voulez afficher les erreurs de validation pour un champ spécifique.

### Pas à pas
1. Utilisez `<span asp-validation-for="Name">`
2. Les erreurs s'affichent automatiquement si la validation échoue

### Syntaxe
```html
<span asp-validation-for="Name" class="text-danger"></span>
```

---

### Scénario : Résumé des erreurs
Vous voulez afficher toutes les erreurs de validation en haut du formulaire.

### Pas à pas
1. Utilisez `<div asp-validation-summary="All">`
2. Toutes les erreurs s'affichent dans un résumé

### Syntaxe
```html
<div asp-validation-summary="All" class="text-danger"></div>
```

---

## Exemples complets

### Scénario : Formulaire complet avec Tag Helpers
Vous créez un formulaire de création complet avec tous les types de champs et la validation.

### Pas à pas
1. Déclarez `@model Product`
2. Créez le formulaire avec tous les champs
3. Ajoutez les Tag Helpers de validation

### Syntaxe
```html
@model Product

<form asp-controller="Product" asp-action="Create" method="post">
    @Html.AntiForgeryToken()
    
    <div class="mb-3">
        <label asp-for="Name" class="form-label"></label>
        <input asp-for="Name" class="form-control" />
        <span asp-validation-for="Name" class="text-danger"></span>
    </div>
    
    <div class="mb-3">
        <label asp-for="Price" class="form-label"></label>
        <input asp-for="Price" class="form-control" />
        <span asp-validation-for="Price" class="text-danger"></span>
    </div>
    
    <div class="mb-3">
        <label asp-for="Category" class="form-label"></label>
        <select asp-for="Category" asp-items="ViewBag.Categories" class="form-select">
            <option value="">-- Choisir --</option>
        </select>
    </div>
    
    <button type="submit" class="btn btn-primary">Créer</button>
    <a asp-action="Index" class="btn btn-secondary">Annuler</a>
</form>
```

---

### Scénario : Liste avec liens
Vous affichez une liste de produits avec des liens vers les actions (détails, modifier).

### Pas à pas
1. Utilisez `@foreach` pour parcourir la liste
2. Créez des liens avec `asp-action` et `asp-route-id`

### Syntaxe
```html
@model List<Product>

@foreach (var product in Model)
{
    <div>
        <h3>@product.Name</h3>
        <a asp-controller="Product" 
           asp-action="Details" 
           asp-route-id="@product.Id" 
           class="btn btn-primary">
            Voir détails
        </a>
        <a asp-controller="Product" 
           asp-action="Edit" 
           asp-route-id="@product.Id" 
           class="btn btn-warning">
            Modifier
        </a>
    </div>
}
```

---

## Désactiver un Tag Helper

### Scénario
Vous voulez utiliser du HTML pur sans que les Tag Helpers soient interprétés.

### Pas à pas
1. Ajoutez le préfixe `!` avant la balise

### Syntaxe
```html
<!a asp-controller="Product" asp-action="Index">Lien sans Tag Helper</a>
```

---

## Attributs générés automatiquement

### Scénario : Avec asp-for="Name"
Le Tag Helper génère automatiquement tous les attributs nécessaires.

### Résultat
```html
<input asp-for="Name" class="form-control" />
```

Génère :
```html
<input type="text" id="Name" name="Name" value="@Model.Name" class="form-control" />
```

---

### Scénario : Avec asp-controller et asp-action
Le Tag Helper génère l'URL correcte selon vos routes.

### Résultat
```html
<a asp-controller="Product" asp-action="Details" asp-route-id="5">Détails</a>
```

Génère :
```html
<a href="/Product/Details/5">Détails</a>
```
