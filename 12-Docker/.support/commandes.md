# Récap des commandes Docker

* Vérifier la version du client ainsi que du serveur docker: 

```bash
docker version
```

* Rechercher une image dans DockerHub: 

```bash
docker search <terme de recherche>
```

* Récupérer une image depuis un registre d'images de conteneur: 

```bash
docker pull <nom de l'image>
```

* Créer un réseau 

```bash
docker network create <nom réseau>
```

* Inspecter un conteneur pour en tirer des infos 

```bash
docker inspect <ID | Nom conteneur>
```

* Sauvegarder un conteneur et ses changements sous forme d'image

```bash
docker commit <ID | Nom conteneur> <Nom d'image>
```

* Création d'une image de toute pièce à partir d'un Dockerfile (le terminal est au même niveau que le fichier `Dockerfile`):

```bash
docker build -t <nom d'image> .
```

* Renommer (créer un duplicat) d'une image

```bash
docker tag <Ancien nom d'image> <Nouveau nom d'image>
```

* Ajouter une image locale dans un registre d'image de conteneur distant

```bash
docker push <Nom d'image>
```

## Lancement d'un conteneur 

* Lancement d'un conteneur d'image classique: 

```bash
docker run <nom image>
```

* Lancement d'un conteneur d'image avec entrée standard et profil TTY: 

```bash
docker run -i -t <nom image>

# ou

docker run -it <nom image>
```

* Lancement d'un conteneur d'image en mode détaché: 

```bash
docker run -d <nom image>
```

* Lancement d'un conteneur d'image via une redirection de ports: 

```bash
docker run -p <port hôte>:<port conteneur> <nom image>
```

* Lancer un conteneur avec un volume anonyme lié à un dossier particulier de l'image / du conteneur

```bash
docker run -v :/emplacement/a/sauvegarder <nom image>
```

* Lancer un conteneur avec un volume nommé lié à un dossier particulier de l'image / du conteneur

```bash
docker run -v nom-volume:/emplacement/a/sauvegarder <nom image>
```

* Lancer un conteneur avec un bind mount lié à un dossier particulier de l'image / du conteneur

```bash
docker run -v /emplacement/sur/hote:/emplacement/a/sauvegarder <nom image>
```

* Lancer un conteneur avec une variable d'environnement

```bash
docker run -e NOM_VARIABLE_ENVIRONNEMENT=valeur <nom image>
```

* Lancer un conteneur avec nom personnalisé

```bash
docker run --name <nom conteneur> <nom image>
```

* Lancer un conteneur avec un réseau

```bash
docker run --network <nom réseau> <nom image>
```

* Exécuter une commande dans un conteneur en cours d'exécution

```bash
docker exec <ID | Nom du conteneur> commande

# Si besoin de l'intéractivité
docker exec -it <ID | Nom du conteneur> commande
```

* Voir les conteneurs en cours d'exécution:

```bash
docker ps

# ou 

docker container ls
```

* Voir tous les conteneurs:

```bash
docker ps -a

# ou 

docker container ls -a
```

* Stopper un conteneur: 

```bash
docker stop <ID | Nom du conteneur>
```

* Supprimer un conteneur: 

```bash
docker rm <ID | Nom du conteneur>
```

* Supprimer les conteneurs à l'arret: 

```bash
docker container prune
```