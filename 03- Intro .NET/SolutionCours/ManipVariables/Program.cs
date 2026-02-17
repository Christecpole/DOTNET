#region Création de variables

// Commentaire monoligne

/* Ici, on va créer des variables, de plusieurs types: 
 * 
 * - Par typage explicite en définissant le type lors de l'initialisation (int, string, bool, etc.)
 * - Par typage inféré en utilisant le mot-clé 'var' qui va fixer le type à partir de la valeur
 * - Sans typage, par passage via un 'object' en utilisant le mot-clé 'dynamic'
 */

/* Pour déclarer des éléments de code, on peut le faire:
 * - en PascalCase (utilisé pour les noms de classe / méthodes / fonctions)
 * - en camelCase (utilisé pour les noms de variables)
 * - en snake_case (non utilisé en .NET)
 * - en SCREAMING_SNAKE_CASE (utilisé pour déclarer des constantes)
 */

int monNombre = 22;
short monNombrePetit = 22;
string monTexte = "Mon texte"; 
bool monBooleen = true;
string @string = "Mot clé réservé";

var monNombreBis = 22;
var monTexteBis = "Je suis un autre texte";
var monBooleenBis = false;

dynamic maVariableSansTypage = 22;

string mon_texte_python = "Valeur";

// Pour créer des valeurs constantes, on peut utiliser des constantes au sens strict du terme, ou des 'readonly', qui fonctionne un peu de la même façon au sein des classes

const int MON_NOMBRE = 254;
// readonly string monTexteReadonly; => Pour créer une variable dont on pourra ensuite mettre une valeur, celle-ci ne pouvant pas être modifiée par la suite

#endregion

// monTexteBis = 22; => On ne peut pas modifier le type d'une variable après son initialisation, seulement la valeur
maVariableSansTypage = "Je suis du texte"; // Sauf s'il s'agit d'une variable dynamique, vu qu'il s'agit derrière d'un 'object'

#region Affichage des valeurs

// Pour afficher des choses en console, il faut utiliser la feature Console.WriteLine(). On met entre parenthèse une chaine de caractère correspondant à ce que l'on veut afficher
Console.WriteLine("La valeur de la variable monNombreBis est: " + monNombreBis + ".");
Console.WriteLine("La valeur de la constante MON_NOMBRE est: " + MON_NOMBRE + ".");

string prenom = "John";
string nomDeFamille = "DOE";
int age = 18;
int salaire = 34_000;

Console.WriteLine("Je m'appelle " + prenom + " " + nomDeFamille + ", j'ai " + age + " ans et je touche salaire de " + salaire + " euros par ans");

// Une chaine de caractère débutant par le caractère '$' sert à utiliser de l'interpolation de string, on peut ainsi injecter les variables directement dans la chaine via une syntaxe particulière
Console.WriteLine($"Je m'appelle {prenom} {nomDeFamille}, j'ai {age} ans et je touche un salaire de {salaire} euros par ans");


Console.WriteLine("=== MENU PRINCIPAL ===");
Console.WriteLine("\t1. Coca");
Console.WriteLine("\t2. Pepsi");

Console.WriteLine("Le chemin de fichier est: C:\\Users\\Administrateur\\Desktop\\poec_net_1512");

// Une chaine de caractère débutant par '@' sert à omettre les '\' de sorte à les traiter en tant que tel et non pas comme délimiteur de caractère spécial
Console.WriteLine(@"Le chemin de fichier est: C:\Users\Administrateur\Desktop\poec_net_1512");

#endregion

#region Récupération de saisie utilisation

int ageBis = 0;
int salaireBis = 0;
string prenomBis = "";
string nomDeFamilleBis = string.Empty;

// Pour récupérer une information utilisateur, on va utiliser Console.ReadLine() de sorte à lire l'entrée, puis on va la convertir (si besoin) en un type voulu

//Console.Write("Quel est ton age ? ");
//string ageEntreParUtilisateurEnTexte = Console.ReadLine();
//int ageConvertiEnNombre = Convert.ToInt32(ageEntreParUtilisateurEnTexte);
//ageBis = ageConvertiEnNombre;

//Console.Write("Quel est ton salaire ? ");
//salaireBis = Convert.ToInt32(Console.ReadLine());

//Console.Write("Quel est ton prénom ? ");
//prenomBis = Console.ReadLine();

//Console.Write("Quel est ton nom de famille ? ");
//nomDeFamilleBis = Console.ReadLine();

//Console.WriteLine($"Bonjour, tu t'appelles {prenomBis} {nomDeFamilleBis}, tu as {ageBis} ans et tu touches un salaire de {salaireBis} euros par ans !");

#endregion

#region Nombre Aléatoire

// Pour générer un nombre aléatoire, on va avoir besoin de deux bords, un minimum et un maximum

int nbMin = 0;
int nbMax = 10;

// On va devoir créer un objet de type Random pour avoir accès aux fonctionnalités de génération de nombre

var random = new Random();

// On va faire usage de cette méthode pour générer notre nombre via les deux bords (attention, le bord supérieur est exclu)

int nbAleatoireEntre0Et10 = random.Next(nbMin, nbMax + 1);

#endregion

#region Parsing 

short shortValue = 203;
int intValue = shortValue;

int intValue2 = 200000;
short shortValue2 = (short) intValue2;

Console.WriteLine("Short value : "+  shortValue2);

string stringValue = "25";
//int ageFromString = int.Parse(stringValue);
int ageFromString = Convert.ToInt32(stringValue);
Console.WriteLine("ageFromString : " + ageFromString);

//string stringValue2 = "vingt cinq";
//int ageFromString2 = int.Parse(stringValue2);
////int ageFromString2 = Convert.ToInt32(stringValue);
//Console.WriteLine("ageFromString : " + ageFromString2);


bool compatible = 21 is int;
bool compatibleString = 21 is string;
if( compatible)
{
    Console.WriteLine("21 est compatible avec les ints");
}

// compatibleString == false
if(!compatibleString)
{
  Console.WriteLine("21 n'est pas compatible avec string");
}

bool compatible2 = 21 is int varint;
varint += 5;
Console.WriteLine("21 dans varInt : "+ varint);

int? varInt2 = 21 as int?;
//string? varString2 = 21 as string?;

Console.WriteLine("21 dans varInt2 :" + varInt2);

#endregion