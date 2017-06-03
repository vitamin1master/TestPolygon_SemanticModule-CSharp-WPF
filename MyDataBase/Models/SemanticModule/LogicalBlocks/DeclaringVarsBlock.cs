using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDataBase.Models.SemanticModule.Errors;

namespace MyDataBase.Models.SemanticModule.LogicalBlocks
{
    public class NumberRowsIsIncorrect : Exception
    {
        public string Message { get; set; }

        public NumberRowsIsIncorrect(string text)
        {
            Message = text;
        }
    }

    public class BasicDeclaringVarsBlock : BasicBlock
    {
        public Pair<string, string>[] NamesAndValues;

        public BasicDeclaringVarsBlock(string[] names, string[] values)
        {
            if (names != null && values != null)
            {
                int numNames = names.Length;
                int numValues = values.Length;
                if (numNames != numValues || numNames == 0)
                    throw new NumberRowsIsIncorrect("Different numbers names and values");
                NamesAndValues = new Pair<string, string>[numNames];
                int i = 0;
                while (i < numNames)
                    NamesAndValues[i] = new Pair<string, string>(names[i], values[i]);
            }
            else throw new NumberRowsIsIncorrect("Names or values are null");
        }
    }

    class DeclaringVarsBlock : Block
    {
        public string TypeVars;
        //public BasicDeclaringVarsBlock TypeVarsDeclared;
        public List<Pair<string, string>> NamesAndValues;
        private string preparationProcessing(string text)
        {
            string processedText = text.Trim().Replace("/r/n", string.Empty).Replace("/t", string.Empty);
            string supString = processedText;
            processedText = processedText.Replace("  ", " ");
            while (supString.Equals(processedText) == false)
                processedText = processedText.Replace("  ", " ");
            return processedText;
        }

        private void splitNameAndValue(string text, List<Pair<string, string>> nameAndValues, int iSTART)
        {
            int i = iSTART;
            int iStart = i;
            string name = null, value;
            while (i < text.Length)
            {
                if (text[i] == ',' || text[i] == '=')
                {
                    if (name == null)
                    {
                        name = text.Substring(iStart, i-iStart).Trim();
                        if (text[i] == ',')
                        {
                            //не забудь проверить на наличие специальных символов
                            NamesAndValues.Add(new Pair<string, string>(name, string.Empty));
                            name = null;
                        }
                    }
                    else
                    {
                        value = text.Substring(iStart, i - iStart).Trim();
                        NamesAndValues.Add(new Pair<string, string>(name, value));
                        name = null;
                    }
                    iStart = i + 1;
                }
                i++;
            }
            if (i == text.Length && iStart!=i)
            {
                if (name == null)
                {
                    name = text.Substring(iStart, i - iStart).Trim();
                    NamesAndValues.Add(new Pair<string, string>(name, string.Empty));
                }
                else
                {
                    value = text.Substring(iStart, i - iStart).Trim();
                    NamesAndValues.Add(new Pair<string, string>(name, value));
                }
            }
        }


        public DeclaringVarsBlock(string text, Block next = null, Block pred = null, Block levelBelow = null,
            Block levelAbove = null, int startIndex = 0, bool blockEndsWithSemicolon = false, int levelNumber = 0)
        {
            Text = text;
            Next = next;
            Prev = pred;
            LevelBelow = levelBelow;
            LevelAbove = levelAbove;
            StartIndex = startIndex;
            if (Text != null)
                LastIndex = Text.Length + startIndex - 1;
            else LastIndex = startIndex;
            BlockEndsWithSemicolon = blockEndsWithSemicolon;
            if (levelAbove != null)
                LevelNumber = levelAbove.LevelNumber+1;
            else
            {
                if (pred == null)
                    LevelNumber = 0;
                else
                    LevelNumber = pred.LevelNumber;
            }
            //RowNumber init
            if (pred == null && levelAbove == null)
                RowNumber = 0;
            else
            {
                if (levelAbove != null)
                    RowNumber = levelAbove.RowNumber;
                if (pred != null)
                    RowNumber = pred.RowNumber + 1;
            }
            TypeThisBlock=TypeLogicalBlock.DeclaringVars;
            NamesAndValues = new List<Pair<string, string>>();

            string processedText = preparationProcessing(text);
            int firstSpace = processedText.IndexOf(" ");
            if (firstSpace == 0 || firstSpace == -1)
                throw new UnsuitableTypeBlockException("Text have no words");
            ServiceWords serviceTypeVar = new ServiceWords(TypeServiceWords.TypeVar);
            string firstWord = processedText.Substring(0, firstSpace);
            if (serviceTypeVar.Exists(firstWord))
                TypeVars = firstWord;
            splitNameAndValue(processedText, NamesAndValues, firstSpace + 1);
        }
    }
}
