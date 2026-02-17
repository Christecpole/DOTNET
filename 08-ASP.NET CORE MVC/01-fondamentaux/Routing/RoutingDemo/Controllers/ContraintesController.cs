using Microsoft.AspNetCore.Mvc;

namespace RoutingDemo.Controllers
{
    /// <summary>
    /// permettre de valider les paramètres
    /// - Les contraintes valident le format **AVANT** d'appeler l'action
    /// </summary>

    [Route("test")]
    public class ContraintesController : Controller
    {
        // :int : le segment doit etre un entier
        [Route("number/{id:int}")]
        public IActionResult Number(int id)
        {
            return Content($"Nombre reçu en paramètre : {id}");
        }

        // :int:range(1,100) = Entier doit etre entre 1 et 100
        [Route("range/{value:int:range(1,100)}")]
        public IActionResult Range(int value)
        {
            return Content($"Valeur dans la plage : {value}");
        }

        // :alpha = lettre uniquement, :minlenght(3) : minimum 3 caractères.
        [Route("name/{value:alpha:minlength(3)}")]
        public IActionResult Name(string value)
        {
            return Content($"Nom Valide: {value}");
        }


        /*
         
         **Contraintes principales :**

| Contrainte | Description | Exemple valide | Exemple invalide |
|------------|-------------|----------------|------------------|
| `:int` | Entier | `123` | `abc` |
| `:alpha` | Lettres uniquement | `Jean` | `Jean123` |
| `:minlength(n)` | Longueur minimum | `abc` (n=3) | `ab` |
| `:maxlength(n)` | Longueur maximum | `ab` (n=3) | `abcd` |
| `:range(n,m)` | Valeur entre n et m | `5` (1,10) | `15` |
| `:datetime` | Date valide | `2024-06-15` | `abc` |
         
         
         */
    }
}
