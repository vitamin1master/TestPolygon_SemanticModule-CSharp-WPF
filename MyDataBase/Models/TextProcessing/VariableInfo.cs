using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataBase.Models.TextProcessing
{
    public class VariableInfo
    {
        public string Name;
        public string Type;
        public int LevelNumber;
        public bool VariablePresenceIndicator;

        public VariableInfo(string name, string type, int levelNumber, bool varPresInd)
        {
            Name = name;
            Type = type;
            LevelNumber = levelNumber;
            VariablePresenceIndicator = varPresInd;
        }
    }
}
