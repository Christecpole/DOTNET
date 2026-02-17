namespace TpBilleterie.Classes;

public class Place : Address
{
    public int Capacity { get; set; }
    
    public Place(string street, string city,int capacity) : base(street, city)
    {
        Capacity = capacity;
    }

    public override string ToString()
    {
        return base.ToString()+ $", Capacity: {this.Capacity}";
    }
}