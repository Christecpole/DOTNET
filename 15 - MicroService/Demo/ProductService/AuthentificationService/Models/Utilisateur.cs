namespace Articles.Api.Models
{
    //représente un utilisateur dans notre bdd
    public class Utilisateur
    {
        public int Id { get; set; }
        // Email : login de l'utilisateur
        // required : oblige à initialiser cette propriété.
        public required string Email { get; set; }
        public required string MotDePasse { get; set; }
        public required string Role { get; set; }
    }
}
