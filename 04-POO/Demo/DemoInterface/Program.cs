

using Demo05Interface.Classes;

void Start()
{
    while (true)
    {
        Console.WriteLine("=== menu ===");
        Console.WriteLine("1 - affichage Basic");
        Console.WriteLine("2 - affichage Complet");

        string entry = Console.ReadLine();

        //l'interface permet de regrouper plusieur classe sous un meme type et donc de generaliser leurs utilisation
        IAffichage affichage;

        switch (entry)
        {
            case "1":
                //on viens mettre un affichage Basique dans notre variable de type IAffichage
                affichage = new AffichageBasique();
                break;
            case "2":
                //on viens mettre un affichage Complet dans notre variable de type IAffichage
                affichage = new AffichageComplet();
                break;
            default:
                return;
        }

        //peu importe que l'on est une instance de AfficheBasique ou affichage Complet ici comme on passe par une interface ici IAffichage on utilise uniquement les methode defini dans l'interface 
        affichage.AfficherMessageBienvenue();
        affichage.AfficherLaDate();
        affichage.AfficherLaClasse();
        }



}

Start();