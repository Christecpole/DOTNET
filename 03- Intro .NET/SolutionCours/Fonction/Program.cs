
#region Fonction Base

void AffichageMenu()
{
    Console.WriteLine("=== Menu ===");
    Console.WriteLine($"1 - Choix1");
    Console.WriteLine($"2 - Choix2");
    Console.WriteLine($"3 - Choix3");
    Console.WriteLine($"4 - Choix4");
}

//AffichageMenu();

#endregion 

#region Fonction avec Parametres

void AffichageMenu2(int NbChoix = 3)
{
    Console.WriteLine("=== Menu ===");
    for (int i = 1; i <= NbChoix; i++)
    {
        Console.WriteLine($"{i} - Choix{i}");
    }
}
AffichageMenu2(8);


//void AffichageMenuPerso(string[] proposition)
//{
//    Console.WriteLine("=== Menu ===");
//    for (int i = 1; i <= proposition.Length; i++)
//    {
//        Console.WriteLine($"{i} - {proposition[i-1]}");
//    }
//}

void AffichageMenuPerso(params string[] proposition)
{
    Console.WriteLine("=== Menu ===");
    for (int i = 1; i <= proposition.Length; i++)
    {
        Console.WriteLine($"{i} - {proposition[i - 1]}");
    }
}

AffichageMenuPerso( "proposition1", "proposition2", "proposition3", "proposition4" );

#endregion

#region Passage par valeur et par reference

//par Valeur
int compteur = 5;

void Incremente(int value)
{
    value++;
    Console.WriteLine("Value :"+value);
}

Incremente(compteur);

Console.WriteLine("Compteur :" + compteur);

// par reference

int compteurRef = 5;

void IncrementeRef(ref int value)
{
    value++;
    Console.WriteLine("ValueRef :" + value);
}

IncrementeRef(ref compteurRef);

Console.WriteLine("CompteurRef :" + compteurRef);

#endregion

#region Fonction avec un retour

double Addition (double numberA, double numberB)
{
    var result = numberA + numberB;
    return result;
}

double resultatObtenue = Addition(5, 8);


#endregion

