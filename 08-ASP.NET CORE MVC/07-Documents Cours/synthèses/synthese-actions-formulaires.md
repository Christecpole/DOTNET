# Méthodes d'action de création et formulaires - Synthèse

## Contexte

Pour créer un formulaire, vous avez besoin de deux actions dans le contrôleur : une action GET pour afficher le formulaire vide, et une action POST pour traiter les données soumises. Les Tag Helpers simplifient la création des formulaires.

---

## Structure du contrôleur

### Scénario : Action GET (Afficher le formulaire)
L'utilisateur accède à la page de création. Vous devez afficher un formulaire vide.

### Pas à pas
1. Créez une méthode `Create()` avec l'attribut `[HttpGet]` (optionnel, GET par défaut)
2. Retournez `View()` pour afficher le formulaire vide
3. Optionnel : passez un modèle vide `View(new Product())`

### Syntaxe
```csharp
[HttpGet]
public IActionResult Create()
{
    return View();
}
```

---

### Scénario : Action POST (Traiter le formulaire)
L'utilisateur soumet le formulaire. Vous devez récupérer les données et les sauvegarder.

### Pas à pas
1. Créez une méthode `Create(Product product)` avec l'attribut `[HttpPost]`
2. Ajoutez `[ValidateAntiForgeryToken]` pour la sécurité CSRF
3. Traitez les données (ajoutez à la liste, sauvegardez en BDD, etc.)
4. Utilisez `TempData` pour un message de succès
5. Redirigez vers `Index` avec `RedirectToAction("Index")`

### Syntaxe
```csharp
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Product product)
{
    _products.Add(product);
    TempData["Success"] = "Produit créé avec succès !";
    return RedirectToAction("Index");
}
```

---

## Formulaire de base

### Scénario
Vous créez un formulaire simple avec un seul champ.

### Pas à pas
1. Utilisez `<form>` avec `asp-controller` et `asp-action`
2. Ajoutez `method="post"`
3. Ajoutez `@Html.AntiForgeryToken()` pour la sécurité
4. Créez les champs avec `asp-for`
5. Ajoutez un bouton `type="submit"`

### Syntaxe
```html
<form asp-controller="Product" asp-action="Create" method="post">
    @Html.AntiForgeryToken()
    
    <div class="mb-3">
        <label asp-for="Name" class="form-label"></label>
        <input asp-for="Name" class="form-control" />
    </div>
    
    <button type="submit" class="btn btn-primary">Créer</button>
</form>
```

---

## Champs de formulaire avec Tag Helpers

### Scénario : Input texte
Vous voulez un champ de saisie texte lié à une propriété du modèle.

### Pas à pas
1. Utilisez `<label asp-for="Name">` pour le label
2. Utilisez `<input asp-for="Name">` pour le champ
3. Ajoutez `class="form-control"` pour le style Bootstrap

### Syntaxe
```html
<div class="mb-3">
    <label asp-for="Name" class="form-label"></label>
    <input asp-for="Name" class="form-control" />
</div>
```

---

### Scénario : Textarea
Vous voulez un champ multiligne pour une description.

### Pas à pas
1. Utilisez `<textarea asp-for="Description">` au lieu de `<input>`
2. Ajoutez `rows="4"` pour définir la hauteur

### Syntaxe
```html
<div class="mb-3">
    <label asp-for="Description" class="form-label"></label>
    <textarea asp-for="Description" class="form-control"></textarea>
</div>
```

---

### Scénario : Input nombre
Vous voulez un champ numérique (prix, quantité, etc.).

### Pas à pas
1. Utilisez `<input asp-for="Price">`
2. Le Tag Helper génère automatiquement `type="number"` si la propriété est numérique

### Syntaxe
```html
<div class="mb-3">
    <label asp-for="Price" class="form-label"></label>
    <input asp-for="Price" class="form-control" />
</div>
```

---

### Scénario : Select (liste déroulante)
Vous voulez une liste déroulante avec des options prédéfinies.

### Pas à pas
1. Dans le contrôleur, remplissez `ViewBag.Categories` avec une liste de `SelectListItem`
2. Dans la vue, utilisez `<select asp-for="Category" asp-items="ViewBag.Categories">`
3. Ajoutez une option par défaut `<option value="">-- Choisir --</option>`

