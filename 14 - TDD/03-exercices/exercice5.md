# Exercice TDD “Gestion d’abonnements” 

## Objectif

Développer un service qui gère des abonnements (mensuel / annuel) en **TDD**, avec tests unitaires utilisant **MSTest + Moq**.

## Règles métier

### Plans

* Monthly = 9.99 €
* Yearly = 99 €

### Méthodes à implémenter

Dans une classe `SubscriptionService` :

```csharp
void Subscribe(Guid userId, string email, PlanType plan);
void ChangePlan(Guid userId, PlanType newPlan);
void Cancel(Guid userId, string email);
```

### Modèle

#### Enum

```csharp
enum PlanType { Monthly, Yearly }
```

#### Classe

```csharp
class Subscription
{
    Guid UserId;
    PlanType Plan;
    bool IsActive;
}
```

### Dépendances (à mocker)

```csharp
public interface IPaymentGateway
{
    bool Charge(Guid userId, decimal amount);
}

public interface ISubscriptionRepository
{
    Subscription? GetByUserId(Guid userId);
    void Save(Subscription subscription);
}

public interface IEmailSender
{
    void Send(string email, string message);
}
```

### Contraintes de validation

* `userId == Guid.Empty` → exception métier
* `email` null/vide/blanc → exception métier

### Subscribe

* Refuse si un abonnement **actif** existe déjà pour l’utilisateur
* Appelle le paiement avec le prix du plan
* Si paiement échoue :

  * lève une exception métier
  * ne sauvegarde pas
  * n’envoie pas d’email
* Si paiement OK :

  * crée/active l’abonnement
  * sauvegarde
  * envoie un email

### ChangePlan

* Refuse si pas d’abonnement actif
* Si `newPlan` == plan actuel : ne fait rien (pas de save, pas de paiement)
* Si Monthly → Yearly : paiement obligatoire (charge `99`)
* Si Yearly → Monthly : pas de paiement
* Sauvegarde le nouvel abonnement si changement

### Cancel

* Refuse si aucun abonnement
* Met `IsActive = false`
* Sauvegarde
* Envoie un email

 