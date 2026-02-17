using System.Globalization;

namespace ViewModels_en_details.ViewModel
{
    public class EtudiantListeViewModel
    {
        public int Id { get; set; }
        public string NomComplet {  get; set; } // Prneom + nom combinés
        public string Email { get; set; }
        public int Age { get; set; } // Age calculé
        public string NomDeLaClasse { get; set; } // relation résolu

    }
}
