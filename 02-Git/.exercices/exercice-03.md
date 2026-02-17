# Exercice 03 - Création et fusion de branches

## Objectifs

Appréhender le fonctionnement des branches dans l'écosystème Git

## Sujet

* Créer un dépot Git pour sauvegarder notre projet de développement d'application frontend

```bash
git init
```

* Faire un commit initial contenant un fichier descriptif de l'applicatif et de ses objectifs

```bash
touch README.md

git add . && git commit -m "Commit initial"
```

* Créer une branche servant à la création de la page d'accueil de notre site

```bash
git switch -c feat/accueil
```

* Faire un ensemble de commits et de modifications à notre applicatif

```bash
echo "<h1>Hello world</h1>" > index.html

git add index.html && git commit -m "Ajout de la page d'accueil"

index.html << EOF
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Accueil</title>
    </head>
    <body>
        <h1>Hello World</h1>
    </body>
    </html>
EOF

git commit -am "Modification de la page d'accueil"
```

* Créer une autre branche basée sur le commit initial servant à la création d'une feature telle que la page de contact 

```bash
git switch -c feat/contact main
```

* Faire un ensemble de modifs et de commits pour tout sauvegarder

```bash
echo "<h1>Hello world</h1>" > contact.html

git add contact.html && git commit -m "Ajout de la page de contact"

contact.html << EOF
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
        <title>Contact</title>
    </head>
    <body>
        <h1>Hello World</h1>
    </body>
    </html>
EOF

git commit -am "Modification de la page de contact"
```

* Se déplacer dans la branche principale et rapatrier les features validées par la hiérarchie

```bash
git switch main 

git merge feat/accueil

git merge feat/contact -m "Merging feat/contact"
```