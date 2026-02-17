### Exercice :

Créer une page web qui affiche une liste d'étudiants avec leurs notes. La page doit remplir les fonctionnalités suivantes :
LINQ C# Moyenne ou average

1. **Afficher le nombre total d'étudiants** dans un message d'information
2. **Calculer et afficher la moyenne de toutes les notes** dans le même message
3. **Afficher un tableau** avec tous les étudiants contenant :
   - L'identifiant (ID)
   - Le prénom
   - Le nom
   - La note (format XX.X / 20)
   - Un statut visuel (badge)
4. **Gérer les badges de statut** :
   - Badge **vert** "Admis" si la note est >= 10
   - Badge **rouge** "Non admis" si la note est < 10
   - Badge **orange** "Excellent" si la note est >= 16 (en plus du badge vert/rouge)


   Les propriétés d'un étudiant : Id, Prenom, Nom, Notes
	créer 5 étudiants

Resultats visuels attendus : 
- Une alerte Bootstrap bleue affichant : "5 étudiant(s) au total | Moyenne générale : 13.70 / 20"
- Un tableau Bootstrap avec 5 lignes
- Les étudiants avec note >= 10 ont un badge vert "Admis"
- L'étudiant avec note < 10 (Sophie Bernard - 8.5) a un badge rouge "Non Admis"
- L'étudiant avec note >= 16 (Pierre Leroy - 18.0) a un badge orange "Excellent" en plus du badge vert