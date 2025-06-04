using PRA_B4_FOTOKIOSK.controller;
using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.IO;
<<<<<<< HEAD
<<<<<<< HEAD
=======
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> parent of e85a591 (c1)
=======
using System.Linq;
using System.Text;
using System.Threading.Tasks;
>>>>>>> parent of e85a591 (c1)
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PRA_B4_FOTOKIOSK
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Window
    {

        public ShopController ShopController { get; set; }
        public PictureController PictureController { get; set; }
        public SearchController SearchController { get; set; }

        public Home()
        {
            // Bouw de UI
            InitializeComponent();
<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD

>>>>>>> 87f44100343c6c10c8dc91dafea3b37fd1bf240d
            ShopManager.Instance = this;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
<<<<<<< HEAD
            // Voeg producten toe
            ShopManager.Products.Add(new KioskProduct("Foto 10x15", 2.50m));
            ShopManager.Products.Add(new KioskProduct("Foto 13x18", 3.50m));
            ShopManager.Products.Add(new KioskProduct("Poster A3", 5.00m));

            // Vul dropdown
            ShopManager.UpdateDropDownProducts();

            // Toon prijslijst
            ShopManager.SetShopPriceList("Prijslijst:\n");
            foreach (var product in ShopManager.Products)
            {
                ShopManager.AddShopPriceList($"{product.Name}: €{product.Price:F2}\n");
            }
=======
            MessageBox.Show("Refresh button clicked!");
=======

            // Stel de manager in
            PictureManager.Instance = this;
            ShopManager.Instance = this;
            ShopController.Window = this;
            PictureController.Window = this;
            SearchController.Window = this;

            // Maak de controllers
            ShopController = new ShopController();
            PictureController = new PictureController();
            SearchController = new SearchController();

=======

            // Stel de manager in
            PictureManager.Instance = this;
            ShopManager.Instance = this;
            ShopController.Window = this;
            PictureController.Window = this;
            SearchController.Window = this;

            // Maak de controllers
            ShopController = new ShopController();
            PictureController = new PictureController();
            SearchController = new SearchController();

>>>>>>> parent of e85a591 (c1)
            // Start de paginas
            PictureController.Start();
            ShopController.Start();
            SearchController.Start();
<<<<<<< HEAD
>>>>>>> parent of e85a591 (c1)
=======
>>>>>>> parent of e85a591 (c1)
>>>>>>> 87f44100343c6c10c8dc91dafea3b37fd1bf240d
        }

        private void btnShopAdd_Click(object sender, RoutedEventArgs e)
        {
            ShopController.AddButtonClick();
        }

        private void btnShopReset_Click(object sender, RoutedEventArgs e)
        {
            ShopController.ResetButtonClick();
        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            PictureController.RefreshButtonClick();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            ShopController.SaveButtonClick();
        }

        private void btnZoeken_Click(object sender, RoutedEventArgs e)
        {
            SearchController.SearchButtonClick();
<<<<<<< HEAD
        }

        private void btnShopReset_Click(object sender, RoutedEventArgs e)
        {
            tbFotoId.Text = "";
            cbProducts.SelectedIndex = -1;
<<<<<<< HEAD
            ShopManager.SetShopReceipt("");
            ShopManager.ResetTotaalBedrag();
            lblTotalAmount.Content = "Totaalbedrag: €0,00";
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // Haal de bon op via ShopManager
            string bon = ShopManager.GetShopReceipt();

            // Controleer of er iets is om op te slaan
            if (string.IsNullOrWhiteSpace(bon))
            {
                MessageBox.Show("Er is geen bon om op te slaan.");
                return;
            }

            // Bepaal het pad waar het bestand wordt opgeslagen: in de Documentenmap
            string bestandsPad = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "bon.txt");

            try
            {
                // Schrijf de bon naar het tekstbestand
                File.WriteAllText(bestandsPad, bon);
                MessageBox.Show($"Bon succesvol opgeslagen in:\n{bestandsPad}");
            }
            catch (IOException ex)
            {
                // Toon een foutmelding als het opslaan mislukt
                MessageBox.Show("Fout bij opslaan van de bon:\n" + ex.Message);
            }
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

            // Eventueel hier productzoekfunctionaliteit implementeren
            // Bijvoorbeeld producten filteren op naam of categorie
=======
<<<<<<< HEAD
            tbAmount.Text = "";
>>>>>>> parent of c211cca (c1 verbeterd)
=======
>>>>>>> parent of e85a591 (c1)
>>>>>>> 87f44100343c6c10c8dc91dafea3b37fd1bf240d
        }
    }
}
