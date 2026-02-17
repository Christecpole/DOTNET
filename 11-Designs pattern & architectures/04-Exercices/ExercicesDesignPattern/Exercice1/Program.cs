// See https://aka.ms/new-console-template for more information
using Exercice1;

Console.WriteLine("Exercice 1");

//Exercice 1 : Builder - Construction de Maison

//Objectif :
//Utilisez le pattern Builder pour construire des maisons avec différentes caractéristiques
//- nombre d'étages
//- piscine ou pas
//- type de toiture
//- couleur

var house = new House.Builder()
    .FloorsValue(2)
    .HasPoolValue(true)
    .ColorValue("jaune")
    .RoofTypeValue("Tuile")
    .Build();

Console.WriteLine(house);