# Exercice 01 - Manipulation de fichiers de base

## Objectifs

Appréhender le fonctionnement des dépots Git et de l'ajout de fichiers dans le cadre du versioning d'une application

## Sujet

Dans le cadre d'une application de votre choix, vous allez devoir créer un dossier permettant de travailler dans un environnement faisant usage d'un contrôle de version via Git. 

```bash
git init
```

* Créer plusieurs fichiers dont l'objectif sera de coder la partie backend d'une application (par exemple des fichiers comme `api.cs`)

```bash
mkdir backend

touch backend/api.cs
touch backend/app.cs
```

* Les ajouter dans l'environnement de travail de Git et les sauvegarder dans le dépot de code

```bash
git add backend/

git commit -m "Ajout des fichiers de base de l'application backend"
```

* Ajouter un autre dossier contenant d'autres fichiers servant à la partie frontend de l'application, comme par exemple une page d'accueil HTML

```bash
mkdir frontend

touch frontend/index.html
```

* La mettre dans le dépot de code Git

```bash
git add backend/

git commit -m "Ajout des fichiers de base de l'application backend"
```

* Modifier les fichiers de l'API et les update au sein du dépot de code

```bash
git commit -a -m "Modification de l'API C#"
```

* Oups! On aurait du faire un projet à part pour la partie frontend. Retirer les fichiers de la partie frontend du dépot de base et les ajouter à un autre dépot de code spécifique pour le frontend