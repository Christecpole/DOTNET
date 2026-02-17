using Demo07Exception.Classe;
using Demo07Exception.Exceptions;
using System.Data;

#region division par O
int Calcul(int a, int b)
{
    return a / b;
}
void Divide()
{

    Console.WriteLine("Entrer la valeur de A");
    int a = int.Parse(Console.ReadLine());

    Console.WriteLine("Entrer la valeur de B");
    int b = int.Parse(Console.ReadLine());

    int result = 0;
    try
    {
        result = Calcul(a, b);
    }
    catch (DivideByZeroException exeception)
    {
        //Console.WriteLine(exeception);
        Console.WriteLine("Division par 0 impossible");
    }


    Console.WriteLine("resultat : " + result);
}

#endregion

#region Compte 

Compte compte = new Compte();

try
{
    Console.WriteLine("Montant a Verser :");
    double montant = double.Parse(Console.ReadLine());
    compte.Verser(montant);
    Console.WriteLine("Solde actuel : " + compte.Solde);
    Console.WriteLine("Montant a retirer: ");
    double montatRetrait = double.Parse(Console.ReadLine());

    compte.Retirer(montatRetrait);

}
catch(SoldeInsuffisantExceptiont ex)
{
    Console.WriteLine(ex.Message);
}catch(FormatException ex)
{
    Console.WriteLine("Format des montant invalide !");
}catch(MontantNegatifException ex)
{
    Console.WriteLine(ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("Une exception a ete attrapé");
}


#endregion