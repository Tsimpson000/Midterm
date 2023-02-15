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

        public void FirstNameText()
        {
            txtFirstName.Text = currentApartment.FirstName;
        }
        public void ListBoxSelection()
        {
            int selectedIndex = lbTenants.SelectedIndex;
            currentApartment = apartments[selectedIndex];
        }
        private void lbTenants_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxSelection();
            DisplayApartmentNumber();
        }

        private void txtFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            ListBoxSelection();
            FirstNameText();
        }
    }
}
