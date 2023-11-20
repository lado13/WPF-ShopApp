using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WPFApp.ContentProp
{
    public static class OrderProduct
    {
        public static List<Product> orderedProducts = new List<Product>(); 
        public static void Add(Product prod)
        {
            try
            {
                if (orderedProducts.Any(title => title.Title == prod.Title))
                {
                    MessageBox.Show("This product has already been added!!!", "Warning", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                }
                else
                {
                    orderedProducts.Add(prod);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void Remove(Product prod)
        {
            try
            {       
                if (orderedProducts != null)
                {
                    orderedProducts.Remove(prod);
                    MessageBox.Show("Product removed!!!");
                }
                else
                {
                    MessageBox.Show("Not Found");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
