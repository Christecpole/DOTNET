namespace SpecieMicroService.Models;

public class Species
{
    public int Id { get; set; }
    public string CommonName { get; set; }
    public string ScientificName { get; set; }
    public Category Category { get; set; }
}