 ### Exercice : Gestion de Paiements

Vous allez créer un programme pour gérer différents types de paiements. Vous allez implémenter une interface commune pour les paiements et ensuite créer des classes spécifiques pour différents modes de paiement : Carte de Crédit et PayPal.

#### Étapes de l'exercice :

1. **Définir l'interface `Paiement`:**
   - Méthode `effectuerPaiement(double montant)`: qui accepte un montant et retourne une chaîne indiquant le succès ou l'échec du paiement.

2. **Créer la classe `CarteDeCredit` qui implémente l'interface `Paiement`:**
   - Attributs : numéro de carte, titulaire de la carte, date d'expiration, code CVV.
   - Implémentation de la méthode `effectuerPaiement(double montant)`.

3. **Créer la classe `PayPal` qui implémente l'interface `Paiement`:**
   - Attributs : adresse email, mot de passe.
   - Implémentation de la méthode `effectuerPaiement(double montant)`.

4. **Classe principale `GestionPaiements`:**
   - Créez des instances de `CarteDeCredit` et `PayPal`.
   - Appelez la méthode `effectuerPaiement` sur ces instances et affichez le résultat.
