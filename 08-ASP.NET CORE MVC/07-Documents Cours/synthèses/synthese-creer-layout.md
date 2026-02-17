# Comment créer un Layout - Synthèse

## Contexte

Un Layout est un template maître qui définit la structure commune de toutes vos pages (header, footer, menu). Il évite de répéter le même code HTML sur chaque page.

---

## Structure de base d'un Layout

### Scénario
Vous créez un Layout principal pour votre application avec menu, contenu principal et footer.

### Pas à pas
1. Créez le fichier `Views/Shared/_Layout.cshtml`
2. Ajoutez la structure HTML de base (`<!DOCTYPE html>`, `<html>`, `<head>`, `<body>`)
3. Placez `@RenderBody()` là où le contenu des vues sera injecté
4. Ajoutez les sections optionnelles pour les styles et scripts

### Syntaxe
```html
<!DOCTYPE html>
<html lang="fr">
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>@ViewData["Title"] - Mon Application</title>
    <link rel="stylesheet" href="~/css/site.css" />
    @await RenderSectionAsync("Styles", required: false)
</head>
<body>
    <header>
        <nav>Menu de navigation</nav>
    </header>

    <main>
        @RenderBody()
    </main>

    <footer>
        <p>&copy; @DateTime.Now.Year - Mon Application</p>
    </footer>

    <script src="~/lib/jquery/dist/jquery.min.js"></script>
    @await RenderSectionAsync("Scripts", required: false)
</body>
</html>
```

---

## Éléments essentiels

### @RenderBody()

### Scénario
Vous devez définir où le contenu de chaque vue sera injecté dans le Layout.

### Pas à pas
1. Placez `@RenderBody()` dans la section `<main>` ou `<body>`
2. C'est obligatoire : sans lui, le contenu des vues ne s'affichera pas

### Syntaxe
```html
<main>
    @RenderBody()  <!-- Point d'injection du contenu de la vue -->
</main>
```

---

### Sections optionnelles

### Scénario
Certaines pages ont besoin de CSS ou JavaScript spécifiques. Les sections permettent d'ajouter du contenu à des endroits précis du Layout.

### Pas à pas
1. Dans le Layout, ajoutez `@await RenderSectionAsync("NomSection", required: false)`
2. Dans les vues, utilisez `@section NomSection { ... }` pour définir le contenu
3. `required: false` = la section est optionnelle

### Syntaxe
```html
@await RenderSectionAsync("Styles", required: false)
@await RenderSectionAsync("Scripts", required: false)
```

---

## Emplacement des Layouts

### Scénario
Les Layouts partagés doivent être dans un dossier accessible par toutes les vues.

### Structure
```
Views/
└── Shared/
    ├── _Layout.cshtml
    ├── _AdminLayout.cshtml
    └── _BlogLayout.cshtml
```

### Règle
- Tous les Layouts partagés sont dans `Views/Shared/`
- Le nom commence par `_` (convention)

---

## Convention de nommage

### Scénario
Pour que les vues trouvent facilement votre Layout, respectez les conventions.

### Règle
- Commence par `_` (underscore)
- Exemple : `_Layout.cshtml`, `_AdminLayout.cshtml`

---

## Pas à pas : Créer un Layout Admin

### Scénario
Vous voulez créer un Layout spécial pour les pages d'administration avec un menu latéral.

### Étape 1 : Créer le fichier
```
Views/Shared/_AdminLayout.cshtml
```

### Étape 2 : Structure HTML de base
```html
<!DOCTYPE html>
<html lang="fr">
<head>
    <meta charset="utf-8" />
    <title>ADMIN - @ViewData["Title"]</title>
    <link rel="stylesheet" href="~/css/site.css" />
</head>
<body>
    @RenderBody()
</body>
</html>
```

### Étape 3 : Ajouter le menu latéral
```html
<body>
    <div class="sidebar">
        <h3>Admin Panel</h3>
        <a asp-controller="Admin" asp-action="Dashboard">Dashboard</a>
        <a asp-controller="Admin" asp-action="Articles">Articles</a>
    </div>
    
    <div class="content">
        @RenderBody()
    </div>
</body>
```

### Étape 4 : Ajouter le CSS
```html
<head>
    <style>
        body {
            display: flex;
        }
        .sidebar {
            width: 250px;
            height: 100vh;
            background: #343a40;
            color: white;
            padding: 20px;
        }
        .content {
            flex: 1;
            margin-left: 250px;
            padding: 20px;
        }
    </style>
</head>
```

