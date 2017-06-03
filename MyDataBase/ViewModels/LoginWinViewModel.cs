using System.Windows.Input;
using MyDataBase.Models;
using MyDataBase.Navigation;
using MyDataBase.Views;

namespace MyDataBase.ViewModels
{
    public class LoginWinViewModel:AbstractViewModel
    {
        //Pages
        public readonly LoginPage _loginPage;
        public readonly RegistrationPage _registrPage;
        //Page's ViewModels
        public LoginPageViewModel _loginPageViewModel;
        public RegistrPageViewModel _registrPageViewModel;
        public MainModel MainModel
        {
            get { return _model; }
            set { _model = value; }
        }
        public LoginWinViewModel(MainModel mainModel, LoginWindow loginWindow)
        {
            MainModel = mainModel;

            //_ChildPageModel нужна только страницам
            _ChildPageModel = null;


            _ThisNavigationService=new NavigationService(loginWindow.PageSpace);
            //_loginPage = new LoginPage();
            _loginPageViewModel = new LoginPageViewModel(MainModel, _ThisNavigationService, loginWindow);
            //_loginPage.DataContext = _loginPageViewModel;
            _loginPage = new LoginPage(_loginPageViewModel);

            _registrPage = new RegistrationPage();
            _registrPageViewModel=new RegistrPageViewModel(MainModel,_ThisNavigationService, loginWindow);
            _registrPage.DataContext = _registrPageViewModel;

            //Navigation Service
            _ThisNavigationService.PushPages(_loginPage, _registrPage);
            //_ThisNavigationService = App.MyNavigation;
            _ThisNavigationService.Navigate("LoginPage");
        }

#region Non this window Func
        public override void FLoginIn()
        {
            throw new System.NotImplementedException();
        }

        public override void FGoToRegistration()
        {
            throw new System.NotImplementedException();
        }

        public override void FCloseWindow()
        {
            throw new System.NotImplementedException();
        }

        public override void FCheckIn()
        {
            throw new System.NotImplementedException();
        }

        public override void FGoToLogin()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
