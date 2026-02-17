### Objectif

Présenter une liste d'élements (produits) avec des actions par ligne : details, modifier, supprimer

### classes essentielles
- Base : 'table'
- Variantes : 'table-striped', 'table-hover', 'table-sm'
- Responsive : 'table-responsive'

### Exemple 

```html
<div class="table-responsive">
  <table class="table table-striped table-hover align-middle">
    <thead>
      <tr>
        <th>Id</th>
        <th>Nom</th>
        <th class="text-end">Prix</th>
        <th class="text-end">Stock</th>
        <th>Actions</th>
      </tr>
    </thead>
    <tbody>
      <tr>
        <td>1</td>
        <td>Exemple</td>
        <td class="text-end">9,90 €</td>
        <td class="text-end">12</td>
        <td class="d-flex gap-2 flex-wrap">
          <a class="btn btn-sm btn-primary" href="#">Détail</a>
          <a class="btn btn-sm btn-outline-warning" href="#">Modifier</a>
          <button class="btn btn-sm btn-danger" type="button">Supprimer</button>
        </td>
      </tr>
    </tbody>
  </table>
</div>
```