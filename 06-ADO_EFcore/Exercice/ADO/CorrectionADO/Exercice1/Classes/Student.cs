namespace Exercice1.Classes;

public class Student
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public int ClasseNumber { get; set; }
    public DateTime DiplomeDate { get; set; }

    public Student(string lastName, string firstName, int classeNumber, DateTime diplomeDate)
    {
        LastName = lastName;
        FirstName = firstName;
        ClasseNumber = classeNumber;
        DiplomeDate = diplomeDate;
    }

    public Student(int id, string lastName, string firstName, int classeNumber, DateTime diplomeDate) :this(lastName, firstName, classeNumber, diplomeDate)
    {
        Id = id;
    }

    public override string ToString()
    {
        return $" Student N°{Id} : {LastName} {FirstName}, numero de classe : {ClasseNumber}, Date de diplome : {DiplomeDate}";
    }
}