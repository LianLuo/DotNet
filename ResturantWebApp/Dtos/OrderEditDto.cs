using System.Collections.Generic;

namespace ResturantWebApp.Dtos
{
    public class OrderEditDto
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public string OrderNum { get; set; }
        public int PaymentID { get; set; }
        public decimal TotalRevenu { get; set; }
        public IEnumerable<OrderItemEditDto> OrderItems { get; set; }
    }
}