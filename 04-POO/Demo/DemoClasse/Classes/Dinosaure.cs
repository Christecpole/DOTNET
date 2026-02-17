namespace DemoClasse.Classes;

public class Dinosaure
{
    private static int _nombreDisosaure = 0;
    
    private int _age;
    private string _nom;
    private int _nombrePattes;
    
    #region Getter Setter Basique
    // public int GetAge()
    // {
    //     return _age;
    // }
    //     
    // public void SetAge(int value)
    // {
    //     if (value > 0)
    //     {
    //         _age = value;
    //     }
    // }
    //
    #endregion
    
    #region Propriete .net

    public int Age
    {
        get => _age;
        set => _age = value;
    }

    public string Nom
    {
        get => _nom;
        set => _nom = value;
    }
    
    public int NombrePattes
    {
        get => _nombrePattes;
        set
        {
            if (value <= 0) Console.WriteLine("Nombre de pattes invalides");
            else _nombrePattes = value;
        }
    }
    #endregion

    #region AutoProperties

    //Pas possible de faire des conditions avec les autos Properties
    
    public bool PeutVoler { get; set; }
    //private bool _peutVoler;

    public string RegimeALimentaire {get; set;} = "Herbivore";

    public double Poids { get; protected set; }
    
    #endregion
    
    #region Constructeur
    
    public Dinosaure()
    {
        _nombreDisosaure++;
    }

    public Dinosaure(string nom, int age):this()
    {
        Nom = nom;
        Age = age;  
        NombrePattes = 4;
        PeutVoler = false;
        Poids = 1000;
    }

    public Dinosaure(int age, string Nom, int nombrePattes, bool peutVoler, string regimeALimentaire,double poids) : this(Nom,age)
    {
        // Age = age;
        // //exemple utilisation this
        // this.Nom = Nom;
        NombrePattes = nombrePattes;
        PeutVoler = peutVoler;
        RegimeALimentaire = regimeALimentaire;
        Poids = poids;
    }

    #endregion

    #region Methodes

    public void AfficheDino()
    {
        Console.WriteLine($"nom : {Nom} | Age {Age} | Nombre de pattes : {NombrePattes} |  Peux Voler : {PeutVoler} | regime Alimentaire : {RegimeALimentaire} | Poids : {Poids}");
    }

    /// <summary>
    /// Methode pour savoir si un dinosaure peut voler
    /// </summary>
    /// <returns>Boolean qui nous dis s'il peut voler ou non</returns>
    public bool Voler()
    {
        if (PeutVoler)
        {
            
            Console.WriteLine("Je vole");
            return true;
        }
        else
        {
            Console.WriteLine("Je ne suis pas capable de voler");
            return false;
        }
    }

    public static void AfficherNombreDinosaure()
    {
        Console.WriteLine($"Nous avons {_nombreDisosaure} dinosaures.");
    }

    #endregion
   

}