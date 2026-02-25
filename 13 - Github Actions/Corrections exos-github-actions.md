**Exercice Github Actions #1 - Workflow pour projet Node.js**

Réaliser, pour le projet en PJ, un workflow via Github Action comportant les étapes suivantes: 

Récupération du code source

Installation de la même version de Node.js qu'en local

Installation des dépendances du projet

Compilation de l'application

Vérification de la compilation

Réalisation des tests unitaires de l'application

&nbsp;

node-project.zip



name: Demo Workflow Node.js



on: 

&nbsp; push:

&nbsp;   branches: \["main", "master"]

&nbsp; workflow\_dispatch:



jobs:

&nbsp; build:

&nbsp;   runs-on: ubuntu-latest

&nbsp;   steps:

&nbsp;     - name: Récupération du code source

&nbsp;       uses: actions/checkout@v6



&nbsp;     - name: Installation de Node.js

&nbsp;       uses: actions/setup-node@v6

&nbsp;       with:

&nbsp;         node-version: '24.13.1'

&nbsp;         cache: 'npm'



&nbsp;     - name: Installation des dépendances

&nbsp;       run: npm ci



&nbsp;     - name: Compile le projet

&nbsp;       run: npm run build



&nbsp;     - name: Vérification de la compilation

&nbsp;       run: | 

&nbsp;         test -f dist/index.html

&nbsp;         cat dist/index.html | grep '<div id="root"></div>'





**Exercice Github Actions #2 - Réalisation d'une stratégie matricielle**

Via la génération d'un projet de type ASP.NET Core avec dotnet 8 et 10, réaliser un workflow sur Github actions permettant, pour une API (type le projet de base Weatherforecast): 

De récupérer le code source

D'installer la version de dotnet adaptée à la stratégie

De compiler le projet

De publier le projet

D'upload des artéfacts correspondant à la version compilée avec la bonne version de dotnet (celle provenant de la stratégie matricielle) récupérable sous la forme d'une archive en fin de workflow

&nbsp;

DemoGithubActions.zip





**Demo Workflow avec Docker Build**



name: Démo packaging Docker



on:

&nbsp; push:

&nbsp;   branches: \["main"]

&nbsp; workflow\_dispatch:



env:

&nbsp; # Nom de l'image: <emplacement du registre d'image de conteneur>/<nom du registre>/<nom de l'image>

&nbsp; DOCKER\_IMAGE\_NAME: ghcr.io/${{ github.repository\_owner }}/demo-website



jobs:

&nbsp; packaging:

&nbsp;   runs-on: ubuntu-latest



&nbsp;   permissions:

&nbsp;     contents: read

&nbsp;     packages: write



&nbsp;   steps:

&nbsp;     - name: Récupération du code source

&nbsp;       uses: actions/checkout@v6



&nbsp;     - name: Connexion au registre d'image de conteneur de Github

&nbsp;       run: echo ${{ secrets.GHCR\_PAT\_BIS }} | docker login ghcr.io -u $GITHUB\_ACTOR --password-stdin

&nbsp;       

&nbsp;       # run: docker login ghcr.io -u $GITHUB\_ACTOR -p ${{ secrets.GHCR\_PAT\_BIS }}



&nbsp;     - name: Packaging de l'application

&nbsp;       run: | 

&nbsp;         docker build -t $DOCKER\_IMAGE\_NAME:latest .

&nbsp;         docker build -t $DOCKER\_IMAGE\_NAME:$GITHUB\_SHA .

&nbsp;     

&nbsp;     - name: Publication de l'image sur le GHCR

&nbsp;       run: docker push -a $DOCKER\_IMAGE\_NAME



**Exercice #3 - Création d'un workflow de CI complet pour un projet Node.js**

Via le projet ci-joint, réaliser un workflow complet permettant: 

La compilation de l'application

La réalisation des tests unitaires avec publication des rapports de test

Le packaging de l'application via l'utilisation de Docker

La publication de l'image avec tracking des version sur le registre d'image de conteneur privé de Github

Le déploiement de l'image dans une machine virtuelle Azure crée au préalable

Faites en sorte d'optimiser au possible le workflow via utilisation de cache, de secrets et autre variables d'environnement au besoin  

&nbsp;

node-project.zip

node-project.zip



**YAML de workflow avec packaging / déploiement sur Azure**



name: Démo packaging Docker



on:

&nbsp; push:

&nbsp;   branches: \["main"]

&nbsp; workflow\_dispatch:



env:

&nbsp; # Nom de l'image: <emplacement du registre d'image de conteneur>/<nom du registre>/<nom de l'image>

&nbsp; DOCKER\_IMAGE\_NAME: ghcr.io/${{ github.repository\_owner }}/demo-website



jobs:

&nbsp; packaging:

&nbsp;   runs-on: ubuntu-latest



&nbsp;   permissions:

&nbsp;     contents: read

&nbsp;     packages: write



&nbsp;   steps:

&nbsp;     - name: Récupération du code source

&nbsp;       uses: actions/checkout@v6



&nbsp;     - name: Connexion au registre d'image de conteneur de Github

&nbsp;       run: echo ${{ secrets.GHCR\_PAT\_BIS }} | docker login ghcr.io -u $GITHUB\_ACTOR --password-stdin

&nbsp;       

&nbsp;       # run: docker login ghcr.io -u $GITHUB\_ACTOR -p ${{ secrets.GITHUB\_TOKEN }}



&nbsp;     - name: Packaging de l'application

&nbsp;       run: | 

&nbsp;         docker build -t $DOCKER\_IMAGE\_NAME:latest .

&nbsp;         docker build -t $DOCKER\_IMAGE\_NAME:$GITHUB\_SHA .

&nbsp;     

&nbsp;     - name: Publication de l'image sur le GHCR

&nbsp;       run: docker push -a $DOCKER\_IMAGE\_NAME



&nbsp; deployment:

&nbsp;   runs-on: ubuntu-latest

&nbsp;   needs: packaging



&nbsp;   steps:

&nbsp;     - name: Déploiement sur Azure

&nbsp;       uses: appleboy/ssh-action@v1

&nbsp;       with:

&nbsp;         host: ${{ secrets.VM\_HOST }}

&nbsp;         username: ${{ secrets.VM\_USERNAME }}

&nbsp;         key: ${{ secrets.VM\_SSH\_KEY }}

&nbsp;         script: |

&nbsp;           echo ${{ secrets.GHCR\_PAT\_BIS }} | docker login ghcr.io -u ${{ github.actor }} --password-stdin



&nbsp;           docker pull ${{ env.DOCKER\_IMAGE\_NAME }}:latest



&nbsp;           docker stop demo-website || true

&nbsp;           docker rm demo-website || true



&nbsp;           docker run -d \\

&nbsp;             -p 80:80 \\

&nbsp;             --name demo-website \\

&nbsp;             --restart always \\

&nbsp;             ${{ env.DOCKER\_IMAGE\_NAME }}:latest



 

&nbsp;

&nbsp;

