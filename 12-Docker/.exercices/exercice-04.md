# Exercice Docker #4 - Création d'une communication entre conteneurs

## Objectifs

Appréhender le fonctionnement de Docker et de ses réseaux

## Sujet

Via l'utilisation de Docker Desktop, de l'image de MySQL disponible sur DockerHub ainsi que des commandes de terminal, réaliser le déploiement d'une base de données conservant ses données ainsi que d'un client MySQL: 

* Rechercher une image de base de données MySQL
* Récupérer l'image sur notre ordinateur
* Lancer un conteneur à partir d'une image de ce SGBD de sorte à ce que l'on puisse persister les données et que l'on puisse communiquer avec par la suite
* Créer un conteneur à partir d'une image style Ubuntu et le brancher au même réseau que le conteneur de base de données
* Y installer le client MySQL
* Interroger le serveur MySQL à partir du client et y créer une table ainsi que des données

## Correction 

* Rechercher une image de base de données MySQL

```bash
docker search mysql
```

* Récupérer l'image sur notre ordinateur

```bash
docker pull mysql
```
* Lancer un conteneur à partir d'une image de ce SGBD de sorte à ce que l'on puisse persister les données et que l'on puisse communiquer avec par la suite

```bash
docker network create exo-04

docker run \
-d \
-v exo-04-data:/var/lib/mysql \
-e MYSQL_ROOT_PASSWORD=password \
-p 3306:3306 \
--network exo-04 \ 
--name exo-04-db \
mysql
```
* Créer un conteneur à partir d'une image style Ubuntu et le brancher au même réseau que le conteneur de base de données

```bash
docker run \
-it \ 
--network exo-04 \ 
--name exo-04-client \
ubuntu
```

* Y installer le client MySQL

```bash
# Une fois dans le conteneur...

apt update -y

apt install -y mysql-client
```

* Interroger le serveur MySQL à partir du client et y créer une table ainsi que des données

```bash
mysql -h exo-04-db -u root -p

# On entre le mot de passe (password) ...

CREATE DATABASE IF EXISTS testDB;

USE testDB;

CREATE TABLE IF NOT EXISTS clients (
    client_id INT AUTO_INCREMENT PRIMARY KEY,
    client_name VARCHAR(150) NOT NULL,
    client_address VARCHAR(500) NOT NULL
);

INSERT INTO clients (client_name, client_address) VALUES 
("John DUPONT", "336, Rue des Templiers 75000 PARIS"),
("Jane DALE", "123, Rue des Fleurs 59300 TOURCOING");

SELECT * FROM clients;

EXIT;

# On sort de MySQL...

exit 

# On sort du conteneur...

docker exec -it exo-04-db bash

# On entre dans le conteneur du serveur de BdD...

mysql -u root -p

# Une fois dans le client MySQL...

SHOW DATABASES;

SELECT * FROM testDB.clients;
```