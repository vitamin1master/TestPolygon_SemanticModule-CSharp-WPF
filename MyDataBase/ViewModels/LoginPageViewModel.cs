using System.Linq;
using System.Windows.Input;
using MyDataBase.Models;
using MyDataBase.Navigation;
using MyDataBase.Views;

namespace MyDataBase.ViewModels
{
    public class LoginPageViewModel:AbstractViewModel
    {
        //_ChildPageModel - модель каждой страницы, содержащая ThisUser
        private LoginWindow _loginWindow;
        public ChildPageModel ChildPageModel
        {
            get { return _ChildPageModel; }
            set { _ChildPageModel = value; }
        }
        //Commands
        public ICommand LoginIn { get; set; }
        public ICommand GoToRegistration { get; set; }
        public ICommand CloseWindow { get; set; }
        public MainModel MainModel
        {
            get { return _model; }
            set { _model = value; }
        } 
        public LoginPageViewModel(MainModel mainModel, NavigationService thisNavigationService, LoginWindow window)
        {
            MainModel = mainModel;
            _ChildPageModel = new ChildPageModel();
            _ThisNavigationService = thisNavigationService;

            LoginIn = new Commands.Commands(this, "LoginIn");
            GoToRegistration = new Commands.Commands(this, "GoToRegistration");
            CloseWindow = new Commands.Commands(this, "CloseWindow");

            _loginWindow = window;
        }

#region Func of Commands
        public override void FLoginIn()
        {
            if (_ChildPageModel.ThisUser.Login == "" || _ChildPageModel.ThisUser.Password == "")
            {
                _ChildPageModel.Error = "Login or Password is empty";
                _ChildPageModel.BoolError = true;
                _ChildPageModel.TrableUser.Login = "";
                _ChildPageModel.TrableUser.Password = "";
                var SearchResult=new InfoUser();
                SearchResult.Login = "admin";
                SearchResult.Password = "admin";
                MainModel.ThisUser = SearchResult;
                _loginWindow.Close();
            }
            else
            {
                int f = 0;
                InfoUser SearchResult = null;
                var sup = MainModel.dataBase.AccessUsers.Where(c => c.Login == _ChildPageModel.ThisUser.Login && c.Password==_ChildPageModel.ThisUser.Password);
                foreach (var VARIABLE in sup)
                {
                    f++;
                    SearchResult = VARIABLE;
                }
                if (f == 1)
                {
                    MainModel.ThisUser = SearchResult;
                    _loginWindow.Close();
                }
                else
                {
                    _ChildPageModel.Error = "Incorrect login or password";
                    _ChildPageModel.BoolError = true;
                    _ChildPageModel.TrableUser.Login = _ChildPageModel.ThisUser.Login;
                    _ChildPageModel.TrableUser.Password = _ChildPageModel.ThisUser.Password;
                }
            }
        }

        public override void FGoToRegistration()
        {
            _ThisNavigationService.Navigate("RegistrationPage");
        }

        public override void FCloseWindow()
        {
            throw new System.NotImplementedException();
        }

#region Non this page func
        public override void FCheckIn()
        {
            throw new System.NotImplementedException();
        }

        public override void FGoToLogin()
        {
            throw new System.NotImplementedException();
        }

        #endregion

#endregion

    }
}
