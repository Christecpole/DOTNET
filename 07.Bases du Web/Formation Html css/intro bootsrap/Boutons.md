### Objectif

standardiser l'apparence des boutons ( créer/ Enregistrer/ Modifier)

### Classes essentielles 
- Base : 'btn'
- Variantes : 'btn-primary', 'btn-secondary', 'btn-warning', 'btn-danger'
- Contours : ''btn-outline-primary', ''btn-outline-warning'...
- Tailles : 'btn-sm', 'btn-xxl' ...
- Désactivé : 'disabled' sur <button>

### Exemples

```html
<button class="btn btn-primary">Enregistrer</button>
<button class="btn btn-danger" disabled>Supprimer</button>
```

### barre d'actions

```html
<div class="d-flex gap-2 flex-wrap">
    <a class="btn btn-primary" href="#">Créer</a>
    <a class="btn btn-outline-warning"href="#">Modifier</a>
    <button class="btn btn-danger">Supprimer</button>
    <a class="btn btn-secondary" href="#">Retour</a>
</div>
```