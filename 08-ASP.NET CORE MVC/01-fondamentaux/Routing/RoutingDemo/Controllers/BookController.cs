using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    /// <summary>
    /// Créez un stysteme de gestion de bibliotheque avec le routing conventionnel
    /// 
    /// Liste de tous les livres ("/Book")
    /// Details d'un livre par ID ("/Book/Details/123")
    /// Livres par genre ("Book/Genre/Fantasy")
    /// Recherche avec une pagination ("Book/Search?title=potter&page=2")
    /// 
    /// Créer une route personnalisée pour les nouveautés ("/nouveautes/2026/06")
    /// </summary>
    public class BookController : Controller
    {
        //URL : Book/Index ou Book
        public IActionResult Index()
        {
            return Content("Liste de tous les livres");
        }

        //URL : Book/Details/123
        public IActionResult Details(int id) 
        {
            return Content($"Livre : {id}");
        }

        //URL : Book/Genre/fantasy
        public IActionResult Genre(string genre)
        {
            return Content($"Livre du genre : {genre}");
        }

        // Book/Search?title=potter&page=2
        public IActionResult Search(string title, int page = 1)
        {
            return Content($"Recherche '{title}' - Page {page}");
        }

        // URL : /nouveautes/2026/06
        public IActionResult Nouveautes(int year, int month)
        {
            return Content($"Nouveauté de {month}/{year}");
        }


        /*
         
         
         ```
┌────────────────────────────────────────────────────────────┐
│                    À RETENIR                               │
├────────────────────────────────────────────────────────────┤
│                                                            │
│  • Pattern par défaut : {controller}/{action}/{id?}        │
│                                                            │
│  • Valeurs par défaut : {controller=Home}                 │
│                                                            │
│  • Paramètres optionnels : {id?} (le ? = optionnel)       │
│                                                            │
│  • L'ordre des routes compte !                             │
│     → Routes spécifiques AVANT routes génériques           │
│                                                            │
│  • Les paramètres sont automatiquement liés                │
│     → Le nom doit correspondre au segment                 │
│                                                            │
│  • Les méthodes doivent être public                        │
│                                                            │
│  • Le suffixe "Controller" est obligatoire                 │
│                                                            │
└────────────────────────────────────────────────────────────┘
```
         
         
         
         */


    }
}
