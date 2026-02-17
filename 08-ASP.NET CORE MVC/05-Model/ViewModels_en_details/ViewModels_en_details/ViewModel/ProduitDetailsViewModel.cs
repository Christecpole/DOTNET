using System.ComponentModel.DataAnnotations;

namespace ViewModels_en_details.ViewModel
{
    // classe qui sontient les données nécéssaires pour une vue spécifique. c'est un intermédiaire entre le model (données bruts) et la view (l'affichage)
    public class ProduitDetailsViewModel
    {
        public string Nom { get; set; } = string.Empty;

        [Display(Name ="Prix")]
        public string PrixFormatte {  get; set; } = string.Empty;
        public int Stock { get; set; }
        public string NomCategorie {  get; set; } = string.Empty;
    }
}
