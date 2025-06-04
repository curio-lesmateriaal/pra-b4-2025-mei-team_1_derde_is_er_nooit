using PRA_B4_FOTOKIOSK.models;
using System;
using System.Collections.Generic;
<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD
using System.Globalization;
=======
=======
>>>>>>> parent of e85a591 (c1)
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
<<<<<<< HEAD
>>>>>>> parent of e85a591 (c1)
=======
>>>>>>> parent of e85a591 (c1)
>>>>>>> 87f44100343c6c10c8dc91dafea3b37fd1bf240d
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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
            Instance.lbPrices.Content = Instance.lbPrices.Content + text;
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
            foreach (KioskProduct item in Products)
            {
                Instance.cbProducts.Items.Add(item.Name);
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
<<<<<<< HEAD
<<<<<<< HEAD
        {
            if (int.TryParse(Instance.tbFotoId.Text, out int id))
                return id;
            return null;
=======
        {
            int? id = null;
            int amount = -1;
            if (int.TryParse(Instance.tbFotoId.Text, out amount))
            {
                id = amount;
            }
            return id;
>>>>>>> parent of e85a591 (c1)
        }

        public static int? GetAmount()
        {
<<<<<<< HEAD
            if (int.TryParse(Instance.tbAmount.Text, out int amount))
                return amount;
            return null;
=======
        {
            int? id = null;
            int amount = -1;
            if (int.TryParse(Instance.tbFotoId.Text, out amount))
            {
                id = amount;
            }
            return id;
>>>>>>> parent of e85a591 (c1)
        }

        public static int? GetAmount()
        {
<<<<<<< HEAD
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

<<<<<<< HEAD
            Instance.lblTotalAmount.Content = $"Totaalbedrag: €{som:F2}";
=======
        public static void ResetTotaalBedrag()
        {
            totaalBedrag = 0;
=======
            int? id = null;
            int amount = -1;
            if (int.TryParse(Instance.tbAmount.Text, out amount))
            {
                id = amount;
            }
            return id;
>>>>>>> parent of e85a591 (c1)
=======
            int? id = null;
            int amount = -1;
            if (int.TryParse(Instance.tbAmount.Text, out amount))
            {
                id = amount;
            }
            return id;
>>>>>>> parent of e85a591 (c1)
>>>>>>> 87f44100343c6c10c8dc91dafea3b37fd1bf240d
        }
    }
}
