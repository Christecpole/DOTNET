#  Exercice : Architecture microservices – Gestion de voyages

##  Objectif

Mettre en place une application composée de **2 microservices** et **1 API Gateway** permettant :

* de gérer des voyages
* de réserver un voyage
* de consulter les réservations d’un voyage

---

#  Architecture attendue

```
Client
   ↓
API Gateway (port 8080)
   ↓
---------------------------------
|                               |
Service Voyage (8081)     Service Réservation (8082)
```

 Les services ne doivent pas être accessibles directement depuis le client (uniquement via la Gateway).

---

#  Contraintes techniques

* Architecture REST
* Format JSON
* Chaque service possède sa propre base de données (ou stockage mémoire)
* Communication HTTP entre services
* Docker recommandé (optionnel)

---

#  Service Voyage (Port 8081)

##  Responsabilités

* Créer un voyage
* Lister les voyages
* Récupérer un voyage par ID

##  Modèle Voyage

```json
{
  "id": 1,
  "destination": "Paris",
  "dateDepart": "2026-06-15",
  "prix": 250
}
```

## Endpoints

### ➜ POST /voyages

Créer un voyage

### ➜ GET /voyages

Lister tous les voyages

### ➜ GET /voyages/{id}

Récupérer un voyage

---

#  Service Réservation (Port 8082)

##  Responsabilités

* Créer une réservation
* Lister les réservations
* Lister les réservations pour un voyage donné

## Modèle Réservation

```json
{
  "id": 1,
  "voyageId": 1,
  "nomClient": "Dupont",
  "nombrePlaces": 2
}
```

 Une réservation doit obligatoirement être liée à un voyage existant.

 Le Service Réservation doit appeler le **Service Voyage** pour vérifier que le voyage existe avant de créer la réservation.

##  Endpoints

### ➜ POST /reservations

Créer une réservation

### ➜ GET /reservations

Lister toutes les réservations

### ➜ GET /reservations/voyage/{voyageId}

Lister les réservations d’un voyage

---

#  API Gateway (Port 8080)

##  Rôle

* Point d’entrée unique de l’application
* Redirection des requêtes vers les bons services

##  Routage attendu

| Requête client       | Redirection vers    |
| -------------------- | ------------------- |
| /api/voyages/**      | Service Voyage      |
| /api/reservations/** | Service Réservation |


---

#  Bonus (optionnel)

* Gestion des erreurs centralisée dans la Gateway
* Limitation du nombre de places disponibles
* Mise en place de Docker Compose
* Ajout d’un circuit breaker
* Limitation du nombre de places disponibles

