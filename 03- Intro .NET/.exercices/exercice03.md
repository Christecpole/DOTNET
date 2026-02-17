# Exercice 03 - Mastermind

## Objectifs

Appréhender le langage C# dans le cadre de la réalisation d'un programme de base

## Sujet 

Créer une application de type console en C# permettant:

* A un utilisateur de pouvoir choisir entre plusieurs modes de difficultés 
* Le programme va générer une succession de pions de couleurs aléatoire (de 4 à 10 pions en fonction du mode de difficulté)
* Le but pour l'utilisateur est de trouver la succession de pions de couleurs générée par le programme, par exemple `BJJR` pour Bleu, Jaune, Jaune, Rouge.
* Le programme devra compter les tentatives de découvertes de l'utilisateur et l'informer, à chaque tentative, de si il a trouvé: 
    * Un pion faisant partie de l'ensemble des pions, placé au bon emplacement
    * Un pion faisant partie de l'ensemble des pions, mais n'étant pas à la bonne place
    * Un pion faisant ne faisant pas partie de l'ensemble des pions de la chaine de pions
* Le nombre de tentatives pourra être limité via un système de vie, au besoin