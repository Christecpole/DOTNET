# Exercice Docker #1 - Création d'un serveur web

## Objectifs

Appréhender le fonctionnement de Docker dans le cadre du déploiement d'une image simple récupérée en ligne

## Sujet

Via l'utilisation de Docker Desktop ainsi que des commandes de terminal, réaliser le déploiement d'un serveur web de type NGINX: 

* Rechercher une image de serveur web NGINX
* Récupérer l'image sur notre ordinateur
* Lancer un conteneur à partir d'une image de ce serveur web
* Vérifier le fonctionnement du serveur web via une commande de type `curl`

## Bonus

* Créer l'image du serveur web à partir d'une image d'Ubuntu (distro Linux légère) et la sauvegarder manuellement. 
* Vérifier son fonctionnement en l'exécutant et en la testant comme précédemment expliqué.

## Correction image maison

* Trouver une image qui va être une base pour notre serveur web:

```bash
docker search ubuntu
```

* Récupérer l'image d'ubuntu: 

```bash
docker pull ubuntu
```

* Lancer Ubuntu en mode intéractif

```bash
docker run -it ubuntu 
```

### Une fois dans le terminal du conteneur

* Mise à jour des paquets 

```bash
apt update -y
```

* Installation de NGINX

```bash
apt install -y nginx
```

* Installation de CURL

```bash
apt install -y curl
```

* Lancement de NGINX et vérification de son statut: 

```bash
service nginx start

service nginx status
```

* Tester le fonctionnement du serveur web:

```bash
curl localhost
```

## Correction image préfaite

* Trouver une image de NGINX:

```bash
docker search nginx
```

* Récupérer l'image de NGINX: 

```bash
docker pull nginx
```

* Lancer NGINX en mode détaché

```bash
docker run -d nginx
```

### Entrer dans le conteneur

* Exécuter un processus dans un conteneur en cours d'exécution

```bash
docker exec -it <id conteneur> bash
```

* Récupérer la page d'accueil via un appel HTTP

```bash
curl localhost
```