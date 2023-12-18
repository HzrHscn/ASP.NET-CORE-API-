using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Barcode { get; set; }
        public string ImgUrl { get; set; }
        public string Status { get; set; }

        // Barkodu otomatik oluşturan bir metod
        public void GenerateBarcode()
        {
            // Örnek bir barkod oluşturma mantığı, burada dilediğiniz şekilde düzenleyebilirsiniz.
            Barcode = $"{Category?.Substring(0, 1)}{Brand?.Substring(0, 1)}{Quantity:D5}";
        }
    }
}
