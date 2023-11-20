using System.Windows;
using WPFApp.ContentProp;
using WPFApp.Members;

namespace WPFApp.Windows
{

    public partial class OrderBoxWindows : Window
    {
    
        public OrderBoxWindows()
        {
            InitializeComponent();
            var prod = OrderProduct.orderedProducts;
            productListView.ItemsSource = prod;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           MembersSystem membersSystem = new MembersSystem();

            if (membersSystem.IsActive == true)
            {
                foreach (var item in productListView.ItemsSource)
                {
                    MessageBox.Show(item.ToString(), "Successfully sent order");
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Please login!!!","Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                LoginWindows loginWindows = new LoginWindows();
                loginWindows.Show();
            }
        }



        private void RemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            var selectedProduct = productListView.SelectedItem;

            Product product = selectedProduct as Product;
           
            if (selectedProduct != null)
            {
                OrderProduct.Remove(product);
                productListView.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please select a product to remove.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }




    }
}
