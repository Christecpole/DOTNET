# Architecture Microservices avec ASP.NET Core
## Plateforme de Signalement Naturaliste 
---

## 1. Contexte du Projet

Vous êtes développeur .NET au sein d'une startup écologique. L'équipe a décidé de refondre l'application **NaturObs** — une plateforme de signalement d'espèces animales et végétales — en adoptant une **architecture microservices**.

L'application doit permettre de :

- Signaler la présence d'espèces animales ou végétales dans la nature
- Visualiser les signalements par zone géographique
- Filtrer les signalements par espèce, date ou région
- Calculer l'empreinte carbone liée aux déplacements effectués lors des observations
- **Authentifier et autoriser les utilisateurs** via un service dédié

> **Contrainte architecturale**
>
> L'application est décomposée en **4 microservices indépendants** communicant via HTTP REST.
> Chaque service possède sa propre base de données (*pattern Database per Service*).
> La sécurité est assurée par des **tokens JWT** émis par l'`AuthService` et validés localement par chaque service.

---

## 2. Architecture Générale

### 2.1 Vue d'ensemble des services

| Service | Port | Responsabilité | Base de données |
|---|---|---|---|
| `AuthService` | 5001 | Inscription, connexion, émission JWT | Mysql |
| `SpeciesService` | 5002 | Gestion du catalogue d'espèces | Mysql  |
| `ObservationService` | 5003 | Signalements naturalistes | Mysql  |
| `TravelLogService` | 5004 | Déplacements + calcul CO₂ | Mysql |
| `Gateway` | 5000 | Api d'acces au systeme | |

### 2.2 Schéma d'authentification JWT

> **Flux d'authentification (JWT Bearer Token)**
>
> 1. Le client envoie `POST /api/auth/login` avec `{ username, password }`
> 2. L'`AuthService` valide les credentials et retourne un JWT
> 3. Le client inclut le token dans chaque requête : `Authorization: Bearer <token>`
> 4. L'api Gateway se charge de verifié le token a chaque requete
> 5. Les endpoints protégés retournent `401` si le token est absent, invalide ou expiré

### 2.3 Structure de la solution

```
NaturObs.sln
├── AuthService/
│   ├── AuthService.csproj
│   ├── Controllers/AuthController.cs
│   ├── Models/User.cs
│   ├── DTOs/
│   ├── Services/
│   └── appsettings.json
├── SpeciesService/
│   ├── SpeciesService.csproj
│   └── ...
├── ObservationService/
│   ├── ObservationService.csproj
│   └── ...
└── TravelLogService/
    ├── TravelLogService.csproj
    └── ...
```

## 3. Microservice : AuthService (port 5001)

### 3.1 Modèles

#### Classe `User`

| Propriété | Type C# | Contrainte |
|---|---|---|
| `Id` | `int` | Clé primaire, auto-générée |
| `Username` | `string` | Unique, non nul, 3–50 caractères |
| `PasswordHash` | `string` | Haché BCrypt, non nul |
| `Email` | `string` | Unique, format email valide |
| `Role` | `Role` (enum) | Défaut : `User` |
| `CreatedAt` | `DateTime` | Initialisé à la création |

#### Enum `Role`

```csharp
public enum Role
{
    User,
    Admin
}
```

### 3.2 DTOs

Vous devez créer les DTOs suivants :

```csharp
public class RegisterRequest(){
     string Username,
    string Password,
    string Email
};

public class LoginRequest(){
    string Username,
    string Password
};

public class AuthResponse(){
    string Token,
    string Username,
    string Role,
    long ExpiresIn
};
```

### 3.3 Endpoints REST

| Méthode | URL | Auth requise | Description |
|---|---|---|---|
| `POST` | `/api/auth/register` | Non | Créer un compte utilisateur |
| `POST` | `/api/auth/login` | Non | Connexion, retourne un JWT |
| `GET` | `/api/auth/me` | Oui (JWT) | Profil de l'utilisateur connecté |

---

## 4. Microservice : SpeciesService (port 5002)

### 4.1 Modèle `Species`

| Propriété | Type C# | Contrainte |
|---|---|---|
| `Id` | `int` | Clé primaire |
| `CommonName` | `string` | Non nul |
| `ScientificName` | `string` | Unique, non nul |
| `Category` | `Category` (enum) | Non nul |

