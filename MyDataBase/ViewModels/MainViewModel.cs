using System;
using System.Collections.Generic;
using System.Windows.Input;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.CodeCompletion;
using MyDataBase.Models;
using MyDataBase.Models.TextProcessing;
using MyDataBase.Views;

namespace MyDataBase.ViewModels
{
    public class MainViewModel:AbstractViewModel
    {
        public LoginWindow _loginWindow;
        public ICommand KeySpace { get; set; }
        public MainModel Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public MainViewModel(LoginWindow loginWindow)
        {
            Model=new MainModel();
            KeySpace = new Commands.Commands(this, "KeySpace");
            _loginWindow = loginWindow;
            //_loginWindow = new LoginWindow();
            _loginWindow.DataContext=new LoginWinViewModel(Model,_loginWindow);
            //_loginWindow.Show();
        }

        //public void DocTextChanged()
        //{
        //    WorkWithDoc.OnTextChanged(_model.DocumentRTB1, _model.Words);
        //}
#region Non this window Func
        public override void FLoginIn()
        {
            throw new NotImplementedException();
        }

        public override void FGoToRegistration()
        {
            throw new NotImplementedException();
        }

        public override void FCloseWindow()
        {
            throw new NotImplementedException();
        }

        public override void FCheckIn()
        {
            throw new NotImplementedException();
        }

        public override void FGoToLogin()
        {
            throw new NotImplementedException();
        }
#endregion

        public void TextChanged(TextEditor textEditor)
        {
            WordProcessing.InputHandling(textEditor, _model.UsersVars, _model.SemanticT, _model.CharacterIndexes, _model, _model.CanvasPanel);
            _model.TextOfTE = textEditor.Text;
        }

    }
}
