# Exercice 02 - Déplacement et corrections dans un dépot Git

## Objectifs

Appréhender le fonctionnement des dépots Git et de l'historique d'une branche

## Sujet

Dans le cadre d'une application de votre choix, vous allez devoir créer un dossier permettant de travailler dans un environnement faisant usage d'un contrôle de version via Git. 

* Créer un dossier de travail compatible avec git

```bash
git init
```

* Créer un ensemble de fichiers de code sources relatif à un site web (tel une page d'accueil, des fichiers de style, etc.)

```bash
mkdir website
mkdir -p website/assets

touch website/index.html
touch website/assets/style.css
```

* Sauvegarder ces fichiers dans notre dépot Git

```bash
git add . 

git commit -m "Ajout des fichiers de base du site web"
```

* Modifier le fichier de la page d'accueil en ajoutant un paragraphe de type lorem ipsum

```bash
# Modification du fichier
```

* Sauvegarder ces modifications

```bash
git commit -am "Ajout d'un paragraphe fictif" 
```

* Modifier le fichier de style de sorte à styliser le paragraphe nouvellement créé

```bash
# Modification du fichier
```

* Sauvegarder ces modifications

```bash
git commit -am "Ajout du style de l'application" 
```

* Corriger le texte du paragraphe en mettant un vrai texte descriptif d'un produit de notre site marchand

```bash
# Modification du fichier
```

* Sauvegarder la modification

```bash
git commit -am "Ajout du contenu du paragraphe" 
```

* Oops, on a fait trop de commits, faire en sorte de rassembler l'ensemble des modifications précédentes 

```bash
git reset main~3

git commit -am "Blabla"
```

en un seul commit pour apporter de la clareté à notre dépot. Nommer le nouveau commit "Blabla"
* On s'est trompé de nom, on aurait du mettre un texte plus descriptif. Corriger notre erreur de sorte à avoir un commit avec un texte adapté, ce sans avoir à devoir rassembler de nouveaux l'ensemble des modifications en un commit.

```bash
git reset main~3

git commit -am "Ajout du paragraphe stylisé"
```

* Créer un fichier de code C# portant l'extension `.cs`

```bash
touch appli.cs
```

* Sauvegarder le fichier dans le dépot Git

```bash
git add . 

git commit -m "Ajout du fichier CS"
```

* Oops, on s'est trompé de projet, sortir le fichier nouvelle ajouté de notre historique Git pour tout le monde

```bash
git reset --hard main~1
```