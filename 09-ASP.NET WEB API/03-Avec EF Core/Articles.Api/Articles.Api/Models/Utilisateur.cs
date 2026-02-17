using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Articles.Api.Models
{
    //représente un utilisateur dans notre bdd
    [Table("utilisateurs")]
    public class Utilisateur
    {
        [Key]
        public int Id { get; set; }
        // Email : login de l'utilisateur
        // required : oblige à initialiser cette propriété.

        [Required]
        [MaxLength(150)]
        public required string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public required string MotDePasse { get; set; }

        [Required]
        [MaxLength(50)]
        public required string Role { get; set; }
    }
}
