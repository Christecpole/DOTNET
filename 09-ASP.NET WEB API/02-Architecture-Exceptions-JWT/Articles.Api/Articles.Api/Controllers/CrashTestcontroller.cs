using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Articles.Api.Controllers
{
    /*
     
     
     Voici les "types d'alarmes" que nous utilisons pour signaler un problème :

    | Exception | Signification (en français) | Exemple concret |
    |-----------|-----------------------------|------------------|
    | `NotFoundException` | "Je ne trouve pas ce que tu demandes" | Article ID 999 n'existe pas |
    | `ArgumentException` | "Ce que tu m'as donné n'a pas de sens" | Page = -5 (impossible) |
    | `UnauthorizedAccessException` | "Tu n'as pas le droit de faire ça" | Supprimer sans être admin |
    | `KeyNotFoundException` | "Cette clé n'existe pas dans ma liste" | Dictionnaire sans la clé demandée |
    | `InvalidOperationException` | "Cette action est impossible dans l'état actuel" | Annuler une commande déjà livrée |

---
     
     
     */
    [Route("api/[controller]")]
    [ApiController]
    public class CrashTestcontroller : ControllerBase
    {
        [HttpGet("boom")]
        public IActionResult Boom()
        {
            // Erreur classique
            // .Net va lancer une exception "DivideByZeroException"
            int i = 0;
            return Ok(10 / i);
        }

        [HttpGet("calcul/{nombre}")]
        public IActionResult Calcul(int nombre)
        {
            if(nombre < 0)
            {
                throw new ArgumentOutOfRangeException("Le nombre ne doit pas être négatif");
            }
            return Ok(Math.Sqrt(nombre)); //Retourne la racine carré d'un nombre

        }

        [HttpGet]
        public IActionResult GetAncienMode(int id)
        {
            try
            {
                // imagine un appel à un service
                if (id == 99) throw new Exception("Cet Id n'existe pas");

                return Ok(new { Resultat = "Succès" });
            }
            catch (Exception ex)
            {
                //On doit formatter l'erreur manuellement
                return BadRequest(new { Message = "Erreur gérée manuellement", Detail = ex.Message });
            }
        }
    }
}
