
namespace CustomerRegister
{
    public class Customer : BaseBind
    {
        private string _firstName;

        public int CustomerId { get; set; } 

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }
    }
}
