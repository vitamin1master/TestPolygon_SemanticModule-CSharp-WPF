using System.Linq;
using System.Windows.Input;
using MyDataBase.Models;
using MyDataBase.Navigation;
using MyDataBase.Views;

namespace MyDataBase.ViewModels
{
    public class RegistrPageViewModel:AbstractViewModel
    {
        private LoginWindow _loginWindow;
        //_ChildPageModel - модель каждой страницы, содержащая ThisUser
        public ChildPageModel ChildPageModel
        {
            get { return _ChildPageModel; }
            set { _ChildPageModel = value; }
        }

        public ICommand CheckIn { get; set; }
        public ICommand CloseWindow { get; set; }
        public ICommand GoToLogin { get; set; }

        public MainModel MainModel
        {
            get { return _model; }
            set { _model = value; }
        }

        public RegistrPageViewModel(MainModel mainModel, NavigationService thisNavigationService, LoginWindow window)
        {
            MainModel = mainModel;
            _ChildPageModel = new ChildPageModel();
            _ThisNavigationService = thisNavigationService;

            CheckIn = new Commands.Commands(this, "CheckIn");
            CloseWindow = new Commands.Commands(this, "CloseWindow");
            GoToLogin = new Commands.Commands(this, "GoToLogin");

            _loginWindow = window;
        }
        #region Func of commands
        //Non this page
        #region non this page func
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

        #endregion
        //Non this page
        public override void FCheckIn()
        {

            if (_ChildPageModel.ThisUser.Login == "" || _ChildPageModel.ThisUser.Password == "" ||
                _ChildPageModel.ThisUser.FName == "" || _ChildPageModel.ThisUser.LName == "")
            {
                
                _ChildPageModel.Error = "Some field is empty";
                _ChildPageModel.BoolError = true;
                //_ChildPageModel.TrableUser.Login = "";
                //_ChildPageModel.TrableUser.Password = "";
                //_ChildPageModel.TrableUser.FName = "";
                //_ChildPageModel.TrableUser.LName = "";

                //Рабочая схема выборки из таблицы, удаления элементов
                //InfoUser asd = new InfoUser();
                //var sup = MainModel.dataBase.AccessUsers.Where(c => c.ID == 7);
                //foreach (var VARIABLE in sup)
                //{
                //    asd = VARIABLE;
                //}
                //MainModel.dataBase.AccessUsers.Attach(asd);
                //MainModel.dataBase.AccessUsers.Remove(asd);
                //MainModel.dataBase.SaveChanges();
            }
            else
            {
                int f = 0;
                InfoUser SearchResult = null;
                var sup = MainModel.dataBase.AccessUsers.Where(c => c.Login == _ChildPageModel.ThisUser.Login);
                foreach (var VARIABLE in sup)
                {
                    f++;
                }
                if (f >= 1)
                {
                    _ChildPageModel.Error = "This user already exists";
                    _ChildPageModel.BoolError = true;

                }
                else
                {
                    MainModel.dataBase.AccessUsers.Add(_ChildPageModel.ThisUser);
                    MainModel.dataBase.SaveChanges();
                    MainModel.ThisUser = _ChildPageModel.ThisUser;
                    _loginWindow.Close();
                }
            }
        }

        public override void FGoToLogin()
        {
            _ThisNavigationService.Navigate("LoginPage");
        }



        #endregion
    }
}