#### Enum `Category`

```csharp
public enum Category
{
    Bird,
    Mammal,
    Insect,
    Plant,
    Other
}
```

### 4.2 Endpoints REST

| Méthode | URL | Auth | Description |
|---|---|---|---|
| `GET` | `/api/species` | Non | Liste de toutes les espèces |
| `GET` | `/api/species/{id}` | Non | Détails d'une espèce |
| `POST` | `/api/species` | `Admin` | Ajouter une espèce |
| `PUT` | `/api/species/{id}` | `Admin` | Modifier une espèce |
| `DELETE` | `/api/species/{id}` | `Admin` | Supprimer une espèce |

---

## 5. Microservice : ObservationService (port 5003)

### 5.1 Modèle `Observation`

| Propriété | Type C# | Contrainte |
|---|---|---|
| `Id` | `int` | Clé primaire |
| `SpeciesId` | `int` | Référence vers SpeciesService (pas de FK EF) |
| `ObserverUsername` | `string` | Extrait du JWT, non nul |
| `Location` | `string` | Non nul (ex : `"Montpellier"`) |
| `Latitude` | `double` | Entre -90 et 90 |
| `Longitude` | `double` | Entre -180 et 180 |
| `ObservationDate` | `DateOnly` | Non nul, pas dans le futur |
| `Comment` | `string?` | Optionnel |

> **Pas de navigation EF Core entre services**
>
> Chaque service stocke uniquement les IDs des entités appartenant à d'autres services.
> `ObservationService` stocke `SpeciesId` (`int`), **pas** un objet `Species`.
> Pour afficher les détails complets, le front-end ou une API Gateway effectue les appels nécessaires.

### 5.2 Endpoints REST

| Méthode | URL | Auth | Description |
|---|---|---|---|
| `GET` | `/api/observations` | Oui | Toutes les observations |
| `POST` | `/api/observations` | Oui | Créer une observation |
| `GET` | `/api/observations/{id}` | Oui | Détails d'une observation |
| `GET` | `/api/observations/by-location?location=...` | Oui | Filtrer par lieu |
| `GET` | `/api/observations/by-species/{speciesId}` | Oui | Filtrer par espèce |
| `GET` | `/api/observations/mine` | Oui | Observations de l'utilisateur connecté |


---

## 6. Microservice : TravelLogService (port 5004)

### 6.1 Modèle `TravelLog`

| Propriété | Type C# | Contrainte |
|---|---|---|
| `Id` | `int` | Clé primaire |
| `ObservationId` | `int` | Référence vers ObservationService |
| `DistanceKm` | `double` | Positif, non nul |
| `Mode` | `TravelMode` (enum) | Non nul |
| `EstimatedCo2Kg` | `double` | Calculé automatiquement, non modifiable |

#### Enum `TravelMode`

```csharp
public enum TravelMode
{
    Walking,
    Bike,
    Car,
    Bus,
    Train,
    Plane
}
```

### 6.2 Logique de calcul CO₂

| Mode de transport | Émission CO₂ (kg/km) | Exemple 100 km |
|---|---|---|
| `Walking` / `Bike` | 0.000 | 0.00 kg |
| `Car` | 0.220 | 22.00 kg |
| `Bus` | 0.110 | 11.00 kg |
| `Train` | 0.030 | 3.00 kg |
| `Plane` | 0.259 | 25.90 kg |

Le calcul doit être effectué dans une classe utilitaire dédiée :

### 6.3 Endpoints REST

| Méthode | URL | Auth | Description |
|---|---|---|---|
| `POST` | `/api/travel-logs` | Oui | Créer un déplacement (CO₂ calculé auto) |
| `GET` | `/api/travel-logs` | Oui | Liste de tous les déplacements |
| `GET` | `/api/travel-logs/stats/{observationId}` | Oui | Statistiques CO₂ par observation |

**Réponse attendue pour `/stats/{observationId}` :**

```json
{
  "totalDistanceKm": 45.5,
  "totalEmissionsKg": 8.4,
  "byMode": {
    "Car": 5.5,
    "Train": 2.9
  }
}
```
---
