using ModelDemo.Validation;
using System.ComponentModel.DataAnnotations;

namespace ModelDemo.Viewmodel
{
    // Class model (viewmodel) adaptée à une vue spécifique. Formulaire d'inscriprion d'un étudiant)
    public class EtudiantInscriptionViewModel
    {
        [Required(ErrorMessage ="Le nom est obligatoire")]
        [Display(Name ="Nom de l'étudiant")]
        [StringLength(50, MinimumLength =2, ErrorMessage ="Le nom doit contenir entre 2 et 50 caractères")]
        public string Nom {  get; set; }

        [EmailAddress(ErrorMessage ="Le format de l'email est invalid")]
        [Required(ErrorMessage= "L'email est obligatoire")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [MinimumAge(16, ErrorMessage ="message d'erreur provenant de l'attribut minimum age crée")]
        public DateTime DateNaissance { get; set; }




    }
}
