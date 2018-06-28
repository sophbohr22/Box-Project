using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BoxProblem.Data
{
    public class BoxInventory
    { 
        [Key]
        public int Id { get; set; }
        
        [Range(0,Int32.MaxValue)]
        public int Weight { get; set; }

        [Range(0,Int32.MaxValue)]
        public int Volume { get; set; }

        public bool CanHoldLiquid { get; set; }

        [Range(0.0,Double.MaxValue)]
        [DataType(DataType.Currency)]
        public double Cost { get; set; }

        [Range(0,Int32.MaxValue)]
        public int InventoryCount { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
