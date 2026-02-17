### Objectif

Afficher un message clair à l'utilisateur après une action ( enregistrement, suppriession, il y a une erreur)

En mvc c'est le comportement que l'on doit avoir lorsqu'on créé, modifie supprime une ressource (succès ou erreur)


### Variantes 
-'alert-success' => succès vert
-'alert-danger' => erreur rouge
-'alert-warning' => avertissement orange
-'alert-info' => information bleu

### Exemple

```html
    <div class="alert alert-success" role="alert">Enregistrement réussi.</div>
```
```html alert avec un lien
<div class="alert alert-info" role="alert">
  Nouveau : <a href="#" class="alert-link">voir les nouveautés</a>.
</div>
```


