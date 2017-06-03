using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataBase.Models.SemanticModule.Errors
{
    class MySyntaxErrorException:Exception
    {
        public string Message { get; set; }
        public MySyntaxErrorException(string text)
        {
            Message = text;
        }
    }
}
