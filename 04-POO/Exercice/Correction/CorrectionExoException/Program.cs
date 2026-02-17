
using CorrectionExoException.Classes;
using CorrectionExoException.Exceptions;

void Exercice1()
{
    while (true)
    {
        try
        {
            Console.WriteLine("Entrer un entier :");
            int entry = int.Parse(Console.ReadLine());
            Console.WriteLine("La valeur entré est : " + entry);
            return;
        }
        catch (FormatException ex)
        {
            Console.WriteLine("La valeur entrée a un format incorect");
        }
    }
}

void Exercice2()
{
    while (true)
    {
        try
        {
            Console.WriteLine("Entrer un entier Positif :");
            int entry = int.Parse(Console.ReadLine());
            if (entry < 0) throw new NegativeValueException("La valeur saisie dois etre positive !");
            Console.WriteLine($"La racine carée de {entry} est : {Math.Sqrt(entry)}");
            return;
        }
        catch (FormatException ex)
        {
            Console.WriteLine("La valeur entrée a un format incorect");
        }catch(NegativeValueException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}


void Exercice3()
{
    int[] tableau = { 1, 2, 3, 4, 5 };

    Console.WriteLine("Entrer l'element au quelle vous voullez acceder :");
    int index = int.Parse(Console.ReadLine());

    try
    {
        if (index > tableau.Length) throw new IndexOutOfRangeException("l'index se trouve en dehors de notre tableau");
        Console.WriteLine($"la valeur a l'index : {index} est : {tableau[index]}"); ;
    }
    catch (IndexOutOfRangeException ex)
    {
        Console.WriteLine(ex.Message);
    }
}

void Exercice4()
{
    List<Student> students = new List<Student>();

    while (true)
    {
        Console.WriteLine("Entrer un nouvelle etudiant Y(es) / N(o):");
        string entry = Console.ReadLine().ToUpper();
        if (entry == "N") break;

        Console.WriteLine("Entrer le nom de l'etudiant :");
        string nom = Console.ReadLine();

        while (true)
        {
            try
            {
                Console.WriteLine("Entrer l'age de l'etudiant :");
                int age = int.Parse(Console.ReadLine());

                students.Add(new Student(nom, age));
                break;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("L'age rentré est au mauvais format");
            }
            catch (InvalideAgeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        

    }

    foreach (Student student in students)
    {
        Console.WriteLine(student.Nom +" " + student.Age);
    }
}


Exercice4();