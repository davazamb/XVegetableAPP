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
        public DateTime? LastPurchase { get; set; }
        public string Image { get; set; }  
        public bool IsActive { get; set; }  
        public string Observation { get; set; }
        public byte[] ImageArray { get; set; }    

        public string ImageFullPath
        { get
            {
                if (string.IsNullOrEmpty(Image))
                {
                    return "icono.png";
                }
                return string.Format("http://vegetableapi.azurewebsites.net{0}", Image.Substring(1));
            }
        }

        public override int GetHashCode()
        {
            return VegetableId;
        }

    }
}
