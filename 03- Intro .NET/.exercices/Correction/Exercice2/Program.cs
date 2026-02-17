Console.WriteLine($"--- Difficultée --- \n 1 - Facile \n 2 - normal \n 3 - difficile");
string? Difficulty = Console.ReadLine();

int NbVie = Difficulty switch
{
    "1" => 10,
    "2" => 7,
    "3" => 5,
};

Random rand = new Random();
int ValeurCible = rand.Next(1, 101);
bool isFind = false;

do
{
    Console.WriteLine("entrer une valeur entre 1 et 100 : ");
    int Entry = int.Parse(Console.ReadLine());

    if(Entry > ValeurCible)
    {
        Console.WriteLine("La valeure recherchée est plus petite !");
    }
    else if(Entry< ValeurCible)
    {
        Console.WriteLine("La valeure recherchée est plus grande !");
    }
    else
    {
        isFind = true;
    }
    NbVie--;
} while (NbVie > 0 && !isFind );

if( NbVie == 0 && !isFind)
{
    Console.WriteLine("Vous n'avez pas trouvé la valeur qui ete : "+ValeurCible);
}
else
{
    Console.WriteLine("Felicitation vous avez trouver la valeur recherché il vous reste ");
}



