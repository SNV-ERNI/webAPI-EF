using System.ComponentModel.DataAnnotations;

namespace CarDealership.API.Entities
{
    public class PurchaseOrderEntity
    {
        [Key]
        public int OrderID { get; set; }
        public int VIN { get; set; } // Foreign key from Cars entity
        public int CustomerID { get; set; } // Foreign key from Customers entity

        // Navigation properties
        public required CarsEntity Car { get; set; }
        public required CustomersEntity Customer { get; set; }

        // Navigation property for TransactionHistory
        public required ICollection<TransactionHistoryEntity> TransactionHistory { get; set; }
    }
}