### Syntaxe
```html
<div class="mb-3">
    <label asp-for="Category" class="form-label"></label>
    <select asp-for="Category" asp-items="ViewBag.Categories" class="form-select">
        <option value="">-- Choisir --</option>
    </select>
</div>
```

---

### Scénario : Checkbox
Vous voulez une case à cocher (ex: "En stock").

### Pas à pas
1. Utilisez `<input asp-for="EnStock" type="checkbox">`
2. Enveloppez dans un `<div class="form-check">`
3. Ajoutez un label avec `asp-for`

### Syntaxe
```html
<div class="mb-3">
    <div class="form-check">
        <input asp-for="EnStock" class="form-check-input" />
        <label asp-for="EnStock" class="form-check-label"></label>
    </div>
</div>
```

---

## Remplir un Select dans le contrôleur

### Scénario
Vous devez remplir une liste déroulante avec des options depuis le contrôleur.

### Pas à pas
1. Dans l'action GET `Create()`, créez une liste de `SelectListItem`
2. Assignez-la à `ViewBag.Categories`
3. Dans la vue, utilisez `asp-items="ViewBag.Categories"`

### Syntaxe
```csharp
public IActionResult Create()
{
    ViewBag.Categories = new List<SelectListItem>
    {
        new SelectListItem { Value = "Informatique", Text = "Informatique" },
        new SelectListItem { Value = "Accessoires", Text = "Accessoires" }
    };
    
    return View(new Product());
}
```

---

## Formulaire complet

### Scénario
Vous créez un formulaire de création complet avec tous les types de champs.

### Pas à pas
1. Déclarez `@model Product` en haut
2. Créez le formulaire avec `asp-controller` et `asp-action`
3. Ajoutez tous les champs nécessaires
4. Ajoutez les boutons de soumission et d'annulation

### Syntaxe
```html
@model Product

<form asp-controller="Product" asp-action="Create" method="post">
    @Html.AntiForgeryToken()
    
    <div class="mb-3">
        <label asp-for="Name" class="form-label"></label>
        <input asp-for="Name" class="form-control" />
    </div>
    
    <div class="mb-3">
        <label asp-for="Description" class="form-label"></label>
        <textarea asp-for="Description" class="form-control" rows="4"></textarea>
    </div>
    
    <div class="mb-3">
        <label asp-for="Price" class="form-label"></label>
        <input asp-for="Price" class="form-control" />
    </div>
    
    <div class="mb-3">
        <label asp-for="Category" class="form-label"></label>
        <select asp-for="Category" asp-items="ViewBag.Categories" class="form-select">
            <option value="">-- Choisir --</option>
        </select>
    </div>
    
    <div class="mb-3">
        <div class="form-check">
            <input asp-for="EnStock" class="form-check-input" />
            <label asp-for="EnStock" class="form-check-label">En stock</label>
        </div>
    </div>
    
    <button type="submit" class="btn btn-primary">Créer</button>
    <a asp-action="Index" class="btn btn-secondary">Annuler</a>
</form>
```

---

## Formulaire d'édition

### Scénario
Vous voulez modifier un produit existant. Le formulaire doit être pré-rempli avec les données actuelles.

### Pas à pas : Contrôleur
1. Action GET `Edit(int id)` : récupérez le produit et passez-le à la vue
2. Action POST `Edit(int id, Product product)` : modifiez le produit et redirigez

### Syntaxe : Contrôleur
```csharp
[HttpGet]
public IActionResult Edit(int id)
{
    var product = _products.FirstOrDefault(p => p.Id == id);
    if (product == null)
        return NotFound();
    return View(product);
}

[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Edit(int id, Product product)
{
    var existingProduct = _products.FirstOrDefault(p => p.Id == id);
    if (existingProduct == null)
        return NotFound();
    
    existingProduct.Name = product.Name;
    existingProduct.Price = product.Price;
    
    TempData["Success"] = "Produit modifié avec succès !";
    return RedirectToAction("Index");
}
```

### Pas à pas : Vue Edit
1. Déclarez `@model Product`
2. Utilisez `asp-route-id="@Model.Id"` dans le formulaire
3. Les champs seront automatiquement pré-remplis grâce à `asp-for`

