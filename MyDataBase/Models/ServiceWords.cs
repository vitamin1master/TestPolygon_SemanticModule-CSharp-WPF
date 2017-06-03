using System.Collections.Generic;

namespace MyDataBase.Models
{
    public enum TypeServiceWords
    {
        TypeVar=1,
        Cycles=2,
        SystemSimbols=3,
        AllWords=4,
    }
    public class ServiceWords
    {
        private List<string> _listWords;
        public ServiceWords()
        {
            _listWords=new List<string>();
        }

        public ServiceWords(TypeServiceWords type)
        {
            _listWords=new List<string>();
            if (type == TypeServiceWords.TypeVar)
            {
                _listWords.Add("int");
                _listWords.Add("float");
                _listWords.Add("double");
                _listWords.Add("bool");
                _listWords.Add("char");
                _listWords.Add("string");
            }
            if (type == TypeServiceWords.SystemSimbols)
            {
                _listWords.Add("+");
                _listWords.Add("-");
                _listWords.Add("*");
                _listWords.Add("/");
                _listWords.Add("(");
                _listWords.Add(")");
                _listWords.Add("&");
                _listWords.Add("|");
                _listWords.Add("=");
                _listWords.Add(",");
                _listWords.Add("{");
                _listWords.Add("}");
                _listWords.Add("^");
                _listWords.Add(";");
            }
            if (type == TypeServiceWords.AllWords)
            {
                _listWords.Add("int");
                _listWords.Add("float");
                _listWords.Add("double");
                _listWords.Add("bool");
                _listWords.Add("void");
                _listWords.Add("this");
                _listWords.Add("if");
                _listWords.Add("while");
                _listWords.Add("for");
                _listWords.Add("foreach");
                _listWords.Add("public");
                _listWords.Add("protected");
                _listWords.Add("private");
                _listWords.Add("class");
                _listWords.Add("struct");
                _listWords.Add("string");
                _listWords.Add("char");
            }

        }

        public void Add(string word)
        {
            _listWords.Add(word);
        }

        public bool Exists(string word)
        {
            return _listWords.Contains(word);
        }

        public void Remove(string word)
        {
            _listWords.Remove(word);
        }

        public string this[int i]
        {
            get { return _listWords[i]; }
            set { _listWords[i] = value; }
        }

        public int Count()
        {
            return _listWords.Count;
        }
    }
}
