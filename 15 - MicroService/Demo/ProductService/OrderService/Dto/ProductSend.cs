namespace OrderService.Dtos
{
    public record ProductSend (
        int id,
        double price,
        int quantity,
        string name
        )
    {
    }
}
