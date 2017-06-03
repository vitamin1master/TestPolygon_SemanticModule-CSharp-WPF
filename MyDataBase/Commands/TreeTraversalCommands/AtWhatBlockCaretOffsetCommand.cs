using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyDataBase.Models.SemanticModule;

namespace MyDataBase.Commands.TreeTraversalCommands
{
    class AtWhatBlockCaretOffsetCommand:ICommand
    {
        public Block Result;
        private int _caretOffset;

        public AtWhatBlockCaretOffsetCommand(int caretOffset)
        {
            _caretOffset = caretOffset;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is Block)
            {
                Block block = (parameter as Block);
                if (block.StartIndex < _caretOffset && block.LastIndex > _caretOffset)
                    Result = block;
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
