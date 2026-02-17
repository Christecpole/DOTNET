// L => principe de substitution de liskov

using CompteBancaire;

// test Compte standart = > retrait 100 => solde => 900
var compteStandard = new CompteStandard(1000m);
compteStandard.Retirer(100m);
Console.WriteLine($"Standard après retrait 100 : {compteStandard.Solde} euros (attendu 900)");

// test Compte bonus = > retrait 100 => solde => 900 (900 + 1%)
var compteBonus = new CompteBonus(1000m);
compteBonus.Retirer(100m);
Console.WriteLine($"Bonus après retrait 100 : {compteBonus.Solde} euros (attendu 901)");

//Plymorphisme : on peut utiliser les deux de la même façon.
Compte c1 = new CompteStandard(500m);
Compte c2 = new CompteBonus(500m);
c1.Retirer(50m);
c2.Retirer(50m);
Console.WriteLine($"Standard : {c1.Solde} euros, Bonus : {c2.Solde} euros");


//Retirer diminue le solde. Les deux sous classes respectent ce contrat. On peux remplacer compte par n'importe quelles sous classe sans casser le comportement attendu.


// Une sous classe ne doit pas inverser le comportement de la classe parent
// On peut remplacer une classe par sa sous classe sans casser le programme
