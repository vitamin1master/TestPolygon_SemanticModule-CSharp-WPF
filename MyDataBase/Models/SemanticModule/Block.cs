using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDataBase.Models.SemanticModule.LogicalBlocks;

namespace MyDataBase.Models.SemanticModule
{
    public class Block
    {
        public string Text;
        public Block Next;
        public Block Prev;
        public Block LevelBelow;
        public Block LevelAbove;
        public int StartIndex;
        public int LastIndex;
        public bool BlockEndsWithSemicolon;
        public int LevelNumber;
        public TypeLogicalBlock TypeThisBlock;
        public int RowNumber;

        public Block(string text = null, Block next = null, Block pred = null, Block levelBelow = null,
            Block levelAbove = null, int startIndex = 0, bool blockEndsWithSemicolon = false)
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
            //Level Number init
            if (levelAbove != null)
                LevelNumber = levelAbove.LevelNumber + 1;
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
            TypeThisBlock = TypeLogicalBlock.StandardBlock;
        }
    }
}
