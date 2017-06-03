using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;
using ICSharpCode.AvalonEdit;
using ICSharpCode.AvalonEdit.CodeCompletion;
using ICSharpCode.AvalonEdit.Editing;
using MyDataBase.Models.SemanticModule;
using MyDataBase.Models.SemanticModule.Errors;
using MyDataBase.ViewModels;

namespace MyDataBase.Models.TextProcessing
{
    public class WordProcessing
    {
        private static void Shift(MainModel _model, int position, int textChangedOnAdd)
        {
            int j = 0;
            while (_model.CharacterIndexes[j] < position - textChangedOnAdd)
            {
                j++;
                if (j >= _model.CharacterIndexes.Count)
                    break;
            }
            if (j != _model.CharacterIndexes.Count)
                while (j < _model.CharacterIndexes.Count)
                {
                    _model.CharacterIndexes[j] = _model.CharacterIndexes[j] + textChangedOnAdd;
                    j++;
                }
        }

        public static void InputHandling(TextEditor textEditor, UserVariables userVars, SemanticTree semanticTree, List<int> characterIndexes, MainModel _model, Canvas panel)
        {
            int textChangedOnAdd = textEditor.Text.Length - _model.TextOfTE.Length;
            bool characterIndexesChanged = PreparationWordProcessing(textEditor, textChangedOnAdd, _model);
            if (characterIndexesChanged)
            {
                if (characterIndexes.Count != 0)
                {
                    semanticTree = new SemanticTree(textEditor.Text, characterIndexes);
                    _model.SemanticT = semanticTree;
                }
                else
                {
                    semanticTree = null;
                }
                if (semanticTree != null)
                {
                    semanticTree.UpdateVariableList(userVars);
                    panel.Children.Clear();
                    semanticTree.DrawTree(panel);
                }
            }
        }

        public static bool PreparationWordProcessing(TextEditor textEditor, int textChangedOnAdd, MainModel _model)
        {
            int position = textEditor.CaretOffset;
            int j = 0;

            bool characterIndexesChanged = false;

            if(textChangedOnAdd==-1)
            {
                if (_model.CharacterIndexes.Contains(position))
                {
                    _model.CharacterIndexes.Remove(position);
                    characterIndexesChanged = true;
                }
            }

            if (textChangedOnAdd < -1)
            {
                int i = textEditor.CaretOffset;
                while (i < textEditor.CaretOffset - textChangedOnAdd)
                {
                    if (_model.CharacterIndexes.Contains(i))
                    {
                        _model.CharacterIndexes.Remove(i);
                        characterIndexesChanged = true;
                    }
                    i++;
                }
            }
            if (_model.CharacterIndexes.Count != 0) 
            {
                Shift(_model, textEditor.CaretOffset, textChangedOnAdd);
            }
            if (textChangedOnAdd == 1)
            {
                if (textEditor.Text[position - 1] == '{')
                {
                    _model.CharacterIndexes.Add(position-1);
                    _model.CharacterIndexes.Sort();
                    textEditor.Document.Text = textEditor.Text.Insert(position, "}");
                    textEditor.CaretOffset = position+1;
                    Shift(_model,position+1,1);
                    _model.CharacterIndexes.Add(position);
                    
                    textEditor.CaretOffset--;
                    _model.CharacterIndexes.Sort();
                    characterIndexesChanged = true;
                }
                if (textEditor.Text[position - 1] == '}' ||
                    textEditor.Text[position - 1] == ';')
                {
                    _model.CharacterIndexes.Add(position-1);
                    _model.CharacterIndexes.Sort();
                    characterIndexesChanged = true;
                }
            }
            
            if (textChangedOnAdd > 1)
            {
                int i = textEditor.CaretOffset - textChangedOnAdd;
                while (i < textEditor.CaretOffset)
                {
                    if (textEditor.Text[i] == '{' || textEditor.Text[i] == '}' ||
                        textEditor.Text[i] == ';')
                    {
                        _model.CharacterIndexes.Add(i);
                        _model.CharacterIndexes.Sort();
                        characterIndexesChanged = true;
                    }
                    i++;
                }
            }
            
            return characterIndexesChanged;
        }

        public static CompletionWindow HelpWindowOutput(CompletionWindow completionWindow, TextEditor textEditor,
            MainModel _model)
        {

            int position = textEditor.CaretOffset;
            int l = position - 1;
            ServiceWords systemSimbols=new ServiceWords(TypeServiceWords.SystemSimbols);
            while (l>=0)
            {
                if (Char.IsWhiteSpace(textEditor.Text[l]) || systemSimbols.Exists(textEditor.Text[l].ToString()))
                    break;
                l--;
            }
            if (l == position - 1)
                return null;
            string newWord=null;
            if (l == -1)
                newWord = textEditor.Text.Substring(l + 1, position);
            else 
                newWord = textEditor.Text.Substring(l + 1, position - l-1);
            if (newWord != null)
            {
                completionWindow = new CompletionWindow(textEditor.TextArea);
                IList<ICompletionData> data = completionWindow.CompletionList.CompletionData;
                int p = 0;
                while (p < _model.UsersVars.Count)
                {
                    if (_model.UsersVars[p].Name.Contains(newWord))
                        if (_model.UsersVars[p].LevelNumber <= _model.SemanticT.GetLevelAtWhichCaretOffset(l + 1)) 
                            data.Add(new MyCompletionData(_model.UsersVars[p].Name));
                    p++;
                }
                //ServiceWords serviceWords=new ServiceWords(TypeServiceWords.AllWords);
                //p = 0;
                //while (p < serviceWords.Count())
                //{
                //    if (serviceWords[p].Contains(newWord))
                //        data.Add(new MyCompletionData(serviceWords[p]));
                //    p++;
                //}
                if (data.Count > 0)
                {
                    completionWindow.Show();
                    completionWindow.Closed += delegate
                    {
                        completionWindow = null;
                    };
                }
                else completionWindow = null;
            }
            return completionWindow;
        }
    }
}
