using Appareils;

//var lecteur = new LecteurFichier();
//lecteur.Enregistrer("text.txt", "Contenu de texte");
//Console.WriteLine(lecteur.Lire("text.txt"));
//// lecteur.Imprimer("text.txt") => lance une exception car ne sais pas faire.

var lecteur = new LecteurFichier();
lecteur.Enregistrer("text.txt", "Contenu de texte");
Console.WriteLine($"Contenu lu : {lecteur.Lire("text.txt")}");

var imprimante = new ImprimanteConsole();//Imprimante : IImpression
var serviceImpression = new ServiceImpression(imprimante); // le service depend de IImpression
serviceImpression.ImprimerDocument("text.txt"); //On imprise sans exception