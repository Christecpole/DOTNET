using System.Runtime.InteropServices;

namespace CorrectionExo1.Classes;

public class Chaise
{
    public int NbPieds { get; set; }
    public string? Materiaux { get; set; }
    public string? Couleur { get; set; }

    public Chaise() { }

    public Chaise(int nbPieds, string materiaux, string couleur)
    {
        NbPieds = nbPieds;
        Materiaux = materiaux;
        Couleur = couleur;
    }
    
    public void Affichage()
    {
        Console.WriteLine($"Nombre de pieds : {NbPieds} | Materiaux : {Materiaux} | Couleur : {Couleur}");
    }
    
    
}