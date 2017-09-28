
using System;

namespace CustomerRegister
{
    public class Customer : BaseBind
    {
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _phoneNumber;
        private string _email;
        private DateTime _dateOfBirth;
        private string _companyName;
        private bool _newsLetter;
        private string _additionalNotes;
        

        public int CustomerId { get; set; } 

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; NotifyPropertyChanged("FirstName"); }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; NotifyPropertyChanged("LastName"); }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; NotifyPropertyChanged("Address"); }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; NotifyPropertyChanged("PhoneNumber"); }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; NotifyPropertyChanged("Email"); }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; NotifyPropertyChanged("DateOfBirth"); }
        }
        public string CompanyName
        {
            get { return _companyName; }
            set { _companyName = value; NotifyPropertyChanged("CompanyName"); }
        }
        public bool NewsLetter
        {
            get { return _newsLetter; }
            set { _newsLetter = value; NotifyPropertyChanged("NewsLetter"); }
        }
        public string AdditionalNotes
        {
            get { return _additionalNotes; }
            set { _additionalNotes = value; NotifyPropertyChanged("AdditionalNotes"); }
        }
    }
}
