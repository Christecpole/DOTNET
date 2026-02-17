# Exercice 04 - Récupération des derniers changements

## Objectifs

Appréhender le fonctionnement des branches dans l'écosystème Git

## Sujet

* Créer un dépot Git pour sauvegarder notre projet de développement d'application frontend

```bash
git init
```

* Faire un commit initial contenant un fichier descriptif de l'applicatif et de ses objectifs

```bash
echo "# Exercice 04" > README.md

git add README.md && git commit -m "Ajout du fichier initial"
```

* Créer une autre branche servant à la création d'une API dont l'objectif sera le traitement des requêtes sur la page de contact. Créer également une branche servant à la création de la page de contact de notre site

```bash
git branch feat/contact-web

git switch -c feat/contact-api
```

* Faire un ensemble de commits et de modifications pour l'API de l'application, ce dans la branche adaptée

```bash
# On code l'API

git add . && git commit -m "Ajout des fichiers initiaux de l'API"

# On améliore notre code

git commit -am "Modification de notre API"
```

* Se déplacer dans la branche principale et rapatrier les changements sur l'API validés par la hiérarchie

```bash
git switch main

git merge feat/contact-api
```

* Se placer ensuite sur la branche en lien avec la page de contact du site web

```bash
git switch feat/contact-web
```

* Faire un ensemble de modifs et de commits pour tout sauvegarder

```bash
# On code le site web

git add . && git commit -m "Ajout des fichiers initiaux du site"

# On améliore notre code

git commit -am "Modification de notre formulaire de contact"
```

* On aimerait tester le fonctionnement réel du formulaire, mettre à jour l'historique des commits de sorte à ce que la branche de développement de la partie frontend du formulaire de contact inclue également les changements précédemment inclus dans la branche principale

```bash
git rebase main
```