### Syntaxe : Vue Edit
```html
@model Product

<form asp-action="Edit" asp-route-id="@Model.Id" method="post">
    @Html.AntiForgeryToken()
    
    <div class="mb-3">
        <label asp-for="Name" class="form-label"></label>
        <input asp-for="Name" class="form-control" />
    </div>
    
    <div class="mb-3">
        <label asp-for="Price" class="form-label"></label>
        <input asp-for="Price" class="form-control" />
    </div>
    
    <button type="submit" class="btn btn-warning">Enregistrer</button>
    <a asp-action="Index" class="btn btn-secondary">Annuler</a>
</form>
```

---

## Formulaire avec IFormCollection

### Scénario
Vous ne voulez pas utiliser de modèle. Vous récupérez les données manuellement depuis le formulaire.

### Pas à pas : Contrôleur
1. Utilisez `IFormCollection form` comme paramètre
2. Récupérez chaque champ avec `form["NomDuChamp"].ToString()`
3. Convertissez les types si nécessaire

### Syntaxe : Contrôleur
```csharp
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(IFormCollection form)
{
    var product = new Product
    {
        Name = form["Name"].ToString(),
        Price = decimal.Parse(form["Price"].ToString()),
        EnStock = form["EnStock"].ToString() == "true"
    };
    
    _products.Add(product);
    return RedirectToAction("Index");
}
```

### Pas à pas : Vue (HTML pur)
1. Utilisez des champs HTML standards avec `name` et `id`
2. Pas besoin de Tag Helpers

### Syntaxe : Vue (HTML pur)
```html
<form method="post">
    @Html.AntiForgeryToken()
    
    <div class="mb-3">
        <label for="Name" class="form-label">Nom</label>
        <input type="text" class="form-control" id="Name" name="Name" />
    </div>
    
    <div class="mb-3">
        <label for="Price" class="form-label">Prix</label>
        <input type="number" class="form-control" id="Price" name="Price" step="0.01" />
    </div>
    
    <button type="submit" class="btn btn-primary">Créer</button>
</form>
```

---

## Protection CSRF

### Scénario
Vous devez protéger vos formulaires contre les attaques CSRF (Cross-Site Request Forgery).

### Pas à pas : Dans la vue
1. Ajoutez `@Html.AntiForgeryToken()` dans le formulaire
2. Cela génère un token de sécurité

### Syntaxe : Dans la vue
```html
<form method="post">
    @Html.AntiForgeryToken()
    <!-- champs du formulaire -->
</form>
```

### Pas à pas : Dans le contrôleur
1. Ajoutez l'attribut `[ValidateAntiForgeryToken]` sur l'action POST
2. ASP.NET Core valide automatiquement le token

### Syntaxe : Dans le contrôleur
```csharp
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Product product)
{
    // traitement
}
```

---

## Messages de succès avec TempData

### Scénario
Après une action (création, modification), vous voulez afficher un message de confirmation.

### Pas à pas : Dans le contrôleur
1. Assignez le message à `TempData["Success"]`
2. Redirigez vers une autre page
3. Le message persiste entre les redirections

### Syntaxe : Dans le contrôleur
```csharp
TempData["Success"] = "Produit créé avec succès !";
return RedirectToAction("Index");
```

### Pas à pas : Dans la vue
1. Vérifiez si `TempData["Success"]` existe
2. Affichez le message dans une alerte Bootstrap

### Syntaxe : Dans la vue
```html
@if (TempData["Success"] != null)
{
    <div class="alert alert-success">
        @TempData["Success"]
    </div>
}
```

---

## Redirection après création

### Scénario
Après avoir créé un produit, vous voulez rediriger l'utilisateur vers la liste.

### Pas à pas
1. Après le traitement, utilisez `RedirectToAction("Index")`
2. L'utilisateur sera redirigé vers la page Index

### Syntaxe
```csharp
[HttpPost]
public IActionResult Create(Product product)
{
    _products.Add(product);
    return RedirectToAction("Index");
}
```

---

## Formulaire avec validation HTML5

### Scénario
Vous voulez ajouter une validation côté client avec HTML5.

### Pas à pas
1. Ajoutez `required` pour les champs obligatoires
2. Ajoutez `min` et `step` pour les champs numériques

### Syntaxe
```html
<input asp-for="Name" class="form-control" required />
<input asp-for="Price" class="form-control" type="number" min="0.01" step="0.01" required />
```
