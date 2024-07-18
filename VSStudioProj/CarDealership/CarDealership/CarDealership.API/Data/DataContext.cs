using CarDealership.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<CarsEntity> CarsEntities { get; set; }
        public DbSet<CustomersEntity> CustomerEntities { get; set; }
        public DbSet<PurchaseOrderEntity> PurchaseOrderEntities { get; set; }
        public DbSet<TransactionHistoryEntity> TransactionHistoryEntities { get; set; }

/*        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring relationships
            modelBuilder.Entity<PurchaseOrderEntity>()
                .HasOne(po => po.Car)
                .WithMany(c => c.PurchaseOrders)
                .HasForeignKey(po => po.VIN);

            modelBuilder.Entity<PurchaseOrderEntity>()
                .HasOne(po => po.Customer)
                .WithMany(c => c.PurchaseOrders)
                .HasForeignKey(po => po.CustomerID);

            modelBuilder.Entity<TransactionHistoryEntity>()
                .HasOne(th => th.PurchaseOrder)
                .WithMany(po => po.TransactionHistory)
                .HasForeignKey(th => th.OrderID);
        }*/
    }
}