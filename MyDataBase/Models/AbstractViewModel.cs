using System.Windows.Input;
using MyDataBase.Models;
using MyDataBase.Navigation;

namespace MyDataBase.ViewModels
{
    public abstract class AbstractViewModel
    {
        public MainModel _model;
        public ChildPageModel _ChildPageModel;
        public NavigationService _ThisNavigationService;
        public abstract void FLoginIn();
        public abstract void FGoToRegistration();
        public abstract void FCloseWindow();
        public abstract void FCheckIn();
        public abstract void FGoToLogin();
    }
}
