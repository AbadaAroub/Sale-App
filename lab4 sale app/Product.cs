using System.Windows.Forms;

namespace lab4_sale_app
{
    public class Product
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string ProductID { get; set; }
        public int Quantity { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Format { get; set; }
        public string Language { get; set; }
        public string ProductType { get; set; }
        public string PlayTime { get; set; }
        public string Platform { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{Name} ({ProductID})      x{Price}"; 
        }
    }
}