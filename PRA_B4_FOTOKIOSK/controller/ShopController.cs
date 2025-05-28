using PRA_B4_FOTOKIOSK.magie;
using PRA_B4_FOTOKIOSK.models;
using System;
using System.IO;
using System.Linq;

namespace PRA_B4_FOTOKIOSK.controller
{
    public class ShopController
    {
        public static Home Window { get; set; }

        public void Start()
        {
            // Stel de bon in
            ShopManager.SetShopReceipt("Eindbedrag:\n€0,00");

            // Voeg producten toe
            ShopManager.Products.Add(new KioskProduct()
            {
                Name = "Foto 15x20",
                Price = 4.00m,
                Description = "Afdruk 15x20 cm"
            });

            ShopManager.Products.Add(new KioskProduct()
            {
                Name = "Sleutelhanger",
                Price = 7.00m,
                Description = "Sleutelhanger met foto"
            });

            ShopManager.Products.Add(new KioskProduct()
            {
                Name = "Mok",
                Price = 9.33m,
                Description = "Mok met foto"
            });

            ShopManager.Products.Add(new KioskProduct()
            {
                Name = "T-shirt",
                Price = 12.69m,
                Description = "T-shirt met foto"
            });

            // Prijslijst opbouwen
            ShopManager.SetShopPriceList("Prijzen:\n");
            foreach (KioskProduct product in ShopManager.Products)
            {
                ShopManager.AddShopPriceList(product.ToString() + "\n");
            }

            // Product dropdown vullen
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
            string line = $"\nFotoID: {fotoId} | {selectedProduct.Name} | Aantal: {amount} | Subtotaal: €{total:F2}";

            // Huidige bon ophalen en eindbedrag verwijderen
            string receipt = ShopManager.GetShopReceipt();
            string zonderEindbedrag = RemoveOldTotal(receipt);

            // Nieuwe regel toevoegen
            zonderEindbedrag += line;

            // Nieuw totaalbedrag berekenen
            decimal nieuwTotaal = CalculateTotal(zonderEindbedrag);

            // Eindbedrag toevoegen
            zonderEindbedrag += $"\n\nEindbedrag:\n€{nieuwTotaal:F2}";

            // Bon updaten
            ShopManager.SetShopReceipt(zonderEindbedrag);
        }

        public void ResetButtonClick()
        {
            ShopManager.SetShopReceipt("Eindbedrag:\n€0,00");
        }

        public void SaveButtonClick()
        {
            string receipt = ShopManager.GetShopReceipt();
            string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Bon.txt");
            File.WriteAllText(path, receipt);
            ShopManager.AddShopReceipt("\nBon opgeslagen op Bureaublad.");
        }

        // Helpers

        private string RemoveOldTotal(string receipt)
        {
            var regels = receipt.Split('\n');
            return string.Join("\n", regels.Where(r => !r.StartsWith("Eindbedrag") && !r.StartsWith("€")));
        }

        private decimal CalculateTotal(string receipt)
        {
            decimal totaal = 0;
            foreach (string regel in receipt.Split('\n'))
            {
                if (regel.Contains("Subtotaal: €"))
                {
                    int index = regel.IndexOf("€") + 1;
                    if (decimal.TryParse(regel.Substring(index), out decimal bedrag))
                    {
                        totaal += bedrag;
                    }
                }
            }
            return totaal;
        }
    }
}
