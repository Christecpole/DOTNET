using Microsoft.AspNetCore.Mvc;

namespace ControllerDemo.Controllers
{
    /***
     * 
     * Scénario :** Vous gérez des utilisateurs. Selon les cas, vous devez retourner différents types de réponses.
     
        1. **Index()** → Affiche la liste des utilisateurs (retourne une vue)

        2. **Details(int id)** → Affiche les détails d'un utilisateur
       - Si `id <= 0` → Retourne `BadRequest("ID invalide")`
       - Si `id > 100` → Retourne `NotFound()` (utilisateur inexistant)
       - Sinon → Retourne une vue

        3. **GetUserJson(int id)** → Retourne les données d'un utilisateur en JSON
       - Créez un objet anonyme avec : `id`, `nom`, `email`
       - Exemple : `new { id = id, nom = "Dupont", email = "dupont@example.com" }`

        4. **Create()** → Simule la création d'un utilisateur
       - Après création, redirige vers `Index`

        5. **AdminPanel()** → Panneau d'administration
       - Simule une vérification : si `id` (paramètre optionnel) n'est pas égal à 1, retourne `Forbid()`
       - Sinon, retourne une vue

        - `http://localhost:5000/User/Index` → Affiche la vue (liste)
       - `http://localhost:5000/User/Details/5` → Affiche la vue (détails)
       - `http://localhost:5000/User/Details/0` → Erreur 400 (BadRequest)
       - `http://localhost:5000/User/Details/150` → Erreur 404 (NotFound)
      - `http://localhost:5000/User/GetUserJson/5` → Affiche JSON : `{"id":5,"nom":"Dupont","email":"dupont@example.com"}`
       - `http://localhost:5000/User/AdminPanel?id=1` → Affiche la vue (admin)
   - `http://localhost:5000/User/AdminPanel?id=2` → Erreur 403 (Forbid)

         */
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            if (id <= 0)
            {
                return BadRequest("ID invalide");
            }
            if(id > 100)
            {
                return NotFound();
            }
            return View();
        }

        public IActionResult GetUserJson(int id)
        {
            var user = new
            {
                id = id,
                nom = "Dupont",
                mail = "dupont@example.com"
            };


            return Json(user);
        }

        public IActionResult CreateUser() 
        {
            // Simulation de création d'un utilisateur
            // On ajouterai en bdd

            return RedirectToAction("Index");
        
        }

        public IActionResult AdminPanel(int? id)
        {
            //verifier si l'utilisateur est un admin
            if(id != 1)
            {
                return Forbid(); // HTTP 403
            }

            return View();
        }
    }
}
