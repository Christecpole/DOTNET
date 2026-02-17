### QUOI : Qu'allons-nous construire ?

Vous allez créer une **application CRUD complète de gestion de produits** avec :
- Des **Models** (`Produit`, `Categorie`) pour la structure de la base de données
- Des **ViewModels** (`ProduitFormViewModel`, `ProduitDetailsViewModel`, `ProduitListItemViewModel`) avec Data Annotations pour la validation et l'affichage
- Une **page Index** : liste des produits dans un tableau avec boutons d'action
- Une **page Details** : affichage détaillé d'un produit
- Une **page Create** : formulaire de création avec validation
- Une **page Edit** : formulaire de modification avec validation
- Une **fonctionnalité Delete** : suppression avec popup de confirmation
- Des **Extensions de mapping** pour transformer Model ↔ ViewModel

**Consigne :** Créer une application CRUD complète de gestion de produits en utilisant des Models typés et des ViewModels.

**Partie 1 : Créer les Models (Structure BDD uniquement)**  
   - Créer `Models/Categorie.cs` avec la structure de la BDD
   - Créer `Models/Produit.cs` avec la structure de la BDD et relations
   - **PAS de Data Annotations dans les Models** (validations dans les ViewModels)

**Partie 2 : Créer les ViewModels**  
   - Créer `ViewModels/Produits/ProduitFormViewModel.cs` pour Create/Edit
   - Créer `ViewModels/Produits/ProduitDetailsViewModel.cs` pour Details
   - Créer `ViewModels/Produits/ProduitListItemViewModel.cs` pour Index (bonne pratique stricte)

**Partie 3 : Créer les Extensions de Mapping**  
   - Créer `Extensions/ProduitMappingExtensions.cs`
   - Méthodes : `ToFormViewModel()`, `ToModel()`, `ToDetails()`, `ToListItem()`

**Partie 4 : Créer le Controller avec toutes les actions CRUD**  
   - Créer `Controllers/ProduitsController.cs`
   - Actions : Index, Details, Create (GET/POST), Edit (GET/POST), Delete (GET/POST)
   - Utiliser les ViewModels et les Extensions

**Partie 5 : Créer les Vues**  
   - Créer `Views/Produits/Index.cshtml` avec tableau (utilise `ProduitListItemViewModel`)
   - Créer `Views/Produits/Details.cshtml` avec ViewModel
   - Créer `Views/Produits/Create.cshtml` avec formulaire et validation
   - Créer `Views/Produits/Edit.cshtml` avec formulaire et validation
   - Ajouter un modal Bootstrap dans `Views/Produits/Details.cshtml` pour la suppression
   - (La vue `Delete.cshtml` n'est pas nécessaire avec les modals)



Deux classes : Produit et catégorie

produit contient : 
Id, 
Nom, 
Description, 
Prix, 
QuantiteStock, 
DateCreation, 
CategorieId, 
Categorie(propriété de navigation), 
EstEnStock(retourne true si stock > 0 sinon false

categorie contient : 
Id,
Nom,
Description
List<Produit> (propriété de navigation)