namespace Articles.Api.Dtos
{
    public class AuteurDto
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; } = string.Empty;
    }
}
