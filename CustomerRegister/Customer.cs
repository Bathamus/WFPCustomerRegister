﻿
namespace CustomerRegister
{
    public class Customer : BaseBind
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }    }
}
