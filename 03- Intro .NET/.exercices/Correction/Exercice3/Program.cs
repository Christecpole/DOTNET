Console.WriteLine($"--- Difficultée --- \n 1 - Facile (4pions 12Vies) \n 2 - normal(6pions 10Vies) \n 3 - difficile (8pions 8Vies)");
Console.WriteLine("Votre choix :");
string? Difficulty = Console.ReadLine();

int NombrePions;
int NombreEssai;

switch(Difficulty)
{
    case "1":
        NombrePions = 4;
        NombreEssai = 12;
        break;
    case "2":
        NombrePions = 6;
        NombreEssai = 10;
        break;
    case "3":
        NombrePions = 8;
        NombreEssai = 8;
        break;
    default:
        NombrePions = 4;
        NombreEssai = 12;
        break;
}
;

char[] CouleursDisponibles = { 'B', 'R', 'J', 'V', 'N', 'O' };

Random rand = new Random();
string sequenceSecrete = "";

for(int i = 0; i<NombrePions; i++)
{
    int index = rand.Next(0,CouleursDisponibles.Length);
    sequenceSecrete += CouleursDisponibles[index];
}

Console.WriteLine("==== Jeu Commence ====");
Console.WriteLine($"Trouver la Séquence de {NombrePions} pions !");
Console.WriteLine("Couleurs disponible : B(Bleu),R(Rouge),J(Jaune),V(Vert),N(Noire),O(Orange)");
Console.WriteLine($"Vous avez {NombreEssai} tentatives.");

int tentative = 0;
int vieRestantes = NombreEssai;
bool gagne = false;
//bool pasEncoreGagne = true;

while(vieRestantes > 0 && !gagne)
{
    tentative++;
    char[] resultaTrouve = new char[NombrePions];
    for(int i = 0; i < NombrePions; i++)
    {
        resultaTrouve[i] = '*';
    }
    Console.WriteLine($"--- Tentative {tentative} ( vie restantes : {vieRestantes}) ---");
    Console.WriteLine($"entrer votre proposition ({NombrePions} lettres");
    string proposition = Console.ReadLine().ToUpper();

    if(proposition.Length != NombrePions)
    {
        Console.WriteLine($"Erreur : vous devez entre exactement {NombrePions} caracteres !");
        tentative--;
        continue;
    }

    bool entreeValide = true;
    foreach(var lettre in proposition)
    {
        bool couleurTrouvee = false;
        foreach(var couleur in CouleursDisponibles)
        {
            if(lettre == couleur)
            {
                couleurTrouvee = true;
                break;
            }
        }
        if (!couleurTrouvee)
        {
            entreeValide = false;
            break;
        }
    }

    if (!entreeValide)
    {
        Console.WriteLine("Erreur : utilisez uniquement les couleurs disponible ");
        Console.WriteLine("Couleurs disponible : B(Bleu),R(Rouge),J(Jaune),V(Vert),N(Noire),O(Orange)");
        tentative--;
        continue;
    }

    int bienPlaces = 0;
    int malPlaces = 0;

    bool[] secretUtilise = new bool[NombrePions];
    bool[] propositionUtilise = new bool[NombrePions];

    for(int i = 0; i<NombrePions; i++)
    {
        if (proposition[i] == sequenceSecrete[i])
        {
            bienPlaces++;
            secretUtilise[i] = true;
            propositionUtilise[i] = true;
            resultaTrouve[i] = proposition[i];
        }
    }

    for(int i = 0; i< NombrePions;i++)
    {
        if (!propositionUtilise[i])
        {
            for(int j = 0;j<NombrePions; j++)
            {
                if (!secretUtilise[j] && proposition[i] == sequenceSecrete[j])
                {
                    malPlaces++;
                    secretUtilise[j] = true;
                    break;
                }
            }
        }
    }

    Console.WriteLine("\nResultat :");
    Console.WriteLine($" Pions biens placés : {bienPlaces}");
    Console.Write("   ");
    foreach(var pions in resultaTrouve)
    {
        Console.Write(pions);
    }
    Console.WriteLine($"\n Pions Mal Placés : {malPlaces}");
    Console.WriteLine($"\n Pions incorrects : {NombrePions - malPlaces - bienPlaces}");

    if(bienPlaces == NombrePions)
    {
        gagne = true;
        Console.WriteLine($"\n Bravo! Vous avez trouvé la sequence en {tentative} tentative(s)");
        Console.WriteLine($"La sequence etait : {sequenceSecrete}");
    }
    else
    {
        vieRestantes--;
        if(vieRestantes == 0)
        {
            Console.WriteLine($"\n Fin de Partie ! Vous avez épuisé vos {NombreEssai} tentatives");
            Console.WriteLine($"La sequence etait : {sequenceSecrete}");
        }
    }

}
