# Exercice Docker #2 - Création d'un serveur web

## Objectifs

Appréhender le fonctionnement de Docker et de NGINX dans le cadre du déploiement d'un serveur web personnalisé

## Sujet

Via l'utilisation de Docker Desktop, de l'image de NGINX disponible sur DockerHub ainsi que des commandes de terminal, réaliser le déploiement d'un serveur web personnalisé: 

* Rechercher une image de serveur web NGINX
* Récupérer l'image sur notre ordinateur
* Lancer un conteneur à partir d'une image de ce serveur web
* Configurer le serveur web pour en modifier la page d'accueil
* Vérifier le résultat via un appel HTTP depuis votre propre ordinateur (la redirection de port est nécessaire pour que le traffic passe)

## Correction

* Rechercher une image de serveur web NGINX

```bash
docker search nginx
```

* Récupérer l'image sur notre ordinateur

```bash
docker pull nginx
```

* Lancer un conteneur à partir d'une image de ce serveur web

```bash
docker run -p 8080:80 -d --name exo-02 nginx
```

* Configurer le serveur web pour en modifier la page d'accueil

```bash
docker exec -it exo-02 bash

# Une fois dans le conteneur...
apt update -y

apt install -y nano

nano /usr/share/nginx/html/index.html

# On modifie, on sauvegarde, on valide le nom de fichier...

exit
```


* Vérifier le résultat via un appel HTTP depuis votre propre ordinateur (la redirection de port est nécessaire pour que le traffic passe)

```bash
# En dehors du conteneur
curl http://localhost:8080

# Ou on va sur notre navigateur et on entre la même adresse dans la barre de navigation
```