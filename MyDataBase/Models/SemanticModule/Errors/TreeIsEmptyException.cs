using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataBase.Models.SemanticModule.Errors
{
    class TreeIsEmptyException:Exception
    {
        public string Message { get; set; }
        public TreeIsEmptyException(string text)
        {
            Message = text;
        }
    }
}
