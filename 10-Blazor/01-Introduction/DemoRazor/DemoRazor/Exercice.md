Créer une mini-application avec 5 pages, chacune dédiée à un concept Razor. Une sidebar permet de naviguer entre les pages.

| Page | Concept | URL |
|------|---------|-----|
| Variables.razor | Affichage de variables | `/syntaxe/variables` |
| Conditions.razor | @if / @else | `/syntaxe/conditions` |
| Boucles.razor | @foreach / @for | `/syntaxe/boucles` |
| Evenements.razor | @onclick | `/syntaxe/evenements` |
| Binding.razor | @bind | `/syntaxe/binding` |

## Exercice 1 : Créer le Layout avec Sidebar

### Consigne
Créer un layout avec une barre de navigation à gauche qui permettra de naviguer entre les 5 pages du TP.

### Objectifs
- Comprendre ce qu'est un layout
- Utiliser `@Body` pour afficher le contenu des pages
- Créer une navigation avec des liens

### À faire
1. Créer un dossier `Syntaxe` dans `Pages`
2. Créer un fichier `SyntaxeLayout.razor`
3. Ajouter `@inherits LayoutComponentBase` en haut du fichier
4. Créer une structure avec 2 colonnes : une sidebar à gauche, le contenu à droite
5. Dans la sidebar, ajouter 5 liens vers les pages : Variables, Conditions, Boucles, Événements, Binding
6. Dans la zone de contenu, placer `@Body`

---

## Exercice 2 : Page Variables

### Consigne
Créer une page qui affiche des variables simples et des expressions calculées.

### Objectifs
- Afficher une variable avec `@variable`
- Afficher une expression avec `@(expression)`
- Formater une date

### À faire
1. Créer `Variables.razor` dans le dossier `Syntaxe`
2. Définir l'URL `/syntaxe/variables`
3. Utiliser le layout `SyntaxeLayout`
4. Créer 3 variables : un nom (texte), un âge (nombre), une date
5. Afficher ces variables dans la page
6. Afficher l'âge multiplié par 2
7. Afficher "Oui" si majeur, "Non" sinon

---

## Exercice 3 : Page Conditions

### Consigne
Créer une page qui affiche du contenu différent selon une condition.

### Objectifs
- Utiliser `@if` et `@else`
- Utiliser `@else if` pour plusieurs conditions
- Lier une checkbox à une variable

### À faire
1. Créer `Conditions.razor` avec l'URL `/syntaxe/conditions`
2. Créer une variable booléenne `estConnecte`
3. Ajouter un interrupteur (switch) lié à cette variable
4. Afficher un message vert si connecté, orange si déconnecté
5. Bonus : ajouter un sélecteur de niveau (débutant/intermédiaire/avancé) qui affiche un badge différent selon le choix

---

## Exercice 4 : Page Boucles

### Consigne
Créer une page qui affiche des listes en utilisant des boucles.

### Objectifs
- Parcourir une liste avec `@foreach`
- Parcourir avec un index en utilisant `@for`
- Afficher une liste d'objets dans un tableau

### À faire
1. Créer `Boucles.razor` avec l'URL `/syntaxe/boucles`
2. Créer une liste de 4 fruits
3. Afficher cette liste avec `@foreach`
4. Afficher la même liste avec `@for` en ajoutant un numéro devant chaque fruit
5. Créer une classe `Personne` avec Nom, Age, Ville
6. Créer une liste de 2-3 personnes
7. Afficher ces personnes dans un tableau HTML

---

## Exercice 5 : Page Événements

### Consigne
Créer une page interactive avec des boutons qui déclenchent des actions.

### Objectifs
- Utiliser `@onclick` pour appeler une méthode
- Passer un paramètre à une méthode avec `@onclick="() => Methode(param)"`
- Modifier une liste dynamiquement

### À faire
1. Créer `Evenements.razor` avec l'URL `/syntaxe/evenements`
2. Créer un compteur qui s'affiche en grand
3. Ajouter un bouton "+1" qui incrémente le compteur
4. Ajouter des boutons "-5", "-1", "+1", "+5" qui modifient le compteur
5. Ajouter un bouton "Reset" qui remet à zéro
6. Créer une liste d'items avec un bouton "Ajouter" et un bouton "Supprimer" sur chaque item

---

## Exercice 6 : Page Binding

### Consigne
Créer une page avec des champs de formulaire liés à des variables.

### Objectifs
- Lier un champ texte à une variable avec `@bind`
- Mettre à jour en temps réel avec `@bind:event="oninput"`
- Désactiver un bouton selon une condition

### À faire
1. Créer `Binding.razor` avec l'URL `/syntaxe/binding`
2. Créer un champ texte lié à une variable, afficher la valeur en dessous
3. Créer un second champ texte avec mise à jour en temps réel
4. Créer un formulaire avec : nom, email, âge, et une checkbox "J'accepte"
5. Afficher un aperçu des données saisies
6. Désactiver le bouton "Valider" tant que la checkbox n'est pas cochée

---

## Exercice 7 : Lien dans le menu

### Consigne
Ajouter un lien dans le menu principal pour accéder au TP.

### À faire
1. Ouvrir `Layout/NavMenu.razor`
2. Ajouter un NavLink vers `/syntaxe/variables` avec le texte "Syntaxe Razor"

---