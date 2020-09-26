namespace ResturantWebApp.Dtos
{
    public class OrderReadDto
    {
        public int OrderID { get; set; }
        public string OrderNum { get; set; }
        public string Customer { get; set; }
        public string PMethod { get; set; }
        public decimal Total { get; set; }
    }
}