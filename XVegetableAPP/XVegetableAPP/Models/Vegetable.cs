using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XVegetableAPP.Models
{
    public class Vegetable
    {
        public int VegetableId { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public override int GetHashCode()
        {
            return VegetableId;
        }

    }
}
