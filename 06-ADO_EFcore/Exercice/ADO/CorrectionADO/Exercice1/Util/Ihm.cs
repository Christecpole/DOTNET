using System.Globalization;
using Exercice1.Classes;
using Exercice1.Repository;

namespace Exercice1.Util;

public class Ihm
{

    private StudentRepository _studentRepository;

    public Ihm()
    {
        _studentRepository = new StudentRepository();
    }

    public void Start()
    {
        while (true)
        {
            Console.WriteLine("\n=== Student menu ===");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Show All Student");
            Console.WriteLine("3. Search Student by ID");
            Console.WriteLine("4. Update Student");
            Console.WriteLine("5. Delete Student");
            Console.WriteLine("6. Search By Name");
            Console.WriteLine("7. Search By Classe");
            Console.WriteLine("0. Quitter");
            Console.Write("\nVotre choix : ");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    AddStudent();
                    break;
                case "2":
                    ShowAllStudent();
                    break;
                case "3":
                    GetById();
                    break;
                case "4":
                    UpdateStudent();
                    break;
                case "5":
                    DeleteStudent();
                    break;
                case "6":
                    SearchByName();
                    break;
                case "7":
                    SearchByClasse();
                    break;
                case "0":
                    Console.WriteLine("Au revoir !");
                    return;
                    break;
                default:
                    Console.WriteLine("Choix invalide !");
                    break;
            }
        }
    }

    private void AddStudent()
    {
        Console.WriteLine("\n--- Add Student ---");
        Console.Write("LastName : ");
        string lastname = Console.ReadLine();
        Console.Write("FirstName : ");
        string firstname = Console.ReadLine();
        Console.Write("Classe Number : ");
        int classeNumber = int.Parse(Console.ReadLine());
        Console.Write("Diplome Date (dd-MM-yyyyy) : ");
        string diplomeDateStr = Console.ReadLine();

        DateTime date = DateTime.ParseExact(diplomeDateStr, "dd-MM-yyyy", CultureInfo.InvariantCulture);

        _studentRepository.Add(new Student(lastname, firstname, classeNumber, date));

    }



    private void ShowAllStudent()
    {
        Console.WriteLine("\n--- Show All Student ---");

        List<Student> students = _studentRepository.GetAll();

        foreach (var student in students)
        {
            Console.WriteLine(student);
        }
    }


    private void GetById()
    {
        Console.WriteLine("\n--- Search Student By ID ---");
        Console.Write("ID  : ");
        int id = int.Parse(Console.ReadLine());

        Student student = _studentRepository.GetById(id);
        Console.WriteLine(student);
    }
    
    private void UpdateStudent()
    {
        Console.WriteLine("\n---Update Student ---");
        Console.Write("ID Student : ");
        int id = int.Parse(Console.ReadLine());
        Console.Write("LastName : ");
        string lastname = Console.ReadLine();
        Console.Write("FirstName : ");
        string firstname = Console.ReadLine();
        Console.Write("Classe Number : ");
        int classeNumber = int.Parse(Console.ReadLine());
        Console.Write("Diplome Date (dd-MM-yyyyy) : ");
        string diplomeDateStr = Console.ReadLine();
        
        DateTime date = DateTime.ParseExact(diplomeDateStr, "dd-MM-yyyyy", CultureInfo.InvariantCulture);

        Student student = new Student(id, lastname, firstname, classeNumber, date);
        
        _studentRepository.Update(student);
        
    }


    private void DeleteStudent()
    {
        Console.WriteLine("\n---Delete Student ---");
        Console.Write("ID Student : ");
        int id = int.Parse(Console.ReadLine());
        
        _studentRepository.Delete(id);

    }
    
    private void SearchByName()
    {
        Console.WriteLine("\n--- Search By Name---");
        Console.Write("Name to search : ");
        string search = Console.ReadLine();

        List<Student> students = _studentRepository.GetAll(search);

        foreach (var student in students)
        {
            Console.WriteLine(student);
        }


    }
    
    private void SearchByClasse()
    {
        Console.WriteLine("\n--- Search By Classe Number---");
        Console.Write("Classe Number to search : ");
        var search = int.Parse(Console.ReadLine());

        List<Student> students = _studentRepository.GetAll(search);

        foreach (var student in students)
        {
            Console.WriteLine(student);
        }


    }
}