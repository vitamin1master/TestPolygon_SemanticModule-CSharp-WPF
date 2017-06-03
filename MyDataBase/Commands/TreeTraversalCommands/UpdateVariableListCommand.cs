using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MyDataBase.Models.SemanticModule;
using MyDataBase.Models.SemanticModule.LogicalBlocks;
using MyDataBase.Models.TextProcessing;

namespace MyDataBase.Commands.TreeTraversalCommands
{
    class UpdateVariableListCommand:ICommand
    {
        private UserVariables _userVariables;

        public UpdateVariableListCommand(UserVariables userVariables)
        {
            _userVariables = userVariables;
        }
        public bool CanExecute(object parameter)
        {
            if (parameter is DeclaringVarsBlock)
                return true;
            return false;
        }

        public void Execute(object parameter)
        {
            if (parameter is DeclaringVarsBlock)
            {
                DeclaringVarsBlock block = (parameter as DeclaringVarsBlock);
                int i=0, n = block.NamesAndValues.Count;
                while (i < n)
                {
                    int k = _userVariables.Exists(block.TypeVars, block.NamesAndValues[i].First, block.LevelNumber);
                    if (k == -1)
                    {
                        _userVariables.AddVariable(block.NamesAndValues[i].First, block.TypeVars, block.LevelNumber,
                            true);
                    }
                    else _userVariables[k].VariablePresenceIndicator = true;
                    i++;
                }
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
