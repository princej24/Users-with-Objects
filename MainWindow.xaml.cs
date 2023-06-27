using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Users_with_Objects
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<User> users;
        private List<Product> products;
        private string firstName;
        private readonly Membership membership;

        public MainWindow()
        {
            InitializeComponent();
            InitializeData();
            DataContext = this;
        }

        private void InitializeData()
        {
            users = new List<User>();

            products = new List<Product>
            {
                new Product("cheese", 10.99),
                new Product(" organic watermelon", 15.99),
                new Product("pound of apples", 5.99)
               
            };

            lstProducts.ItemsSource = products;
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text;


            if (!string.IsNullOrEmpty(username))
            {

                User user = new User(username, membership);



                users.Add(user);

                MessageBox.Show("User added successfully!");
            }
            else
            {
                MessageBox.Show("Please enter a username.");
            }
        }

        private void btnAddToCart_Click(object sender, RoutedEventArgs e)
        {
            Product selectedProduct = lstProducts.SelectedItem as Product;

            if (selectedProduct != null)
            {
                User selectedUser = users[lstCart.SelectedIndex];

                selectedUser.ShoppingCart.Products.Add(selectedProduct);

                lstCart.Items.Refresh();

                MessageBox.Show("Product added to cart successfully!");
            }
            else
            {
                MessageBox.Show("try again");

            }


           

        }
        private void btnCheckout_Click(object sender, RoutedEventArgs e)
        {
            User selectedUser = lstCart.SelectedItem as User;

            if (selectedUser != null)
            {
                double totalAmount = CalculateTotalAmount(selectedUser);

                MessageBox.Show($"Checkout complete! Total amount: {totalAmount}");

               
                selectedUser.ShoppingCart.Products.Clear();
                lstCart.Items.Refresh();
            }
            else
            {
                MessageBox.Show("Please select a user from the shopping cart.");
            }

        }

        private double CalculateTotalAmount(User user)
        {
            double totalAmount = 0;

            foreach (Product product in user.ShoppingCart.Products)
            {
                totalAmount += product.Price;
            }

            
            if (user.Membership != null)
            {
                double discount = user.Membership.CalculateDiscount(totalAmount);
                totalAmount -= discount;
            }

            return totalAmount;
        }
    }
}
