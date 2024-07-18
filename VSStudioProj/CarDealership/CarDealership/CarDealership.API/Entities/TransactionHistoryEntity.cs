using System.ComponentModel.DataAnnotations;

namespace CarDealership.API.Entities
{
    public class TransactionHistoryEntity
    {
        [Key]
        public int TransID { get; set; } // Primary Key
        public int OrderID { get; set; } // Foreign Key from PurchaseOrder
        public DateOnly Date { get; set; }

        // Navigation property
        public required PurchaseOrderEntity PurchaseOrder { get; set; }
    }
}
