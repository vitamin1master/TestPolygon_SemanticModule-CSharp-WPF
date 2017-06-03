using System;
using System.Threading;
using System.Windows;
using MyDataBase.Navigation;
using MyDataBase.Views;

namespace MyDataBase
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainWindow mainWindow;
        private LoginWindow _loginWindow;
        //public static NavigationService MyNavigation;
        //public static NavigationService Navigation;
        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);
            _loginWindow = new LoginWindow();
            mainWindow = new MainWindow(_loginWindow);
            mainWindow.Show();
            mainWindow.IsEnabled = false;
            _loginWindow.Closed+=(sender, args) => { mainWindow.IsEnabled = true; };
            Thread.Sleep(500);
            _loginWindow.Show();
            //MyNavigation = new NavigationService(_loginWindow.PageSpace);
            //var j = _loginWindow.DataContext;
        }
    }
}
