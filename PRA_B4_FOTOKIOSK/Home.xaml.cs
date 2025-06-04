using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.IO;
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
        }

        private void btnShopAdd_Click(object sender, RoutedEventArgs e)
        {
            ShopManager.AddToReceipt();
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
            tbAmount.Text = "";
>>>>>>> parent of c211cca (c1 verbeterd)
        }
    }
}
