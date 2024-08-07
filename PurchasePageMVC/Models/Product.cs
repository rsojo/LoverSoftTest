using Business.Helpers;

namespace PurchasePageMVC.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string EncryptedId { get { return Encrypt.EncryptString(Id.ToString()); } }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Img { get; set; }

    }
}