#region Opérateurs arithmétiques

int monNombreA = 5;
int monNombreB = 8;

int laSomme = monNombreA + monNombreB; // Addition
int laDifference = monNombreA - monNombreB; // Soustraction
int leProduit = monNombreA * monNombreB; // Multiplication
int leQuotient = monNombreA / monNombreB; // Division
int leModulo = 10 % 3; // Reste d'une division euclidienne

Console.WriteLine($"10 / 4 en int = {10 / 4}");
Console.WriteLine($"10 / 4 en double = {10 / 4.0}");

#endregion

#region Opérateurs de comparaison

int monNombre = 32;

bool superieurA50 = monNombre > 50; // Supériorité stricte
bool inferieurA50 = monNombre < 50; // Infériorité stricte
bool egalA50 = monNombre == 50; // Egalité
bool inferieurOuEgalA50 = monNombre <= 50; // Infériorité
bool superieurOuEgalA50 = monNombre >= 50; // Supériorité
bool differentDe50 = monNombre != 50; // Différence

#endregion

#region Opérateurs logiques

bool estMajeur = true;
bool estTitulaireDuPermis = false;

bool estMajeurETPossedeLePermis = estMajeur && estTitulaireDuPermis; // ET
bool estSoitMajeurSoitTitulaireDuPermis = estMajeur || estTitulaireDuPermis; // OU
bool estMajeurETNePossedePasLePermis = estMajeur && !estTitulaireDuPermis; // ET.. NOT...

#endregion

#region Les conditions IF...ELSE IF...ELSE

Console.Write("Votre age: ");
int age = Convert.ToInt32(Console.ReadLine());

/* Syntaxe: if (condition booléenne) {...} else if (condition booléenne) {...} else {...}
 * Il est possible d'avoir uniquement le 'if'
 * 
 * Il est possible d'avoir autant d'else if que l'on veut, mais on peut n'avoir qu'un seul if
 * 
 * On peut omettre le else final
 */

if (age >= 21) Console.WriteLine("Vous êtes majeur aux USA !");
else if (age >= 18)
{
    Console.WriteLine("Vous êtes majeur en France !");
}
else Console.WriteLine("Vous êtes mineur...");

// ATTENTION: L'ordre des conditions est important pour éviter les soucis !

//if (age >= 18) Console.WriteLine("Vous êtes majeur en France !");
//else if (age >= 21) Console.WriteLine("Vous êtes majeur aux USA !");
//else Console.WriteLine("Vous êtes mineur...");

#endregion

#region Les SWITCH...CASE....BREAK

Console.WriteLine("=== SODAS ===");
Console.WriteLine("1. Coca Cola");
Console.WriteLine("2. Iced Tea");
Console.WriteLine("3. Schweppes");
Console.WriteLine("4. Ginger Beer");
Console.WriteLine("5. Vin Chaud");
Console.WriteLine("6. Eau");

Console.Write("\nVotre choix: ");
string choixUtilisateur = Console.ReadLine();

//if (choixUtilisateur == "1") Console.WriteLine("Vous voulez un Coca Cola ! Cela fera 2.40€...");
//else if (choixUtilisateur == "2") Console.WriteLine("Vous voulez un Ice Tea ! Cela fera 2.70€...");
//else if (choixUtilisateur == "3") Console.WriteLine("Vous voulez un Schweppes ! Cela fera 2.60€...");
//else if (choixUtilisateur == "4") Console.WriteLine("Vous voulez une Ginger Beer ! Cela fera 3.20€...");
//else if (choixUtilisateur == "5") Console.WriteLine("Vous voulez un Vin Chaud ! Cela fera 4.50€...");
//else if (choixUtilisateur == "6") Console.WriteLine("Vous voulez une Eau ! Cela fera 1.50€...");
//else Console.WriteLine("Je n'ai pas compris votre choix...");

switch (choixUtilisateur)
{
    case "1":
        Console.WriteLine("Vous voulez un Coca Cola ! Cela fera 2.40€...");
        break;
    case "2":
        Console.WriteLine("Vous voulez un Ice Tea ! Cela fera 2.70€...");
        break;
    case "3":
        Console.WriteLine("Vous voulez un Schweppes ! Cela fera 2.60€...");
        break;
    case "4":
        Console.WriteLine("Vous voulez une Ginger Beer ! Cela fera 3.20€...");
        break;
    case "5":
        Console.WriteLine("Vous voulez un Vin Chaud ! Cela fera 4.50€...");
        break;
    case "6":
        Console.WriteLine("Vous voulez une Eau ! Cela fera 1.50€...");
        break;
    default:
        Console.WriteLine("Je n'ai pas compris votre choix...");
        break;
}

#endregion

#region TERNAIRE

Console.Write("Votre nombre d'enfants: ");
int nbEnfants = Convert.ToInt32(Console.ReadLine());

string tailleFamille = nbEnfants > 2 ? "Grande" : "Petite";

// Console.WriteLine($"Votre famille est {tailleFamille}");
Console.WriteLine($"Votre famille est {(nbEnfants > 2 ? "grande" : "petite")}");

#endregion

#region SWITCH EXPRESSION

// Disponible à partir de C# 8.0, il est possible de conditionner la valeur d'une variable en se basant sur un ensemble de valeurs possibles grâce à une 'switch expression'

Console.WriteLine("=== SODAS ===");
Console.WriteLine("1. Coca Cola");
Console.WriteLine("2. Iced Tea");
Console.WriteLine("3. Schweppes");
Console.WriteLine("4. Ginger Beer");
Console.WriteLine("5. Vin Chaud");
Console.WriteLine("6. Eau");

Console.Write("\nVotre choix: ");
string choixUtilisateurBis = Console.ReadLine();

double lePrix = choixUtilisateurBis switch
{
    "1" => 2.4,
    "2" => 2.7,
    "3" => 2.6,
    "4" => 3.2,
    "5" => 4.5,
    "6" => 1.5,
    _ => 0.0
};

//switch (choixUtilisateurBis)
//{
//    case "1":
//        lePrix = 2.40;
//        break;
//    case "2":
//        lePrix = 2.70;
//        break;
//    default:
//        lePrix = 0.0;
//        break;
//}

int laNote = 17;

string appreciation = laNote switch
{
    >= 16 => "Très bien",
    >= 14 => "Bien",
    >= 12 => "Assez bien",
    >= 10 => "Passable",
    _ => "Chômage"
};

Console.WriteLine($"Vu que votre note est de {laNote} / 20, votre appréciation est: {appreciation}");

#endregion