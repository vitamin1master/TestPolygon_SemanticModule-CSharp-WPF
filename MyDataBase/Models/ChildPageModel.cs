using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MyDataBase.Annotations;

namespace MyDataBase.Models
{
    public class ChildPageModel:IDataErrorInfo,INotifyPropertyChanged
    {
        private InfoUser _thisUser;
        private string _error;
        public InfoUser TrableUser { get; set; }
        public InfoUser ThisUser
        {
            get { return _thisUser; }
            set { _thisUser = value; }
        }

        public ChildPageModel()
        {
            ThisUser=new InfoUser();
            TrableUser = new InfoUser();
            BoolError = false;
            Error = null;
        }
        public bool BoolError { get; set; }
        public string this[string columnName]
        {
            get { return Error; }
            //{
            //    if (columnName == "LoginIn")
            //        if (ThisUser.Login == "" || ThisUser.Password == "") 
            //            Error = "Login or Password is empty";
            //        else Error = null;
            //    if (columnName == "CheckIn")
            //        if (ThisUser.Login == "" || ThisUser.Password == "" || ThisUser.FName == "" ||
            //            ThisUser.LName == "") 
            //            Error = "Login or Password or FirstName or LastName is empty";
            //        else Error = null;
            //    return Error;
            //}
        }

        public string Error { get { return _error; } set { _error = value; OnPropertyChanged("Error");} }

        #region interface INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
#endregion
    }
}

