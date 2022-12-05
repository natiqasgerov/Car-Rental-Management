using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CarRentalSystem.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public string NumberPlate { get; set; }
        public string FuelType { get; set; }
        public string Transmission { get; set; }
        public string TankSize { get; set; }
        public string EngineSize { get; set; }
        public string Odometer { get; set; }
        public string Status { get; set; }
        public byte[]? Picture { get; set; }
        public Brush? Color { get; set; }

        
    }
}
