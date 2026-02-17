using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelDemo.Models
{
    public class Etudiant
    {
        public int Id { get; set; }

        [Display(Name="Nom de l'étudiant")]
        //Le nom est obligatoire
        // Si il n'est pas remplie on a definit un message d'erreur
        //[Required(ErrorMessage ="Le prénom est obligatoire")]
        [Required(ErrorMessage= "Le {0} est obligatoire")] //{0} sera remplacé par "Nom de l'étudiant" (valeur de display.Name)
        public string Nom { get; set; } = string.Empty;

        // Limite le nombre de caractères à 100
        // minimum possible c'est 2 caractères
        [StringLength(100, MinimumLength = 2)]
        public string? Prenom { get; set; }

        [Display(Name ="Votre Email", Prompt ="etudiant@ecole.com")] // guider la personne sur le format attendu.
        [Column(TypeName = "decimal(18,2)")]
        [Range(0,20, ErrorMessage ="La note doit être entre 0 et 20")]
        public decimal Note {  get; set; }
        //Verifie que la chaine de caractère est un email, ressemble à un email
        [EmailAddress(ErrorMessage ="Format d'email invalide")]
        public string Email { get; set; }

        [Column("Telephone")] // renomme la colonne en bbdd
        [Required(ErrorMessage ="Le numéro de téléphone est obligatoire")]
        [Phone(ErrorMessage ="Numéro de téléphone est invalide")]
        public string NumeroTelephone { get; set; }

        [Url(ErrorMessage ="Url est invalide")]
        public string portfolioUrl { get; set; }

        // empeche les ages négatifs
        // donne un age minimal et maximal
        [Range(16, 100, ErrorMessage ="L'âge doit être compris entre 16 et 100 ans")]
        public int Age { get; set; }
        public DateTime DateNaissance { get; set; }

        //Propriétés calculées
        public bool IsAdult => Age >= 18;
        //public bool Isbool
        //{
        //    get
        //    {
        //        return Age >= 0;
        //    }
        //}

        // indique qu'elle n'existe pas en bdd
        // elle ne doit pas être stocké.
        [NotMapped]
        public string NomComplet 
        {
            get
            {
                return $"{Nom} {Prenom}";
            }
        }

        [NotMapped]
        public string CategorieAge
        {
            get
            {
                if (Age < 18) return "Mineur";
                if (Age <= 25) return "Jeune Adulte";
                return "Adulte";
            }
        }

        // indique la sémentique de la donnée.
        [DataType(DataType.MultilineText)] // genère un textarea
        [Display(Name="La vie de l'étudiant")]
        public string biographie {  get; set; }

        [DataType(DataType.Currency)]// indique que c'est un montant monétaire
        [Display(Name ="Les frais de scolarité")]
        public decimal montant {  get; set; }

        [DataType(DataType.Date)]
        [Display(Name ="Date d'inscription")]
        public DateTime DateInscription { get; set; }

        // Utilise "=>" pour des calcules , retours simples, "get {}" pour de la logique complexe
     
        // Clé étrangère : reference vers la classe
        public int ClasseId { get; set; }
        // propriété de navigation : accèder à la classe
        public Classe Classe { get; set; }


        // propriété de navigation vers les cours
        public List<Cours> Cours { get; set; } = new List<Cours>();


    }
}
