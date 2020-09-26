namespace ResturantWebApp.Dtos
{
    public class OrderDetailReadDto
    {
        public int OrderID { get; set; }
        public string OrderNum { get; set; }
        public int CustomerID { get; set; }
        public int PaymentID { get; set; }
        public decimal TotalRevenu { get; set; }
    }
}