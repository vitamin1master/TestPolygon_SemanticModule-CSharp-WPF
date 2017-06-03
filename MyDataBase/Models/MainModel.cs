using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Documents;
using ICSharpCode.AvalonEdit.CodeCompletion;
using MyDataBase.Annotations;
using MyDataBase.CustomUI;
using MyDataBase.Models.SemanticModule;
using MyDataBase.Models.TextProcessing;

namespace MyDataBase.Models
{
    public class MainModel:INotifyPropertyChanged
    {
        private InfoUser _thisUser;
         
        private FlagFlowDocument _documentRTB1;
        public DataContext dataBase;

        //public ServiceWords Words { get; set; }
        public UserVariables UsersVars { get; set; }
        public string TextOfTE;
        public int CaretPositionOfTE;
        public List<int> CharacterIndexes;
        public CompletionWindow completionWindow;
        public Canvas CanvasPanel;
        public InfoUser ThisUser
        {
            get { return _thisUser; }
            set
            {
                _thisUser = value;

                //if(_thisUser.Login!=""&& _thisUser.Password!="")
                //    WorkWithDoc.StartPackage(DocumentRTB1,_thisUser);
            }
        }

        public FlagFlowDocument DocumentRTB1
        {
            get { return _documentRTB1; }
            set { _documentRTB1 = value; }
        }

        public SemanticTree SemanticT { get; set; }

        public MainModel()
        {
            CharacterIndexes = new List<int>();
            TextOfTE = "";
            CaretPositionOfTE = 0;
            UsersVars=new UserVariables();
            dataBase = new DataContext();
            ThisUser = new InfoUser();
            _documentRTB1=new FlagFlowDocument();
        }
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
