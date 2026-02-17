using System.ComponentModel.DataAnnotations;

namespace ViewModels_en_details.Models
{
    public class Classe
    {
        [Key]
        public int ClasseId { get; set; }
        public string ClasseName { get; set; }
    }
}
