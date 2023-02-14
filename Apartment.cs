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
        }

        public Apartment(string apartmentNumber)
        {

        }
    }
}
