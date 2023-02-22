//Tyler Simpson
//Midterm
//February 16 2023
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

namespace Midterm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Apartment> apartments = new List<Apartment>();
        Apartment currentApartment = null;
        public MainWindow()

        {
            InitializeComponent();
            Preload();
            DisplayInformation();
            DisplayApartmentCount();
            runNotes.Text = "Notes";

        }
        void Preload()
        {
            Random rand = new Random();
            for (int i = 100; i < 301; i++)
            {
                string apart = "H" + i;
                if (rand.Next(2) != 0)
                {
                    int monthly = rand.Next(1000, 3000);
                    apartments.Add(new Apartment(apart, "Will", "Cram", monthly));
                }
                else
                {
                    apartments.Add(new Apartment(apart));
                }
            }
        }
        public void DisplayInformation()
        {
            lbTenants.Items.Clear();

            for (int i = 0; i < apartments.Count; i++)
            {
                lbTenants.Items.Add(apartments[i]);
            }
        }

        public void DisplayApartmentCount()
        {
            lblTotalApartments.Content = apartments.Count;
        }

        public void DisplayApartmentNumber()
        {
            lblApartmentNumber.Content = currentApartment.ApartmentNumber;
        }
        public void ListBoxSelection()
        {
            int selectedIndex = lbTenants.SelectedIndex;
           
            if(selectedIndex >= 0)
            {
                currentApartment = apartments[selectedIndex];
            }
        }

        private void lbTenants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxSelection();
            DisplayApartmentNumber();
            DisplayTenantText();
            

        }
        public void DisplayTenantText()
        {
            txtFirstName.Text = currentApartment.FirstName;
            txtLastName.Text = currentApartment.LastName;
            txtMonthlyPayment.Text = currentApartment.MonthlyPayment.ToString();
            txtBedrooms.Text = currentApartment.NumberOfBedrooms.ToString();
            runNotes.Text = currentApartment.ApartmentNotes;
            
        }

        private void btnAddUpdateTenant_Click(object sender, RoutedEventArgs e)
        {
            currentApartment.AddUpdateTenant();

            currentApartment.FirstName = txtFirstName.Text;
            currentApartment.LastName = txtLastName.Text;
            currentApartment.MonthlyPayment = decimal.Parse(txtMonthlyPayment.Text);
            

            DisplayInformation();
            MessageBox.Show("Tenant added/Updated");
        }

        private void btnRemoveTenant_Click(object sender, RoutedEventArgs e)
        {

            ListBoxSelection();


            currentApartment.RemoveTenant();


            DisplayInformation();
            MessageBox.Show("Tenant Removed");
        }

        private void btnPartialPayment_Click(object sender, RoutedEventArgs e)
        {

            string partialPay = txtPayment.Text;
            decimal partialPayment = decimal.Parse(partialPay);
            decimal remainingBalance = currentApartment.CurrentBalance - partialPayment;
            if(remainingBalance > 0)
            {
                lblTotalBalance.Content = "$" + remainingBalance.ToString();
                currentApartment.CurrentBalance = remainingBalance;
                DisplayInformation();
                MessageBox.Show("Partial Payment made");
            }
            else
            {
                MessageBox.Show("Please input a correct partial payment");
            }
        }

        private void btnPayInFull_Click(object sender, RoutedEventArgs e)
        {
            string fullPay = txtPayment.Text;
            decimal fullPayment = decimal.Parse(fullPay);
            decimal remainingBalance = currentApartment.CurrentBalance - fullPayment;
            if(remainingBalance == 0)
            {
                lblTotalBalance.Content = "$" + remainingBalance.ToString();
                currentApartment.CurrentBalance = remainingBalance;
                DisplayInformation();
                MessageBox.Show("Full Payment made");
            }
            else
            {
                MessageBox.Show("Please input a correct full payment");
            }
        }

        private void btnMonthlyDues_Click(object sender, RoutedEventArgs e)
        {

            for (int i = 0; i < apartments.Count; i++)
            {
                apartments[i].CurrentBalance += apartments[i].MonthlyPayment;
            }
            DisplayInformation();
            MessageBox.Show("Monthly dues added");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            currentApartment.ApartmentNotes += runNotes.Text;
            MessageBox.Show("Saved");
        }
    }
}
