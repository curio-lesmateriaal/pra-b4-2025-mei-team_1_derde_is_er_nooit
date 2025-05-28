using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System.Windows;

namespace PRA_B4_FOTOKIOSK
{
    public partial class Home : Window
    {
        public Home()
        {
            InitializeComponent();
            ShopManager.Instance = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShopManager.Products.Add(new KioskProduct("Foto 10x15", 2.50));
            ShopManager.Products.Add(new KioskProduct("Foto 13x18", 3.50));
            ShopManager.Products.Add(new KioskProduct("Poster A3", 5.00));

            ShopManager.UpdateDropDownProducts();

            ShopManager.SetShopPriceList("Prijslijst:\n");
            foreach (var product in ShopManager.Products)
            {
                ShopManager.AddShopPriceList($"{product.Name}: €{product.Price:F2}\n");
            }
        }

        private void btnShopAdd_Click(object sender, RoutedEventArgs e)
        {
            ShopManager.AddToReceipt();
        }
    }
}
