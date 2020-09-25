namespace ResturantWebApp.Models
{
    public class OrderItemEntity : BaseEntity
    {
        public int ItemID { get; set; }
        public int Quantity { get; set; }
        public int OrderID { get; set; }
    }
}