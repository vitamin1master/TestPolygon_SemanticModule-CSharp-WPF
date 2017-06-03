using MyDataBase.Models;
using MyDataBase.Navigation;

namespace MyDataBase.ViewModels
{
    public interface IViewModel
    {
        void FLoginIn();
        void FGoToRegistration();
        void FCloseWindow();
        void FCheckIn();
        void FGoToLogin();
    }
}