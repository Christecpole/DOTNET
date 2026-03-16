namespace ProductService.Dtos
{
    public record ProductReceive(
        double price,
        int quantity,
        string name
        )
   {}
}
