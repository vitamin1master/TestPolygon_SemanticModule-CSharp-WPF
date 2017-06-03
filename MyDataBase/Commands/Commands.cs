using System;
using System.Windows.Input;
using MyDataBase.ViewModels;
using MyDataBase.Views;

namespace MyDataBase.Commands
{
    public class Commands:ICommand
    {
        private AbstractViewModel _viewModel;
        private string _nameCommand;

        /// <summary>
        /// Для того, чтобы проверить, на какой странице мы находимся, используем 
        /// </summary>
        private LoginPage supLoginPage = new LoginPage();

        private RegistrationPage supRegistrPage = new RegistrationPage();

        public Commands(AbstractViewModel viewModel, string nameCommand)
        {
            _viewModel = viewModel;
            _nameCommand = nameCommand;
        }

        #region interface ICommand

        public bool CanExecute(object parameter)
        {
            if (_nameCommand == "LoginIn" || _nameCommand == "CheckIn")
                //return String.IsNullOrWhiteSpace(_viewModel._ChildPageModel[_nameCommand]);
                if (_viewModel._ChildPageModel.BoolError)
                {
                    if (_viewModel._ChildPageModel.TrableUser.Login != _viewModel._ChildPageModel.ThisUser.Login ||
                        _viewModel._ChildPageModel.ThisUser.Password != _viewModel._ChildPageModel.TrableUser.Password)
                    {
                        _viewModel._ChildPageModel.BoolError = false;
                        _viewModel._ChildPageModel.Error = null;
                    }
                }
                else return true;
            if (_nameCommand == "GoToRegistration" || _nameCommand == "GoToLogin" || _nameCommand == "CloseWindow") 
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            if (_nameCommand == "LoginIn")
                _viewModel.FLoginIn();
            if (_nameCommand == "CheckIn")
                _viewModel.FCheckIn();
            if (_nameCommand == "GoToRegistration")
                _viewModel.FGoToRegistration();
            if (_nameCommand == "GoToLogin") 
                _viewModel.FGoToLogin();
            if (_nameCommand == "CloseWindow")
            {
                //if (_viewModel._ThisNavigationService.frame.Content.GetType() == supLoginPage.GetType()) 
                    //_viewModel.FCloseWindow();
                //if (_viewModel._ThisNavigationService.frame.Content.GetType() == supRegistrPage.GetType())
                    //_viewModel.FCloseWindow();
                _viewModel.FCloseWindow();
            }

        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        #endregion
    }
}
