using Business.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PurchasePageMVC.Models
{
    public class PurchaseProduct
    {
        public int Id { get; set; }
        public int PurchaseId { get; set; }
        public int ProductId { get { return Int32.Parse(Encrypt.DecryptString(EncryptedProductId)); } }
        public string EncryptedProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}