using System;
using System.Collections.Generic;
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
        private List<Customer> RenderListToView;

        DbCommands cmd = new DbCommands();
        public MainWindow()
        {
            InitializeComponent();
            UpdateCustomerList();
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            txtFirstName.Text.Trim();
            if (txtFirstName.Text != string.Empty)
            {
                cmd.AddCustomerToDb(CreateCustomer());
                ClearForm();
                UpdateCustomerList();
            }
        }

        private void Selector_OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            var customer = (sender as ListView).SelectedIndex;
            if (customer >= 0)
            {
                txtFirstName.Text = RenderListToView[customer].FirstName;
                txtLastName.Text = RenderListToView[customer].LastName;
                txtAddress.Text = RenderListToView[customer].Address;
                txtPhoneNumber.Text = RenderListToView[customer].PhoneNumber;
                txtEmail.Text = RenderListToView[customer].Email;
                dpDateOfBirth.SelectedDate = RenderListToView[customer].DateOfBirth;
                txtCompanyName.Text = RenderListToView[customer].CompanyName;
                cbNewsLetter.IsChecked = RenderListToView[customer].NewsLetter;
                txtAdditionalNotes.Text = RenderListToView[customer].AdditionalNotes;
            }
        }

        private void UpdateCustomerList()
        {
            Customers = cmd.GetAllCustomers();
            RenderListToView = Customers.ToList();
            DataContext = RenderListToView;
        }

        private void txtSearch_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            var cbxSelect = cbxSearch.SelectedItem.ToString();

            switch (cbxSelect)
            {
                case "Email":
                    RenderListToView = Customers.Where(x => x.Email.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                    break;
                case "Phone number":
                    RenderListToView = Customers.Where(x => x.PhoneNumber.ToLower().Contains(txtSearch.Text.ToLower())).ToList();
                    break;
                default:
                    RenderListToView = Customers.ToList();
                    break;
            }

            DataContext = RenderListToView;
        }

        private void ComboBox_Loaded(object sender, RoutedEventArgs e)
        {
            cbxSearch.ItemsSource = new List<string>
            {
                "Email",
                "Phone number",
            };
            cbxSearch.SelectedIndex = 0;

        }

        private void CustomerSituation_Checked(object sender, RoutedEventArgs e)
        {
            if (btnBuisness.IsChecked == true)
                txtCompanyName.IsEnabled = true;
                //txtCompanyName.Style
            else
                txtCompanyName.IsEnabled = false;
        }

        private Customer CreateCustomer()
        {
            return new Customer
            {
                FirstName = txtFirstName.Text,
                LastName = txtLastName.Text,
                Address = txtAddress.Text,
                PhoneNumber = txtPhoneNumber.Text,
                Email = txtEmail.Text,
                DateOfBirth = (DateTime)dpDateOfBirth.SelectedDate,
                CompanyName = txtCompanyName.Text,
                NewsLetter = (Boolean)cbNewsLetter.IsChecked,
                AdditionalNotes = txtAdditionalNotes.Text
            };
        }

        private void ClearForm()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            dpDateOfBirth.SelectedDate = null;
            btnBuisness.IsChecked = false;
            btnPrivate.IsChecked = false;
            txtCompanyName.Text = null;
            cbNewsLetter.IsChecked = false;
            txtAdditionalNotes.Text = string.Empty;
        }

        private void ResetForm_Click(object sender, RoutedEventArgs e)
        {
            ClearForm();
        }
    }
}
