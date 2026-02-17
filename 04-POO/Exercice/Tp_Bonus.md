## Tp Billetterie

- Nous voullon crée une application de gestion de billets pour des evenements :

- nos classe seront :
    - adresse 
        - rue
        - ville 

   - Lieu (herite de adresse) : 
        - capacité
    
   - billet :
        - numeros de place
        - client
        - Evenement
        - type de place (standar , gold, vip)


   - Evenement :
        - nom
        - lieu 
        - date
        - heure
        - nombre de place
        - Liste de Billet


  - Client :
     - nom
     - prenom
     - adresse 
     - age 
     - numeros de telephone
     - Liste de Billet


---
  
1. Réservation de Billets :

- Nos clients pourront réserver des billets pour différents événements, et chaque billet sera lié à un événement.

2. Gestion des Événements :

- Pour chaque événement, il sera possible de récupérer la liste des billets associés.

3. Interface Homme-Machine (IHM) :

- Nous souhaitons une interface utilisateur permettant de réaliser les opérations CRUD (Créer, Lire, Mettre à jour, Supprimer) pour chaque entité.

4. Exception :

- Lorsque on recherche un element pour l'afficher ou l'ajouter, si l'index recherché n'existe pas on retourne une erreure "NotFoundException" (que l'on auras crée) qui seras traité dans notre IHM.

5. Bonus : Vérification des Places Disponibles :

- Lors de la réservation d'un billet pour un événement, nous voulons vérifier si l'événement a encore des places disponibles.


