| Méthode | Action | Code C# |
|---------|--------|---------|
| **GET** | Récupérer | `Http.GetFromJsonAsync<T>("url")` |
| **POST** | Créer | `Http.PostAsJsonAsync("url", objet)` |
| **PUT** | Modifier (tout) | `Http.PutAsJsonAsync("url", objet)` |
| **PATCH** | Modifier (partiel) | `Http.PatchAsync("url", content)` |
| **DELETE** | Supprimer | `Http.DeleteAsync("url")` |