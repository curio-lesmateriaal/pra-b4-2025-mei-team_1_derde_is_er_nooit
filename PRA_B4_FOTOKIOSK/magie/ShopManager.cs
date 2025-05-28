using PRA_B4_FOTOKIOSK.models;
using System.Collections.Generic;
using System.Windows;

namespace PRA_B4_FOTOKIOSK.magie
{
    public class ShopManager
    {
        public static List<KioskProduct> Products = new List<KioskProduct>();
        public static Home Instance { get; set; }

        public static void SetShopPriceList(string text)
        {
            Instance.lbPrices.Content = text;
        }

        public static void AddShopPriceList(string text)
        {
            Instance.lbPrices.Content += text;
        }

        public static void SetShopReceipt(string text)
        {
            Instance.lbReceipt.Content = text;
        }

        public static string GetShopReceipt()
        {
            return (string)Instance.lbReceipt.Content;
        }

        public static void AddShopReceipt(string text)
        {
            SetShopReceipt(GetShopReceipt() + text);
        }

        public static void UpdateDropDownProducts()
        {
            Instance.cbProducts.Items.Clear();
            foreach (KioskProduct product in Products)
            {
                Instance.cbProducts.Items.Add(product.Name);
            }
        }

        public static KioskProduct GetSelectedProduct()
        {
            if (Instance.cbProducts.SelectedItem == null) return null;
            string selected = Instance.cbProducts.SelectedItem.ToString();
            foreach (KioskProduct product in Products)
            {
                if (product.Name == selected) return product;
            }
            return null;
        }

        public static int? GetAmount()
        {
            int amount;
            if (int.TryParse(Instance.tbAmount.Text, out amount))
            {
                return amount;
            }
            return null;
        }

        public static void AddToReceipt()
        {
            KioskProduct product = GetSelectedProduct();
            int? amount = GetAmount();

            if (product == null || amount == null || amount <= 0)
            {
                MessageBox.Show("Selecteer een product en vul een geldig aantal in.");
                return;
            }

            double total = product.Price * amount.Value;
            string line = $"{product.Name} x {amount} = €{total:F2}\n";
            AddShopReceipt(line);
        }
    }
}
