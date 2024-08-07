using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Purchase Purchase { get; set; }

        public List<PurchaseProduct> PurchaseProducts { get; set; }
    }
}