---

## Utiliser un Layout dans une vue

### Scénario : Layout par défaut
Par défaut, toutes les vues utilisent `_Layout.cshtml` défini dans `_ViewStart.cshtml`.

### Pas à pas
1. Ne spécifiez rien dans la vue
2. Le Layout par défaut sera utilisé automatiquement

### Syntaxe
```html
@{
    ViewData["Title"] = "Ma page";
}
<!-- Utilise automatiquement _Layout.cshtml -->
```

---

### Scénario : Layout spécifique
Vous voulez qu'une page utilise un Layout différent (ex: Layout Admin).

### Pas à pas
1. Dans la vue, définissez `Layout = "_AdminLayout"` dans un bloc `@{}`
2. Le Layout Admin sera utilisé au lieu du Layout par défaut

### Syntaxe
```html
@{
    Layout = "_AdminLayout";
    ViewData["Title"] = "Page admin";
}
```

---

### Scénario : Désactiver le Layout
Vous créez une page qui ne doit pas utiliser de Layout (ex: page d'impression).

### Pas à pas
1. Définissez `Layout = null` dans un bloc `@{}`
2. Écrivez votre HTML complet

### Syntaxe
```html
@{
    Layout = null;
}
```

---

## _ViewStart.cshtml

### Scénario
Vous voulez définir le Layout par défaut pour toutes les vues de l'application.

### Pas à pas
1. Créez ou modifiez `Views/_ViewStart.cshtml`
2. Définissez `Layout = "_Layout"`
3. Toutes les vues utiliseront ce Layout par défaut

### Syntaxe
```html
@{
    Layout = "_Layout";
}
```

Définit le Layout par défaut pour toutes les vues.

---

## Réutiliser des Partial Views dans un Layout

### Scénario
Vous voulez réutiliser le même footer ou menu dans plusieurs Layouts.

### Pas à pas
1. Créez une Partial View (ex: `_Footer.cshtml`)
2. Dans le Layout, utilisez `<partial name="_Footer" />`
3. Le footer sera réutilisé dans tous les Layouts qui l'incluent

### Syntaxe
```html
<body>
    <header>
        <partial name="_NavigationMenu" />
    </header>

    <main>
        @RenderBody()
    </main>

    <partial name="_Footer" />
</body>
```

---

## Layout avec menu latéral complet

### Scénario
Vous créez un Layout Admin complet avec menu latéral fixe et zone de contenu.

### Pas à pas
1. Créez la structure HTML avec sidebar et content
2. Ajoutez le CSS pour positionner le menu latéral à gauche
3. Placez `@RenderBody()` dans la zone de contenu

### Syntaxe
```html
<!DOCTYPE html>
<html lang="fr">
<head>
    <meta charset="utf-8" />
    <title>ADMIN - @ViewData["Title"]</title>
    <link rel="stylesheet" href="~/css/site.css" />
    <style>
        body { display: flex; margin: 0; }
        .sidebar {
            width: 250px;
            height: 100vh;
            background: #343a40;
            color: white;
            padding: 20px;
            position: fixed;
        }
        .content {
            flex: 1;
            margin-left: 250px;
            padding: 20px;
        }
    </style>
</head>
<body>
    <div class="sidebar">
        <h3>Admin Panel</h3>
        <a asp-controller="Admin" asp-action="Dashboard">Dashboard</a>
        <a asp-controller="Admin" asp-action="Articles">Articles</a>
    </div>
    
    <div class="content">
        @RenderBody()
    </div>

    <script src="~/lib/jquery/dist/jquery.min.js"></script>
    @await RenderSectionAsync("Scripts", required: false)
</body>
</html>
```

---

## Sections dans les vues

### Scénario
Une page a besoin de JavaScript ou CSS spécifique qui doit être chargé dans le Layout.

### Pas à pas : Définir une section dans une vue
1. Dans la vue, utilisez `@section NomSection { ... }`
2. Le contenu sera injecté à l'endroit défini dans le Layout

### Syntaxe : Section Scripts
```html
@section Scripts {
    <script>
        console.log("Script spécifique à cette page");
    </script>
}
```

### Syntaxe : Section Styles
```html
@section Styles {
    <style>
        .custom-style { color: red; }
    </style>
}
```
