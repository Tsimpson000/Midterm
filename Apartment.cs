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
            _apartmentNumber = apartmentNumber;
            _firstName = "";
            _lastName = "";
            _monthlyPayment = -1;
            _numberOfBedrooms = -1;
            
        }
        public string ApartmentNumber { get => _apartmentNumber;}
        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public decimal MonthlyPayment { get => _monthlyPayment; set => _monthlyPayment = value; }
        public decimal CurrentBalance { get => _currentBalance; set => _currentBalance = value; }
        public float NumberOfBedrooms { get => _numberOfBedrooms; set => _numberOfBedrooms = value; }
        public string ApartmentNotes { get => _apartmentNotes; set => _apartmentNotes = value; }
        public bool IsOccupied { get => _isOccupied; set => _isOccupied = value; }

        public override string ToString()
        {
            if(IsOccupied)
            {
                return $"{_apartmentNumber} - {_firstName} {_lastName} - {_monthlyPayment}";
            }
            else
            {
                return $"{_apartmentNumber} - Vacant - {0}";
            }
           
        }
    }
}
