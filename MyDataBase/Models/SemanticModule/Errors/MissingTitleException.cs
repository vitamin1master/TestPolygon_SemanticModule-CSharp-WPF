using System;

namespace MyDataBase.Models.SemanticModule.Errors
{
    class MissingTitleException:Exception
    {
        public string Message { get; set; }
        public MissingTitleException(string text)
        {
            Message = text;
        }
    }
}
