Console.WriteLine("Entrer votre Nom :");
string? Nom = Console.ReadLine();

Console.WriteLine("Entrer votre Prenom :");
string? Prenom = Console.ReadLine();

Console.WriteLine("Entrer votre Age :");
string? AgeStr = Console.ReadLine();
int age;
int.TryParse(AgeStr, out age);

if ( age >= 18)
{
    Console.WriteLine("Binvenue : " + Nom + " " + Prenom);

    float ardoise = 0.0f;
    bool continu = true;
    while (continu)
    {
        Console.WriteLine("--- Menu ---");
        Console.WriteLine("1- Coca");
        Console.WriteLine("2- Ice Tea");
        Console.WriteLine("3- Eau");
        Console.WriteLine("4- Café");
        Console.WriteLine("STOP- Quitter");

        Console.WriteLine("Selectioner une boisson :");
        string? entry = Console.ReadLine();

     
        switch (entry)
        {
            case "1":
                Console.WriteLine("Vous avez choisi un Coca a 1.4 euros");
                ardoise += 1.4f;
                break;
            case "2":
                Console.WriteLine("Vous avez choisi un Ice Tea a 1.2 euros");
                ardoise += 1.2f;
                break;
            case "3":
                Console.WriteLine("Vous avez choisi un Eau a 0.8 euros");
                ardoise += 0.8f;
                break;
            case "4":
                Console.WriteLine("Vous avez choisi un Café a 4 euros");
                ardoise += 4f;
                break;
            case "STOP":
                Console.WriteLine("Vous nous quitter");
                Console.WriteLine("Vous devez payer : " + ardoise + " euros");
                continu = false;
                break;
            default:
                Console.WriteLine("Choix invalide");
                break;
        }
    }
   

}
else
{
    Console.WriteLine("Vous etes Mineur !");
}