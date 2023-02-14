using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm
{
    public class Apartment
    {
        string _apartmentNumber;
        string _firstName;
        string _lastName;
        decimal _monthlyPayment;
        decimal _currentBalance;
        float _numberOfBedrooms;
        string _apartmentNotes;
        bool _isOccupied;

        public Apartment(string apartmentNumber, string firstName, string lastName, decimal monthlyPayment, float numberOfBedrooms)
        {
            _apartmentNumber = apartmentNumber;
            _firstName = firstName;
            _lastName = lastName;
            _monthlyPayment = monthlyPayment;
            _numberOfBedrooms = numberOfBedrooms;
            _isOccupied = true;
        }

        public Apartment(string apartmentNumber)
        {
            _isOccupied = false;
            _firstName = "";
            _lastName = "";
            _monthlyPayment = 0;
            _numberOfBedrooms = 0;
            
        }
        public string ApartmentNumber { get => _apartmentNumber; set => _apartmentNumber = value; }
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public decimal MonthlyPayment { get => _monthlyPayment; set => _monthlyPayment = value; }
        public decimal CurrentBalance { get => _currentBalance; set => _currentBalance = value; }
        public float NumberOfBedrooms { get => _numberOfBedrooms; set => _numberOfBedrooms = value; }
        public string ApartmentNotes { get => _apartmentNotes; set => _apartmentNotes = value; }
        public bool IsOccupied { get => _isOccupied; set => _isOccupied = value; }
    }
}
