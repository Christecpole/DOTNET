namespace OrderService.Dto
{
    public record OrderReceive
        (
        string commandeNumber,
        List<int> productIds)
    {
    }
}
