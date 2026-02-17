## Principe, pattern, architecture : trois niveaux distincts

Il est important de ne pas confondre ces trois notions.

---

### Le principe

Un **principe** est une **règle générale** qui guide la conception. Il décrit un objectif ou une contrainte, sans imposer une solution concrète.

**Exemples :**

- Les principes SOLID (Single Responsibility, Open/Closed, Liskov Substitution, Interface Segregation, Dependency Inversion)

- DRY, KISS, YAGNI
    - Don't repeat yourself : Le même logique de calcul copiée dans trois services différents => une seule méthode Calculer() utilisée partout
    - Keep it simple, stupid : la solution la plus simple est la meilleur pas besoin de complexifier 
    - you aren't gonna need it : ne pas développer une fonctionnalité tant qu'elle n'est pas reellement necessaire => prevoir le multilangue alors qu'on en a pas besoin maintenant.

Un principe répond à la question : **« Que doit-on respecter ? »**

---

### Le design pattern

Un **design pattern** est une **solution concrète** à un problème de conception. Il propose une structure de code et des responsabilités précises.

**Exemples :**

- **Repository** : abstraire l’accès aux données
- **Adapter** : faire correspondre une interface à une autre
- **Strategy** : encapsuler un algorithme interchangeable
- **Decorator** : ajouter des comportements sans modifier le code existant

Un pattern répond à la question : **« Comment résoudre ce problème ? »**

---

### L’architecture

L’**architecture** décrit l’**organisation globale** d’une application : couches, modules, flux de données et responsabilités au niveau système.

**Exemples :**

- Architecture en couches (présentation, métier, accès aux données)
- Clean Architecture
- Architecture hexagonale
- Architecture microservices

L’architecture répond à la question : **« Comment est structurée l’application ? »**

---

## on a déjà utilisé des patterns

Deux patterns : le **Repository** et l’**injection de dépendances**.

### Repository pattern

Le Repository abstrait l’accès aux données. Au lieu d’appeler directement une base de données ou une API, vous manipulez une interface :

```csharp
public interface IOrderRepository
{
    Order GetById(int id);
    void Add(Order order);
    void Update(Order order);
}
```

**Problème résolu** : séparer la logique métier de la façon dont les données sont stockées et récupérées.

---

### Injection de dépendances (DI)

L’injection de dépendances fournit à une classe les objets dont elle a besoin, au lieu qu’elle les crée elle-même :

```csharp
public class OrderService
{
    private readonly IOrderRepository _repository;

    public OrderService(IOrderRepository repository)
    {
        _repository = repository;
    }
}
```

**Problème résolu** : réduire le couplage entre les classes et faciliter les tests et les changements d’implémentation.

---