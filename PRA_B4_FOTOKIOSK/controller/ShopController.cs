using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace PRA_B4_FOTOKIOSK.controller
{
    public class ShopController
    {
        public static Home Window { get; set; }
        private static List<(int FotoId, string ProductNaam, int Aantal, decimal Totaalprijs)> Bestellingen = new List<(int, string, int, decimal)>();

        public void Start()
        {
            ShopManager.SetShopReceipt("Eindbedrag:\n€0,00");

            ShopManager.Products.Add(new KioskProduct() { Name = "Foto 15x20", Price = 4.00m, Description = "Afdruk 15x20 cm" });
            ShopManager.Products.Add(new KioskProduct() { Name = "Sleutelhanger", Price = 7.00m, Description = "Sleutelhanger met foto" });
            ShopManager.Products.Add(new KioskProduct() { Name = "Mok", Price = 9.33m, Description = "Mok met foto" });
            ShopManager.Products.Add(new KioskProduct() { Name = "T-shirt", Price = 12.69m, Description = "T-shirt met foto" });

            ShopManager.SetShopPriceList("Prijzen:\n");
            foreach (KioskProduct product in ShopManager.Products)
            {
                ShopManager.AddShopPriceList($"{product.Name} - €{product.Price:F2}\nBeschrijving: {product.Description}\n");
            }

            ShopManager.UpdateDropDownProducts();
        }

        public void AddButtonClick()
        {
            KioskProduct selectedProduct = ShopManager.GetSelectedProduct();
            int? fotoId = ShopManager.GetFotoId();
            int? amount = ShopManager.GetAmount();

            if (selectedProduct == null || fotoId == null || amount == null || amount <= 0)
            {
                ShopManager.AddShopReceipt("\nFout: Vul alle velden correct in.");
                return;
            }

            decimal total = selectedProduct.Price * amount.Value;
            Bestellingen.Add((fotoId.Value, selectedProduct.Name, amount.Value, total));

            UpdateReceipt();
        }

        private void UpdateReceipt()
        {
            string bonTekst = "Bestellingen:\n";

            foreach (var bestelling in Bestellingen)
            {
                bonTekst += $"FotoID: {bestelling.FotoId}\nProduct: {bestelling.ProductNaam}\nAantal: {bestelling.Aantal}\nSubtotaal: €{bestelling.Totaalprijs:F2}\n\n";
            }

            decimal totaalBedrag = Bestellingen.Sum(b => b.Totaalprijs);
            bonTekst += $"===================\nEindbedrag: €{totaalBedrag:F2}\n===================";

            ShopManager.SetShopReceipt(bonTekst);

            // Voorkomen dat een tweede eindbedrag verschijnt
            if (Window != null)
            {
                Window.lbSearchInfo.Content = ""; // Eerst leegmaken
                Window.lbSearchInfo.Content = $"Eindbedrag: €{totaalBedrag:F2}"; // Dan opnieuw instellen
            }
        }

        public void ResetButtonClick()
        {
            Bestellingen.Clear();
            ShopManager.SetShopReceipt("Eindbedrag:\n€0,00");

            if (Window != null) Window.lbSearchInfo.Content = "Eindbedrag: €0,00";
        }

        public void SaveButtonClick()
        {
            string receipt = ShopManager.GetShopReceipt();
            string filePath = "receipt.txt";
            File.WriteAllText(filePath, receipt);
            MessageBox.Show($"Bon opgeslagen naar {filePath}");

        }
    }
}
