
using CorrectionExoSalarie.Classes;

//tableau contenant l'ensemble des salariés de l'application 
Salarie[] salariesTabs = new Salarie[0];

//Methode de lancement de l'appli avec l'affichage du menu 
void Start()
{
    while (true)
    {
        Console.WriteLine("=== Menu ===");
        Console.WriteLine("1/ Ajouter un salarié");
        Console.WriteLine("2/ affichage des Salarié");
        Console.WriteLine("3/ affichage des stat de l'entreprise");
        Console.WriteLine("4/ reset");

        string entry = Console.ReadLine();

        switch (entry)
        {
            case "1":
                AddSalarie();
                break;
            case "2":
                ShowSalarie();
                break;
            case "3":
                ShowStat();
                break;
            case "4":
                //reset du compte de salarié, du salaire total et du tableau contenant les salariés
                Salarie.Reset();
                salariesTabs = new Salarie[0];
                break;
            default:
                return;
        }
    }
}

//Methode d'ajout d'un salarié
void AddSalarie()
{

    //recuperation des information du salarié
    Console.WriteLine("=== Ajout d'un Salarié ===");
    Console.WriteLine("Entrer le Matricule : ");
    string matricule = Console.ReadLine();
    Console.WriteLine("Entrer le Service : ");
    string service = Console.ReadLine();
    Console.WriteLine("Entrer le Categorie : ");
    string categorie = Console.ReadLine();
    Console.WriteLine("Entrer le Nom : ");
    string nom = Console.ReadLine();
    Console.WriteLine("Entrer le salaire : ");
    double salaire = Double.Parse(Console.ReadLine());

    //creation du salarié
    Salarie salarie = new Salarie(matricule,service,categorie,nom,salaire);

    //ajout du salarié dans un tableau de dimention +1 par rapport a l'ancient tableau
    Salarie[] newTab = new Salarie[salariesTabs.Length+1];
    salariesTabs.CopyTo(newTab,0);
    newTab[newTab.Length - 1] = salarie;

    salariesTabs = newTab;

}

//Methode d'affichage des information des salarié
void ShowSalarie()
{
    Console.WriteLine("=== Affichage des salariés ===");
    foreach(var salarie in salariesTabs)
    {
        salarie.AfficherSalaire();
    }
}

//affichage des stat global ( nbSalarie et totalSalaire)
void ShowStat()
{
    Salarie.AffichageTotalSalarie();
}

Start();