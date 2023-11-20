using System.Windows;
using WPFApp.ContentProp;

namespace WPFApp.Windows
{

    public partial class ProductDetailWindow : Window
    {
        public ProductDetailWindow()
        {
            InitializeComponent();
        }
   
        private void AddCart_Click(object sender, RoutedEventArgs e)
        {  
            Product prod = DataContext as Product;
            OrderProduct.Add(prod);      
            this.Close();
        }




    }
}
