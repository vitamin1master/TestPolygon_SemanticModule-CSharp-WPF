using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataBase.Models.SemanticModule.Errors
{
    class FalseMeaningAtCharacterIndexes:Exception
    {
        public string Message { get; set; }
        public FalseMeaningAtCharacterIndexes(string text)
        {
            Message = text;
        }
    }
}
