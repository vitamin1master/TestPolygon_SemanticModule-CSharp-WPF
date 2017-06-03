using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.CodeCompletion;
using MyDataBase.CustomUI;
using MyDataBase.Models.TextProcessing;
using MyDataBase.ViewModels;
using MyDataBase.Views;

namespace MyDataBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(LoginWindow _loginWindow)
        {
            DataContext=new MainViewModel(_loginWindow);
            InitializeComponent();
            (DataContext as MainViewModel).Model.CanvasPanel = Panel;
            //textEditor.TextArea.TextEntering += textEditor_TextArea_TextEntering;
            textEditor.TextArea.TextEntered += textEditor_TextArea_TextEntered;
        }

        CompletionWindow completionWindow;

        void textEditor_TextArea_TextEntered(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Length == 1)
                completionWindow = WordProcessing.HelpWindowOutput(completionWindow, textEditor,
                    (DataContext as MainViewModel).Model);
        }

        void textEditor_TextArea_TextEntering(object sender, TextCompositionEventArgs e)
        {
            if (e.Text.Length > 0 && completionWindow != null)
            {
                if (!char.IsLetterOrDigit(e.Text[0]))
                {
                    // Whenever a non-letter is typed while the completion window is open,
                    // insert the currently selected element.
                    completionWindow.CompletionList.RequestInsertion(e);
                }
            }
            // Do not set e.Handled=true.
            // We still want to insert the character that was typed.
        }

        //private void DocumentBox1_OnTextChanged(object sender, TextChangedEventArgs e)
        //{
        //    if (sender is DocumentBox)
        //        if ((sender as DocumentBox).FlagDocument.Flag==false)
        //            if (DataContext is MainViewModel)
        //            {
        //                (sender as DocumentBox).TextChanged -= DocumentBox1_OnTextChanged;

        //                //TextPointer p = (sender as DocumentBox).Selection.Start;
        //                TextPointer p = (sender as DocumentBox).CaretPosition.DocumentStart;
        //                TextPointer t = (sender as DocumentBox).CaretPosition;
        //                int k = p.GetOffsetToPosition(t);
        //                (DataContext as MainViewModel).DocTextChanged();
        //                if (k != 0)
        //                    p = p.GetPositionAtOffset(k);
        //                (sender as DocumentBox).CaretPosition = p;

        //                (sender as DocumentBox).TextChanged += DocumentBox1_OnTextChanged;
        //            }
        //}

        private void TextEditor_OnTextChanged(object sender, EventArgs e)
        {
            if (sender is TextEditor)
                if (DataContext is MainViewModel)
                    (DataContext as MainViewModel).TextChanged(sender as TextEditor);
        }
    }
}
