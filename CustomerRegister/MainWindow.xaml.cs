using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CustomerRegister
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Customer> Customers;
        public MainWindow()
        {
            InitializeComponent();
            DbCommands cmd = new DbCommands();
            DataContext = cmd.GetAllCustomers();
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            txtFirstName.Text.Trim();
            if (txtFirstName.Text != string.Empty)
            {
                Customers.Add(new Customer
                {
                    FirstName = txtFirstName.Text
                });
                txtFirstName.Text = string.Empty;
            }
        }

        private void Selector_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            Nullable<int>item = (sender as ListView).SelectedIndex;
            if (item != null)
            {
                txtFirstName.Text = Customers[(int)item].FirstName;
            }
        }
    }
}
