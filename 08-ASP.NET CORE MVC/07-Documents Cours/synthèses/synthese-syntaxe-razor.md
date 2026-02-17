# Syntaxe Razor - Synthèse

## Contexte

Razor permet de mélanger du code C# dans du HTML pour créer des pages web dynamiques. Utilisez Razor pour afficher des données provenant du contrôleur, créer des conditions d'affichage, et parcourir des listes.

---

## Déclaration du modèle

### Scénario
Vous voulez recevoir des données du contrôleur dans votre vue. Le modèle définit le type de données attendu.

### Pas à pas
1. En haut de votre fichier `.cshtml`, ajoutez `@model` suivi du type
2. Utilisez `@Model` (M majuscule) dans le reste de la vue pour accéder aux données

### Syntaxe
```html
@model TypeDuModele
```

### Exemples
```html
@model Product
@model List<Product>
@model string
```

### Utilisation
```html
@model Product
<h1>@Model.Name</h1>
```

---

## Variables et blocs de code

### Scénario
Vous devez calculer des valeurs ou stocker des données temporaires dans votre vue avant de les afficher.

### Pas à pas : Variable simple
1. Créez un bloc `@{}` en haut de votre vue
2. Déclarez vos variables avec `var`
3. Utilisez `@variable` pour afficher la valeur

### Syntaxe
```html
@{
    var message = "Bonjour";
    var nombre = 42;
}
<p>@message</p>
<p>Le nombre est : @nombre</p>
```

### Pas à pas : Expression
1. Utilisez `@(expression)` pour évaluer une expression C#
2. Les parenthèses délimitent clairement l'expression

### Syntaxe
```html
<p>Total : @(nombre * 2)</p>
```

### Pas à pas : Bloc de code multiligne
1. Déclarez toutes vos variables dans un bloc `@{}`
2. Utilisez les variables dans le reste de la vue

### Syntaxe
```html
@{
    var prenom = "Marie";
    var nom = "Dupont";
    var fullName = $"{prenom} {nom}";
    var produits = new List<string> { "Laptop", "Souris" };
    var total = 1299.99m;
}
```

---

## Conditions

### Scénario
Vous voulez afficher du contenu différent selon une condition (ex: afficher "En stock" ou "Rupture" selon le stock).

### Pas à pas : If/Else
1. Utilisez `@if (condition)` pour vérifier une condition
2. Ajoutez `else` si nécessaire
3. Placez le HTML à afficher entre les accolades

### Syntaxe
```html
@if (isAuthenticated)
{
    <p>Bienvenue, vous êtes connecté !</p>
}

@if (stock > 0)
{
    <span class="badge bg-success">En stock (@stock)</span>
}
else
{
    <span class="badge bg-danger">Rupture de stock</span>
}
```

---

## Boucles

### Scénario
Vous avez une liste d'éléments à afficher (produits, articles, etc.) et vous voulez créer un élément HTML pour chaque item.

### Pas à pas : Foreach
1. Utilisez `@foreach (var item in collection)`
2. Placez le HTML à répéter entre les accolades
3. Utilisez `@item` pour accéder à l'élément actuel

### Syntaxe
```html
@foreach (var produit in produits)
{
    <li>@produit</li>
}
```

### Pas à pas : For
1. Utilisez `@for` quand vous avez besoin de l'index
2. Déclarez le compteur `int i = 0`
3. Accédez aux éléments avec `Model[i]`

### Syntaxe
```html
@for (int i = 0; i < Model.Count; i++)
{
    var product = Model[i];
    <h3>Produit @(i + 1)</h3>
}
```

---

## Utilisation du Model

### Scénario
Le contrôleur vous passe un objet ou une liste d'objets que vous devez afficher dans la vue.

### Pas à pas : Model simple
1. Déclarez `@model Product` en haut
2. Utilisez `@Model.PropertyName` pour accéder aux propriétés
3. Utilisez l'opérateur ternaire pour des conditions simples

