namespace PRA_B4_FOTOKIOSK.models
{
    public class KioskProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        public KioskProduct(string name, decimal price, string description = "")
        {
            Name = name;
            Price = price;
            Description = description;
        }

        public KioskProduct() { }

        public override string ToString()
        {
            return $"{Name} - €{Price} | {Description}";
        }
    }
}
