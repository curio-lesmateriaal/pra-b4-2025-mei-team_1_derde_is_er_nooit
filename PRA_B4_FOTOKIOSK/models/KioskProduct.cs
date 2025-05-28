namespace PRA_B4_FOTOKIOSK.models
{
    public class KioskProduct
    {
        public string Name { get; set; }
        public double Price { get; set; }

        public KioskProduct(string name, double price)
        {
            Name = name;
            Price = price;
        }
    }
}
