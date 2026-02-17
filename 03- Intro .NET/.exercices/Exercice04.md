# Exercice C# - Système de Gestion d'Inventaire de Magasin

## Objectif
Créer un programme de gestion d'inventaire pour un magasin qui utilise des tableaux et des fonctions pour analyser les stocks et les ventes.

## Consignes

### Partie 1 : Saisie des données
Créez un programme qui permet de :
- Demander à l'utilisateur le nombre de produits dans l'inventaire (entre 5 et 20)
- Saisir le nom de chaque produit (stocker dans un tableau de strings)
- Saisir pour chaque produit :
  - Le prix unitaire (double, entre 0.01 et 10000)
  - La quantité en stock (int, entre 0 et 1000)
  - Le nombre d'unités vendues ce mois (int, entre 0 et 1000)

### Partie 2 : Fonctions à implémenter


1. **`double CalculerValeurStock(double[] prix, int[] quantites)`**
   - Calcule la valeur totale du stock (prix × quantité pour chaque produit)
   - Retourne la valeur totale

2. **`double CalculerChiffreAffaires(double[] prix, int[] ventes)`**
   - Calcule le chiffre d'affaires total (prix × ventes pour chaque produit)
   - Retourne le chiffre d'affaires

3. **`string TrouverProduitPlusCher(string[] noms, double[] prix)`**
   - Trouve le nom du produit le plus cher
   - Retourne le nom du produit

4. **`string TrouverProduitLePlusVendu(string[] noms, int[] ventes)`**
   - Trouve le nom du produit avec le plus de ventes
   - Retourne le nom du produit

5. **`int CompterProduitsEnRupture(int[] quantites)`**
   - Compte combien de produits ont un stock de 0
   - Retourne le nombre de produits en rupture

6. **`int CompterProduitsStockFaible(int[] quantites, int seuil)`**
   - Compte combien de produits ont un stock inférieur au seuil donné
   - Retourne le nombre de produits en stock faible

7. **`void AfficherFicheProduit(string nom, double prix, int quantite, int ventes)`**
   - Affiche la fiche complète d'un produit :
     - Nom
     - Prix unitaire
     - Quantité en stock
     - Nombre de ventes
     - Chiffre d'affaires généré (prix × ventes)
     - Statut : "En rupture" (stock = 0), "Stock faible" (< 10), "Stock correct" (>= 10)

8. **`double CalculerMoyenne(double[] valeurs)`**
   - Calcule et retourne la moyenne d'un tableau de valeurs

9. **`void AfficherAlerteStock(string[] noms, int[] quantites, int seuil)`**
   - Affiche la liste des produits dont le stock est inférieur au seuil
   - Affiche "Aucune alerte" si tous les stocks sont suffisants

### Partie 3 : Programme principal

Dans votre fonction `Main()`, vous devez :
1. Saisir toutes les données (noms, prix, quantités, ventes)
2. Afficher la fiche de chaque produit
3. Afficher les statistiques globales :
   - Valeur totale du stock
   - Chiffre d'affaires total du mois
   - Prix moyen des produits
   - Produit le plus cher
   - Produit le plus vendu
   - Nombre de produits en rupture
   - Nombre de produits en stock faible (< 10)
4. Afficher les alertes de stock (produits avec stock < 10)

### Partie 4 : BONUS (optionnel)

Si vous souhaitez aller plus loin :

1. **`void TrierParVentes(string[] noms, double[] prix, int[] quantites, int[] ventes)`**
   - Trie tous les tableaux par ordre décroissant de ventes (tri à bulles)
   - Modifie les tableaux en place pour garder la cohérence

2. **`void AfficherTopVentes(string[] noms, int[] ventes, int top)`**
   - Affiche le top N des produits les plus vendus

3. **`double CalculerTauxRotation(int ventes, int stock)`**
   - Calcule le taux de rotation d'un produit (ventes / stock)
   - Retourne 0 si le stock est à 0

4. Ajouter un menu interactif permettant de :
   - Afficher toutes les fiches produits
   - Afficher les statistiques globales
   - Afficher les alertes de stock
   - Rechercher un produit par nom
   - Afficher le top 5 des ventes
   - Quitter le programme

## Exemple d'exécution attendu

```
=== SYSTÈME DE GESTION D'INVENTAIRE ===

Combien de produits dans l'inventaire ? 3

--- Produit 1 ---
Nom : Laptop
Prix unitaire : 899.99
Quantité en stock : 15
Ventes du mois : 8

--- Produit 2 ---
Nom : Souris
Prix unitaire : 25.50
Quantité en stock : 3
Ventes du mois : 22

--- Produit 3 ---
Nom : Clavier
Prix unitaire : 65.00
Quantité en stock : 0
Ventes du mois : 5

=== FICHES PRODUITS ===

--- Fiche : Laptop ---
Prix unitaire : 899.99 €
Quantité en stock : 15
Ventes du mois : 8
Chiffre d'affaires : 7199.92 €
Statut : Stock correct

--- Fiche : Souris ---
Prix unitaire : 25.50 €
Quantité en stock : 3
Ventes du mois : 22
Chiffre d'affaires : 561.00 €
Statut : Stock faible

--- Fiche : Clavier ---
Prix unitaire : 65.00 €
Quantité en stock : 0
Ventes du mois : 5
Chiffre d'affaires : 325.00 €
Statut : En rupture

=== STATISTIQUES GLOBALES ===
Valeur totale du stock : 13694.35 €
Chiffre d'affaires du mois : 8085.92 €
Prix moyen des produits : 330.16 €
Produit le plus cher : Laptop (899.99 €)
Produit le plus vendu : Souris (22 ventes)
Produits en rupture : 1
Produits en stock faible : 2

=== ALERTES DE STOCK ===
 Souris - Stock : 3 (Réapprovisionner)
 Clavier - Stock : 0 (URGENT - Rupture)
```



