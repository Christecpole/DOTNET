using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Articles.Api.Models
{
    [Table("articles")]
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Titre { get; set; } = string.Empty;

        [Required]
        [MaxLength(5000)]
        public string Contenu { get; set; } = string.Empty;

        [ForeignKey("Auteur")]
        public int AuteurId { get; set; }
        public Auteur? Auteur { get; set; }
    }
}
