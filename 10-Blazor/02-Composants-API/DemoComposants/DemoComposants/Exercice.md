
Créer un composant `Alerte.razor` qui :

1. Reçoit un `Message` en paramètre
2. Reçoit un `Type` en paramètre (success, warning, danger, info)
3. Affiche le message dans une div Bootstrap `alert alert-{type}`

### Résultat attendu

- Une alerte verte avec "Opération réussie !"
- Une alerte orange avec "Attention, fichier volumineux"
- Une alerte rouge avec "Erreur de connexion"

Améliorer le composant `Alerte` :
1. Ajouter un bouton "×" pour fermer l'alerte
2. Quand on clique sur "×", l'alerte doit prévenir son parent via `EventCallback`
3. La page doit masquer l'alerte
