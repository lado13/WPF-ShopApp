using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using WPFApp.Windows;

namespace WPFApp.View
{

    public partial class ContentUI : UserControl
    {
        private HttpClient httpClient = new HttpClient();
        private const string apiUrl = "https://api.escuelajs.co/api/v1/";
        public ContentUI()
        {
            InitializeComponent();
            SomeOtherAsyncMethod();
        }

        private async Task LoadCategories()
        {
            try
            {
                string categoriesJson = await httpClient.GetStringAsync($"{apiUrl}categories");
                List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(categoriesJson);
                CategoryListView.ItemsSource = categories;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}");
            }
        }

        private async Task LoadProductsByCategory(int categoryId)
        {    
            try
            {
                string productsJson = await httpClient.GetStringAsync($"{apiUrl}categories/{categoryId}/products");
                List<Product> products = JsonConvert.DeserializeObject<List<Product>>(productsJson);
                productListView.ItemsSource = products;
                lodingText.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}");
            }
        }


        private async Task Loading()
        {
            char[] charArray = { 'L', 'o', 'a', 'd', 'i', 'n', 'g', '.', '.', '.' };
            Random random = new Random();

            foreach (var character in charArray)
            {
                Color randomColor = Color.FromRgb((byte)random.Next(256), (byte)random.Next(256), (byte)random.Next(256));
                Run run = new Run(character.ToString())
                {
                    Foreground = new SolidColorBrush(randomColor)
                };
                lodingText.Inlines.Add(run);
            }
        }

        private async Task SomeOtherAsyncMethod()
        {
            await Loading();
            await LoadCategories();
            await LoadProductsByCategory(2);    
        }

        private async void CategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Category category)
            {
                LoadProductsByCategory(category.Id);
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


     


    }
}
