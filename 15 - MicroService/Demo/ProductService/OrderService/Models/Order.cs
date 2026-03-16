namespace OrderService.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string CommandeNumber { get; set; }
        public List<int> ProductIds { get; set; }

        public Order()
        {
            ProductIds = new List<int>();
        }
    }
}
