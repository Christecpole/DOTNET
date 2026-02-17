namespace ApiClient.Dtos
{
    public class ClientDtoListe
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime DateInscription { get; set; }
        public string DateInscriptionFormatee => DateInscription.ToString("dd/MM/yyyy");

    }
}
