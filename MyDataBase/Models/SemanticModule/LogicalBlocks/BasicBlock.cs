using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDataBase.Models.SemanticModule.LogicalBlocks
{
    public class BasicBlock
    {
        public string Text;
        public Block LogicalBlock;

        public BasicBlock(string text=null, Block logicalBlock=null)
        {
            Text = text;
            LogicalBlock = logicalBlock;
        }
    }
}
