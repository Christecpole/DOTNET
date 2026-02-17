namespace TpBilleterie.Classes;

public class Customer
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public Address Address { get; set; }
    public int Age { get; set; }
    public string Phone { get; set; }
    public List<Billet> Billets { get; set; }

    public Customer(string firstname, string lastname, Address address, int age, string phone)
    {
        Firstname = firstname;
        Lastname = lastname;
        Address = address;
        Age = age;
        Phone = phone;
        Billets = new List<Billet>();
    }

    public void AddBillet(Billet billet)
    {
        Billets.Add(billet);
    }

    public override string ToString()
    {
        return $"Customer : {Firstname} {Lastname} {Age} {Phone} {Address}";
    }
}