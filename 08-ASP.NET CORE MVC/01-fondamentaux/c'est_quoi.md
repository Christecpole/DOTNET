### definition

framework => un ensemble d'outils  créé par microsoft pour nous permettre de construire "facilement" de manière organisée et pro.

exemple : 

si on veut construire une maison :
- les briques => c#
- plan d'architecture : architecture mvc
- outils : framework
- l'équipe : developpeur
==> la maison : l'application web

Asp mvc core : architecture + un ensemble d'outils

ASP.NET core

-ASP : Active server pages (pages serveur actives)
-.NEt : La plateforme microsoft , l'ensemble .Net 

-MVC :
M => model => les données
V => view => l'affichage
C => controller ==> coordinateur

==> façon d'organiser notre code 

### comment ca fonctionne :

asp.Net core mvc transforme une requete en une page web que l'utilisateur veut voir.
https://monsite.com/produits/details/5

produits => controller
details => action
5 => 

2. le navigateur evoie une requête http au server :
"Je veux voir le produit numéro 5"
le serveur = la machine qui heberge notre appli
recoit la requete , analyser l'url : "Controller : produit , action = details et l'id (parametre ) est 5"

3. Controller : demande au model de lui rapporter les données, le detail du produit numéro 5.

4. le model renvoie répond au controller en lui donnant ce qu'il a demander à savoir : le detail d'un produit

5.Le controller renvoyer la vue en lui passant la donné pour qu'elle l'affiche.

6.L'utilisateur voit la page avec le produit.



Avantages en plusieurs couche:
"maintenable" facile de modifier une partie sans casser le reste
"clareté" facile de trouver où se trouve chaque fonctionnalité

```
┌──────────────┐
│   NAVIGATEUR │
│  (Utilisateur)│
└──────┬───────┘
       │ 1. Requête HTTP
       │ /produits/details/5
       ▼
┌─────────────────────┐
│   CONTROLLER        │
│  ProductController  │
│                     │
│  Details(int id)    │
└──────┬──────────────┘
       │ 2. "Donne-moi le produit 5"
       ▼
┌─────────────────────┐
│      MODEL          │
│      Product        │
│                     │
│  - Id               │
│  - Name             │
│  - Price            │
│  - IsAvailable      │
└──────┬──────────────┘
       │ 3. Retourne les données
       ▼
┌─────────────────────┐
│   CONTROLLER        │
│                     │
│  return View(product)│
└──────┬──────────────┘
       │ 4. "Affiche ces données"
       ▼
┌─────────────────────┐
│       VIEW          │
│  Details.cshtml     │
│                     │
│  Génère le HTML     │
└──────┬──────────────┘
       │ 5. Page HTML
       ▼
┌──────────────┐
│   NAVIGATEUR │
│  (Affiche)   │
└──────────────┘
```

```csharp
// MAUVAIS EXEMPLE - Code spaghetti
// Tout est mélangé : données, logique, affichage

public void AfficherProduit(int id)
{
    var connection = new SqlConnection("Server=...");
    connection.Open();
    
    var command = new SqlCommand("SELECT * FROM Products WHERE Id = " + id);
  
    
    var reader = command.ExecuteReader();
    
    Console.WriteLine("<html>");
    Console.WriteLine("<body>");
    Console.WriteLine("<h1>" + reader["Name"] + "</h1>");
    Console.WriteLine("<p>Prix: " + reader["Price"] + " €</p>");
    
    if ((decimal)reader["Price"] > 100)
    {
        Console.WriteLine("<span style='color: red'>Produit premium</span>");
    }
    
    Console.WriteLine("</body>");
    Console.WriteLine("</html>");
}
```


