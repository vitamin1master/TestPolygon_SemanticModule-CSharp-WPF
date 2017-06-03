using System.ComponentModel;
using System.Runtime.CompilerServices;
using MyDataBase.Annotations;

namespace MyDataBase.Models
{
    public class InfoUser:INotifyPropertyChanged
    {
        private string _login, _password, _fName, _lName;
        public int ID { get; set; }
        public string Login
        {
            get { return _login; }
            set { _login = value;
                OnPropertyChanged("Login");
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
        public string FName
        {
            get { return _fName; }
            set
            {
                _fName = value;
                OnPropertyChanged("FName");
            }
        }
        public string LName
        {
            get { return _lName; }
            set
            {
                _lName = value;
                OnPropertyChanged("LName");
            }
        }
        public InfoUser()
        {
            ID = 0;
            Login = "";
            Password = "";
            FName = "";
            LName = "";
        }

        #region interface INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) 
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
