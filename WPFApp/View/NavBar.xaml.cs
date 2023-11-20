using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using WPFApp.Windows;

namespace WPFApp.View
{

    public partial class NavBar : UserControl 
    {

        private readonly HttpClient httpClient = new HttpClient();
        private readonly string apiUrl = "https://api.escuelajs.co/api/v1/";

        public NavBar()
        {
            InitializeComponent();        
        }

        private async void txtSearch_TextChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                string SearchText = SearchInput.Text;

                if (string.IsNullOrWhiteSpace(SearchText))
                {
                    productListView.ItemsSource = null;
                    productListView.Visibility = Visibility.Collapsed;
                }
                else
                {
                    productListView.Visibility = Visibility.Visible;
                    string productsJson = await httpClient.GetStringAsync($"{apiUrl}products");
                    var allProducts = JsonConvert.DeserializeObject<List<Product>>(productsJson);
                    var filteredProducts = allProducts.Where(product => product.Title.Contains(SearchText)).ToList();

                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        foreach (var product in filteredProducts)
                        {
                            productListView.ItemsSource = filteredProducts;
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }
        }


        private void myListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (productListView.SelectedItem != null)
            {
                Product selectedProduct = (Product)productListView.SelectedItem;
                productListView.SelectedItem = null;
                var productDetailWindow = new ProductDetailWindow();
                productDetailWindow.DataContext = selectedProduct;
                productDetailWindow.Show();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoginWindows loginWindows = new LoginWindows();
            loginWindows.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegisterWindows registerWindows = new RegisterWindows();
            registerWindows.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OrderBoxWindows orderBoxWindows = new OrderBoxWindows();
            orderBoxWindows.Show();
        }



    }
}
