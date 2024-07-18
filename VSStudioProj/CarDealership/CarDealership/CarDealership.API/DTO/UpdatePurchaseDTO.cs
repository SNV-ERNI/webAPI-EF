namespace CarDealership.API.DTOs
{
    public class UpdatePurchaseOrderDTO
    {
        public int OrderID { get; set; }
        public int VIN { get; set; }
        public int CustomerID { get; set; }
    }
}