### Syntaxe
```html
@model Product

<h1>@Model.Name</h1>
<p>Prix : @Model.Price €</p>
<p>Disponible : @(Model.Stock > 0 ? "Oui" : "Non")</p>
```

### Pas à pas : Model avec liste
1. Déclarez `@model List<Product>` en haut
2. Utilisez `@Model.Count` pour obtenir le nombre d'éléments
3. Utilisez `@foreach` pour parcourir la liste
4. Utilisez `@product` (variable de boucle) pour accéder à chaque élément

### Syntaxe
```html
@model List<Product>

<h1>@Model.Count produit(s)</h1>

<table class="table">
    @foreach (var product in Model)
    {
        <tr>
            <td>@product.Name</td>
            <td>@product.Price.ToString("C")</td>
        </tr>
    }
</table>
```

---

## ViewData et ViewBag

### Scénario
Vous voulez passer des données simples (titre, message) du contrôleur à la vue sans créer un modèle complet.

### Pas à pas
1. Dans le contrôleur : `ViewData["Title"] = "Ma page"` ou `ViewBag.Message = "Texte"`
2. Dans la vue : utilisez `@ViewData["Title"]` ou `@ViewBag.Message`

### Syntaxe
```html
@{
    ViewData["Title"] = "Ma page";
}

<h1>@ViewData["Title"]</h1>
<p>@ViewBag.Message</p>
```

---

## Commentaires Razor

### Scénario
Vous voulez ajouter des notes dans votre code qui ne seront pas visibles dans le HTML final.

### Pas à pas
1. Utilisez `@* ... *@` pour les commentaires Razor
2. Ces commentaires ne sont pas envoyés au navigateur

### Syntaxe
```html
@* Ceci est un commentaire Razor - invisible dans le HTML final *@
```

---

## Échappement du symbole @

### Scénario
Vous voulez afficher le symbole @ littéralement (ex: dans une adresse email).

### Pas à pas
1. Utilisez `@@` pour afficher un seul `@`

### Syntaxe
```html
@@email.com  <!-- Affiche : @email.com -->
```

---

## Texte brut dans un bloc de code

### Scénario
Vous voulez afficher du texte sans balise HTML dans un bloc de code C#.

### Pas à pas
1. Utilisez `<text>...</text>` ou `@: ...` pour du texte brut

### Syntaxe
```html
@if (showMessage)
{
    <text>Ceci est du texte brut sans balise HTML</text>
    @: Ceci aussi est du texte brut
}
```

---

## Formatage

### Scénario
Vous voulez formater des nombres, dates ou montants pour un affichage professionnel.

### Pas à pas : Format monétaire
1. Utilisez `.ToString("C")` pour le format monétaire (€)

### Syntaxe
```html
@Model.Price.ToString("C")
```

### Pas à pas : Format décimal
1. Utilisez `.ToString("F2")` pour 2 décimales

### Syntaxe
```html
@moyenne.ToString("F2")
```

### Pas à pas : Format date
1. Utilisez `.ToString("dd/MM/yyyy")` pour formater une date

### Syntaxe
```html
@Model.PublishedAt.ToString("dd/MM/yyyy")
```

---

## Opérateur ternaire

### Scénario
Vous voulez afficher une valeur conditionnelle en une seule ligne.

### Pas à pas
1. Utilisez `@(condition ? valeurSiVrai : valeurSiFaux)`
2. N'oubliez pas les parenthèses

### Syntaxe
```html
@(Model.Stock > 0 ? "Oui" : "Non")
```

---

## LINQ dans les vues

### Scénario
Vous voulez calculer des statistiques (moyenne, total, comptage) directement dans la vue.

### Pas à pas
1. Déclarez les variables dans un bloc `@{}`
2. Utilisez les méthodes LINQ : `.Count()`, `.Average()`, `.Sum()`, etc.

### Syntaxe
```html
@{
    var totalStudents = Model.Count;
    var moyenne = Model.Average(s => s.Grade);
    var featuredCount = Model.Count(a => a.IsFeatured);
}
```
