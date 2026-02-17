double CalculerValeurStock(double[] prix, int[] quantites)
{
    double totalValeurStock = 0;
    for (int i = 0; i < prix.Length; i++)
    {
        double valeurStock = prix[i] * quantites[i];
        totalValeurStock += valeurStock;
    }

    return totalValeurStock;
}

double CalculerChiffreAffaires(double[] prix, int[] ventes)
{
    double totalchiffreAffaire = 0;
    for (int i = 0; i < prix.Length; i++)
    {
        double chiffreAffaire = prix[i] * ventes[i];
        totalchiffreAffaire += chiffreAffaire;
    }

    return totalchiffreAffaire;
}

string TrouverProduitPlusCher(string[] noms, double[] prix)
{
    double prixMax = prix[0];
    int index = 0;
    for (int i = 1; i < prix.Length; i++)
    {
        if (prix[i] > prixMax)
        {
            prixMax = prix[i];
            index = i;
        }
    }

    return noms[index];
}

string TrouverProduitLePlusVendu(string[] noms, int[] ventes)
{
    int venteMax = ventes[0];
    int index = 0;
    for (int i = 1; i < ventes.Length; i++)
    {
        if (ventes[i] > venteMax)
        {
            venteMax = ventes[i];
            index = i;
        }
    }

    return noms[index];
}

int CompterProduitsEnRupture(int[] quantites)
{
    int totalRupture = 0;
    foreach (var value in quantites)
    {
        if (value == 0)
        {
            totalRupture++;
        }
    }

    return totalRupture;
}

int CompterProduitsStockFaible(int[] quantites, int seuil)
{
    int totalStockFaible = 0;
    foreach (var value in quantites)
    {
        if (value <= seuil)
        {
            totalStockFaible++;
        }
    }

    return totalStockFaible;
}

void AfficherFicheProduit(string nom, double prix, int quantite, int ventes)
{
    Console.WriteLine("=== "+nom+" ====");
    Console.WriteLine("Prix :"+prix);
    Console.WriteLine("Quantite :"+quantite);
    Console.WriteLine("Ventes :"+ventes);
    Console.WriteLine("Chiffre d'affaire :"+ (prix*ventes));
    Console.WriteLine("Statut :"+ (quantite == 0 ? "En Rupture" : quantite< 10? "Stock faible" : "Stock correct"));
}

double CalculerMoyenne(double[] valeurs)
{
    double total=0;
    foreach (var value in valeurs)
    {
        total += value;
    }

    double moyenne = total / valeurs.Length;
    return moyenne;
}

void AfficherAlerteStock(string[] noms, int[] quantites, int seuil)
{
    int nbProduitStockFaible = CompterProduitsStockFaible(quantites, seuil);
    if (nbProduitStockFaible != 0)
    {
        Console.WriteLine("Produit | stock");
        for (int i = 0; i < quantites.Length; i++)
        {
            if (quantites[i] <= seuil)
            {
                Console.WriteLine($"{noms[i]} | {quantites[i]} !! attention stock bas");
            }
        }
    }
    else
    {
        Console.WriteLine("Aucun produit n'as de probleme de stock ");
    }
}


void main()
{
    Console.WriteLine("Entrer le nombre de produit en stock :");
    int nbProduit = Int32.Parse(Console.ReadLine());

    string[] produitNom = new string[nbProduit];
    double[] produitPrix = new double[nbProduit];
    int[] produitQuantite = new int[nbProduit];
    int[] produitVendu = new int[nbProduit];

    if (nbProduit != 0)
    {

        for (int i = 0; i < nbProduit; i++)
        {
            Console.WriteLine($"Entrer le nom du produit {i}:");
            produitNom[i] = Console.ReadLine();
            Console.WriteLine($"Entrer le prix du produit {i}:");
            produitPrix[i] = Double.Parse(Console.ReadLine());
            Console.WriteLine($"Entrer la quantite du produit {i}:");
            produitQuantite[i] = Int32.Parse(Console.ReadLine());
            Console.WriteLine($"Entrer le nombre de produit vendu pour le produit {i}:");
            produitVendu[i] = Int32.Parse(Console.ReadLine());
        }
    } else {
        produitNom = new string[]{"produit1","produit2","produit3","produit4"};
        produitPrix = new double[]{112.3,12,54,13};
        produitQuantite = new int[]{12,11,0,5}; 
        produitVendu = new int[]{5,10,8,6};
    }

    Console.WriteLine("`\n ==== Liste des Produits ==== ");
    for (int i = 0; i < produitNom.Length; i++)
    {
        AfficherFicheProduit(produitNom[i],produitPrix[i],produitQuantite[i],produitVendu[i]);
    }
    
    
    Console.WriteLine("`\n ==== Statistique GLobal ==== ");
    Console.WriteLine("Valeur total des stock :"+ CalculerValeurStock(produitPrix,produitQuantite) +" euros");
    Console.WriteLine("Valeur total du chiffre d'affaire :"+ CalculerChiffreAffaires(produitPrix,produitVendu) +" euros");
    Console.WriteLine("Prix Moyen des produit  :"+ CalculerMoyenne(produitPrix) +" euros");
    Console.WriteLine("produit le plus cher  :"+ TrouverProduitPlusCher(produitNom,produitPrix) );
    Console.WriteLine("produit le plus vendu  :"+ TrouverProduitLePlusVendu(produitNom,produitVendu) );
    Console.WriteLine("produit en rupture  :"+ CompterProduitsEnRupture(produitQuantite) +" produits");
    Console.WriteLine("produit en stock faible  :"+ CompterProduitsStockFaible(produitQuantite,10)+" produits");
    
    Console.WriteLine("`\n ==== Alerte des stock ==== ");
    AfficherAlerteStock(produitNom,produitQuantite,10);
}

main();




