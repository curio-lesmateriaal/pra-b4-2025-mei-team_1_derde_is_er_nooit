﻿using PRA_B4_FOTOKIOSK.models;
using System.Collections.Generic;
using System.Windows;

namespace PRA_B4_FOTOKIOSK.magie
{
    public class ShopManager
    {
        public static List<KioskProduct> Products = new List<KioskProduct>();
        public static Home Instance { get; set; }

        private static List<double> bedragen = new List<double>();

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

        public static int? GetFotoId()
        {
            if (int.TryParse(Instance.tbFotoId.Text, out int id))
                return id;
            return null;
        }

        public static int? GetAmount()
        {
            if (int.TryParse(Instance.tbAmount.Text, out int amount))
                return amount;
            return null;
        }

        public static void AddToReceipt()
        {
            KioskProduct product = GetSelectedProduct();
            int? amount = GetAmount();
            int? fotoId = GetFotoId();

            if (product == null || amount == null || fotoId == null || amount <= 0)
            {
                MessageBox.Show("Vul een geldig foto-id, selecteer een product en geef een juist aantal op.");
                return;
            }

            double total = (double)product.Price * amount.Value;
            string line = $"Foto-ID: {fotoId} | {product.Name} x {amount} = €{total:F2}\n";
            AddShopReceipt(line);

            bedragen.Add(total);
            double som = 0;
            foreach (var bedrag in bedragen)
                som += bedrag;

            Instance.lblTotalAmount.Content = $"Totaalbedrag: €{som:F2}";
        }
    }
}
