using System;
using System.Collections.Generic;
using MyDataBase.Models.SemanticModule.Errors;
using MyDataBase.Models.SemanticModule.LogicalBlocks;

namespace MyDataBase.Models.SemanticModule
{
    public class TreeSlider
    {
        private Block _head;
        private Block _slider;

        private static string preparationProcessing(string text)
        {
            string processedText = text.Trim().Replace("/r/n", string.Empty).Replace("/t", string.Empty);
            string supString = processedText;
            processedText = processedText.Replace("  ", " ");
            while (supString.Equals(processedText) == false)
                processedText = processedText.Replace("  ", " ");
            return processedText;
        }

        public Block GetHeadThisLevel()
        {
            return _head;
        }

        public Block GetThisBlock()
        {
            return _slider;
        }

        public TreeSlider(Block head)
        {
            _head = head;
            _slider = head;
        }

        public string GetsText()
        {
            return _slider.Text;
        }

        public TreeSlider PreviousThisLevel()
        {
            if (_slider.Prev != null)
                _slider = _slider.Prev;
            return this;
        }

        public TreeSlider NextThisLevel()
        {
            if (_slider.Next != null)
                _slider = _slider.Next;
            return this;
        }

        public TreeSlider GoDownLevel()
        {
            if (_slider.LevelBelow != null)
                _slider = _slider.LevelBelow;
            return this;
        }

        public TreeSlider GoUpLevel()
        {
            if (_slider.LevelAbove != null)
                _slider = _slider.LevelAbove;
            return this;
        }

        public bool ExitLevelBelow()
        {
            if (_slider.LevelBelow == null)
                return false;
            return true;
        }

        public bool ExitLevelAbove()
        {
            if (_slider.LevelAbove == null)
                return false;
            return true;
        }

        public bool ExitNextThisLevel()
        {
            if (_slider.Next != null)
                return true;
            return false;
        }

        public bool ExitPrevThisLevel()
        {
            if (_slider.Prev != null)
                return true;
            return false;
        }

        public void AddToLevelBelow(string text, List<int> characterIndexes, int startIndex)
        {
            if (_head.Text == null)
                throw new MissingTitleException("Missing Title");
            else
            {
                _slider.LevelBelow=new Block(null,null,null,null,_slider,startIndex);
                if (text != "")
                {
                    TreeSlider _splitingSlider = new TreeSlider(_slider.LevelBelow);
                    SemanticTree.SplitBlocksThisLevel(_splitingSlider, text, characterIndexes, startIndex);
                }
                else _slider.LevelBelow.Text = "";
            }
        }

        public void AddToThisLevel(string text, int startIndex, bool blockEndsWithSemicolon)
        {
            if (_head.Text == null)
            {
                TypeLogicalBlock type1 = IdentificationBlockType(text);
                switch (type1)
                {
                    case TypeLogicalBlock.DeclaringVars:
                    {
                        _head=new DeclaringVarsBlock(text,null,null,null,_head.LevelAbove,startIndex,blockEndsWithSemicolon);
                        if (_head.LevelAbove != null)
                            _head.LevelAbove.LevelBelow = _head;
                        _slider = _head;
                        break;
                    }
                    default:
                    {
                        _head.Text = text;
                        _head.StartIndex = startIndex;
                        _head.LastIndex = startIndex + text.Length - 1;
                        _head.BlockEndsWithSemicolon = blockEndsWithSemicolon;
                        break;
                    }
                }
            }
            else
            {
                TypeLogicalBlock type2 = IdentificationBlockType(text);
                switch (type2)
                {
                    case TypeLogicalBlock.DeclaringVars:
                    {
                        _slider.Next = new DeclaringVarsBlock(text, null, _slider, null, null, startIndex,
                            blockEndsWithSemicolon);
                        break;
                    }
                    default:
                    {
                        _slider.Next = new Block(text, null, _slider, null, null, startIndex, blockEndsWithSemicolon);
                        break;
                    }
                }
            }
        }

        public static TypeLogicalBlock IdentificationBlockType(string text)
        {
            string preparationText = preparationProcessing(text);
            int firstSpace = preparationText.IndexOf(" ");
            if(firstSpace==0||firstSpace==-1)
                return TypeLogicalBlock.StandardBlock;
            ServiceWords serviceTypeVar = new ServiceWords(TypeServiceWords.TypeVar);
            string firstWord = preparationText.Substring(0, firstSpace);
            if (serviceTypeVar.Exists(firstWord))
                return TypeLogicalBlock.DeclaringVars;
            return TypeLogicalBlock.StandardBlock;
        }
    }
}
