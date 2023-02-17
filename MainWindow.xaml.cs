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
                    int bedrooms = rand.Next(1, 4);
                    apartments.Add(new Apartment(apart, "Will", "Cram", monthly, bedrooms));
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
            currentApartment = apartments[selectedIndex];
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
        }

        private void btnAddUpdateTenant_Click(object sender, RoutedEventArgs e)
        {
            //ListBoxSelection();
            
            string apartmentNumber = currentApartment.ApartmentNumber;
            string fName = txtFirstName.Text;
            string lName = txtLastName.Text;
            string mPayment = txtMonthlyPayment.Text;
            string bedrooms = txtBedrooms.Text;

            decimal monthlyPayment = decimal.Parse(mPayment);
            float numberOfBedrooms = float.Parse(bedrooms);
            apartments.Remove(currentApartment);
            apartments.Add(new Apartment(apartmentNumber, fName, lName, monthlyPayment, numberOfBedrooms));

            DisplayInformation();
        }

        private void btnRemoveTenant_Click(object sender, RoutedEventArgs e)
        {
            
            //ListBoxSelection();
            int selectedIndex = lbTenants.SelectedIndex;
            Apartment currentApartment = apartments[selectedIndex];
            string apartmentNumber = currentApartment.ApartmentNumber;
            apartments.Remove(currentApartment);
            //apartments.Add(new Apartment(apartmentNumber));
            DisplayInformation();
        }

        private void btnPartialPayment_Click(object sender, RoutedEventArgs e)
        {

            string partialPay = txtPayment.Text;
            decimal partialPayment = decimal.Parse(partialPay);
            decimal remainingBalance = currentApartment.MonthlyPayment - partialPayment;
            if(remainingBalance > 0)
            {
                lblTotalBalance.Content = "$" + remainingBalance.ToString();
                currentApartment.MonthlyPayment = remainingBalance;
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
            decimal remainingBalance = currentApartment.MonthlyPayment - fullPayment;
            if(remainingBalance == 0)
            {
                lblTotalBalance.Content = "$" + remainingBalance.ToString();
                currentApartment.MonthlyPayment = remainingBalance;
            }
            else
            {
                MessageBox.Show("Please input a correct full payment");
            }
        }
    }
}
