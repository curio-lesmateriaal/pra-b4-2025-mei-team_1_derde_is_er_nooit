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

            // Vul de productenlijst
            ShopManager.Products.Add(new KioskProduct { Name = "Foto afdruk 10x15", Price = 0.50m });
            ShopManager.Products.Add(new KioskProduct { Name = "Foto afdruk 13x18", Price = 1.00m });
            ShopManager.Products.Add(new KioskProduct { Name = "Fotoboek", Price = 15.00m });
            ShopManager.Products.Add(new KioskProduct { Name = "Canvas print", Price = 25.00m });
            ShopManager.Products.Add(new KioskProduct { Name = "Mok met foto", Price = 8.50m });
            ShopManager.Products.Add(new KioskProduct { Name = "T-shirt met foto", Price = 12.99m });

            ShopManager.UpdateDropDownProducts();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Refresh button clicked!");
        }

        private void btnShopAdd_Click(object sender, RoutedEventArgs e)
        {
            ShopManager.AddToReceipt();
        }

        private void btnShopReset_Click(object sender, RoutedEventArgs e)
        {
            tbFotoId.Text = "";
            tbAmount.Text = "";
            cbProducts.SelectedIndex = -1;
            ShopManager.SetShopReceipt("");
            ShopManager.ResetTotaalBedrag();
            lblTotalAmount.Content = "Totaalbedrag: €0,00";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            string bon = ShopManager.GetShopReceipt();
            MessageBox.Show("Bon opgeslagen:\n" + bon);
        }

        private void btnZoeken_Click(object sender, RoutedEventArgs e)
        {
            string zoekterm = tbZoeken.Text.Trim();
            if (string.IsNullOrEmpty(zoekterm))
            {
                MessageBox.Show("Vul een zoekterm in.");
                return;
            }

            lbSearchInfo.Content = $"Zoeken naar: {zoekterm}";
        }
    }
}
