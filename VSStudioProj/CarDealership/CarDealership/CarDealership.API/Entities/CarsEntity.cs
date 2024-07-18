using System.ComponentModel.DataAnnotations;

namespace CarDealership.API.Entities
{
    public class CarsEntity
    {
        [Key]
        public int VIN { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int YearVersion { get; set; }
        public string PlateNumber { get; set; } = string.Empty;
        public string CarType { get; set; } = string.Empty;

    }
}
