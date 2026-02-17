

#region List

//Création d'une list avec les valeur 2,4,6,8 a l'interieur
List<int> nombrePairs = new List<int>() {2,4,6,8};

//ajout dela valeur 10 dans notre list NombrePairs
nombrePairs.Add(10);

//affichage de la liste
foreach (var pair in nombrePairs)
{
    Console.WriteLine(pair);
}

//création de la liste prenom qui est vide a sa creation
List<string> prenoms = new List<string>();

//ajout de prenom dans la liste que l'on viens de crée
prenoms.Add("Toto");
prenoms.Add("Tata");
prenoms.Add("Titi");
prenoms.Add("Tutu");

//retrait du prenom "Titi" de la list de prenom
prenoms.Remove("Titi");
//Supresion avec verification de l'element a l'emplacement 0 de la liste 
int Index = 0;
// on verifie que l'element que l'on veux surprimer est bien dans la liste pour eviter une erreure de out of bound (en dehors des limites de la liste)
if(Index < prenoms.Count)
{
    prenoms.RemoveAt(Index);
}

Console.WriteLine(prenoms[0]);


#endregion

#region HasSet

//creation d'un hashset (une list qui ignore les doublon)
HashSet<string> set = new HashSet<string>();
//ajout de valeur dans la le set
set.Add("Java");
set.Add("Python");
set.Add("Python3");
set.Add("C++");
//le set ignoreras les doublon que l'on essayeras de lui ajouter
set.Add("C++");
set.Add("C++");
//affichage de note set dans la console 
//string.join permet de faire la concatenation de tout les valeurs qui sont dans notre set 
//soit le set devien "Java, Python, Pyhton3, C++"
Console.WriteLine("HashSet : "+ string.Join(", ",set));



//exemple de comment afficher le set avec une boucle for
foreach (var langage in set)
{
    Console.WriteLine(langage);
}


//Création d'un sorted set, un set qui ordone automatiquement les donnée placé a l'interieur
SortedSet<string> sortedSet = new SortedSet<string>();
sortedSet.Add("Java");
sortedSet.Add("Python");
sortedSet.Add("Python3");
sortedSet.Add("C++");
sortedSet.Add("C++");
sortedSet.Add("C++");
Console.WriteLine("HashSet : " + string.Join(", ", sortedSet));

//methode disponible pour le sortedset (pas tres important a retenir)
Console.WriteLine("1er element : "+sortedSet.First());
Console.WriteLine("dernier element : "+sortedSet.Last());
Console.WriteLine("Sous ensemble avant pyhton "+ string.Join(", ", sortedSet.GetViewBetween(sortedSet.First(), "Pyhton")));
#endregion

#region Dictionaire

//Création d'un dictionaire, une liste permetant de liée un key et une valeur 
Dictionary<string,int> panier = new Dictionary<string,int>();

// soit dans notre exemple la clé "Pomme" va etre liée a la valeur 5
panier.Add("Pomme", 5);
// soit dans notre exemple la clé "Poire" va etre liée a la valeur 3
panier.Add("Poire", 3);
// soit dans notre exemple la clé "Peche" va etre liée a la valeur 4
panier.Add("Peche", 4);
// soit dans notre exemple la clé "Pomme" va etre liée a la valeur 3
panier.Add("Banane", 3);

//notre dictionaire possede une methode ContainsKey qui permet de verifier si une clé a est deja presente dans notre a l'interieur
if (!panier.ContainsKey("Pomme"))
{
    panier.Add("Pomme", 10);
}
else
{
    panier["Pomme"] += 2;
}

//Le count nous permet de connaitre le nombre depair clé valeur
Console.WriteLine("1. nombre d'entrées du dictionaire : "+ panier.Count);
// on peu acceder au valeur liée a nos clé en utilisant les [] pour specifier la valeur de quelle clé on veux recuperer
Console.WriteLine("2. valeur associé a pomme : " + panier["Pomme"]);
Console.WriteLine("3. verifier la presence d'un clé : " + panier.ContainsKey("Ananas"));
//retrait de la clé "Poire" et la valeur qui lui est associé
Console.WriteLine("4. suppresion d'une clé : " + panier.Remove("Poire"));

//exemple d'affichage de nos clé / valeur presente dans notre dictionaire
Console.WriteLine("=== affichage du dictionaire ===");
foreach (KeyValuePair<string,int> entry in panier)
{
    Console.WriteLine(entry);
    Console.WriteLine("Clé :" + entry.Key);
    Console.WriteLine("Value : "+entry.Value);
}

#endregion