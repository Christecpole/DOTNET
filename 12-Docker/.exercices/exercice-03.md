# Exercice Docker #3 - Création d'une base de données

## Objectifs

Appréhender le fonctionnement de Docker et de MySQL

## Sujet

Via l'utilisation de Docker Desktop, de l'image de MySQL disponible sur DockerHub ainsi que des commandes de terminal, réaliser le déploiement d'une base de données conservant ses données: 

* Rechercher une image de base de données MySQL
* Récupérer l'image sur notre ordinateur
* Lancer un conteneur à partir d'une image de ce SGBD de sorte à ce que l'on puisse persister les données
* Configurer le serveur de base de données de sorte à avoir une BdD ainsi que plusieurs tables et données dedans (à vous de choisir les données)
* Supprimer le conteneur de base de données
* Recréer un autre conteneur de base de données et vérifier que les données du premier conteneur son encore présentes


## Correction 

* Rechercher une image de base de données MySQL

```bash
docker search mysql
```

* Récupérer l'image sur notre ordinateur

```bash
docker pull mysql
```

* Lancer un conteneur à partir d'une image de ce SGBD de sorte à ce que l'on puisse persister les données

```bash
docker run \
-d \
-p 3306:3306 \
-e MYSQL_ROOT_PASSWORD=password \
-v exo-03-data:/var/lib/mysql \
--name exo-03-db \
mysql
```

* Configurer le serveur de base de données de sorte à avoir une BdD ainsi 
que plusieurs tables et données dedans (à vous de choisir les données)

```bash
docker exec -it exo-03-db bash

# Une fois dans le conteneur...
mysql -u root -p

# On tape le mode passe (password)

# Une fois dans le client MySQL...
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
```

* Supprimer le conteneur de base de données

```bash
docker stop exo-03-db

docker rm exo-03-db
```

* Recréer un autre conteneur de base de données et vérifier que les données du premier conteneur son encore présentes

```bash
docker run \
-d \
-p 3307:3306 \
-e MYSQL_ROOT_PASSWORD=password \
-v exo-03-data:/var/lib/mysql \
--name exo-03-db-bis \
mysql


docker exec -it exo-03-db-bis bash

# Une fois dans le conteneur...
mysql -u root -p

# On tape le mode passe (password)

# Une fois dans le client MySQL...
SHOW DATABASES;

SELECT * FROM testDB.clients;
```