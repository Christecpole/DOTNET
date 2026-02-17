#region WHILE

int unNombre = 15;

while (unNombre < 10)
{
    Console.WriteLine("Je continue...");
    // unNombre = unNombre + 1;
    // unNombre += 1;
    unNombre++;
}

Console.WriteLine("Fin de boucle...");

#endregion

#region DO...WHILE...

// Permet d'effectuer la suite des instructions au moins une fois avant le bouclage (va se faire du coup au moins une fois même si le bouclage ne doit pas avoir lieu)

int unNombreBis = 5;

do
{
    Console.WriteLine("Je continue...");
    // unNombre = unNombre + 1;
    // unNombre += 1;
    unNombreBis++;
} while (unNombreBis < 10);

Console.WriteLine("Fin de boucle...");

#endregion

#region INCREMENT BEFORE / AFTER

// On peut incrémenter une valeur numérique de 1 via '++'. L'incrémentation va se faire en amont ou en aval de l'affichage ou de l'utilisation de la variable selon si l'on met le symbole avant ou après la variable.

int nombreEntier = 1;

while(nombreEntier <= 10)
{
    Console.WriteLine("La valeur du nombre est de " + nombreEntier++);
}

Console.WriteLine("Fin de la boucle");

nombreEntier = 1;

while (nombreEntier <= 10)
{
    Console.WriteLine("La valeur du nombre est de " + ++nombreEntier);
}

Console.WriteLine("Fin de la boucle");

#endregion

#region CONTINUE...BREAK...

// 'continue' => Permet de passer à la boucle suivante directement en zappant la suite des instructions du bouclage actuel
// 'break' => Permet de casser la boucle et de passer à la suite du programme

int nombreEntierBis = 0;

while (nombreEntierBis <= 10)
{
    nombreEntierBis++;
    if (nombreEntierBis % 2 != 0) continue; // Si le nombre entier n'est pas un nombre multiple de 2, on zappe l'affichage via 'continue'
    Console.WriteLine("La valeur du nombre est de " + nombreEntierBis);
}

Console.WriteLine("Fin de la boucle");

while (true)
{
    Console.Write("Veuilliez entrer STOP pour arrêter la boucle: ");
    string monMot = Console.ReadLine();
    if (monMot == "STOP") break;
}

#endregion

#region FOR

// Syntaxe:  for (définition de l'increment; condition de sortie de la boucle; modification de l'incrément)

for (int i = 0; i < 10; i++) Console.WriteLine($"La valeur de \"i\" est de {i}");

#endregion

#region FOREACH

string unMotPlusOuMoinsLong = "Pomme de terre";

// Pour parcourir un ensemble d'élément, on va utiliser leur index dans le but de faire ici les caractères un par un dans la chaine de caractère
for (int i = 0; i < unMotPlusOuMoinsLong.Length; i++) Console.WriteLine(unMotPlusOuMoinsLong[i]);

// Pour éviter de modifier par mégarde les éléments en cours d'itération, on va utiliser une boucle de type FOREACH, qui empêche les modifications
foreach (var item in unMotPlusOuMoinsLong) Console.WriteLine(item);

#endregion