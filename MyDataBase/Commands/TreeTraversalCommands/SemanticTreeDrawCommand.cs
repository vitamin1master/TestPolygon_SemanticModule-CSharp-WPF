using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using MyDataBase.Draw;
using MyDataBase.Models.SemanticModule;
using MyDataBase.Models.SemanticModule.LogicalBlocks;

namespace MyDataBase.Commands.TreeTraversalCommands
{
    class SemanticTreeDrawCommand:ICommand
    {
        private Canvas _panel;

        public SemanticTreeDrawCommand(Canvas panel)
        {
            _panel = panel;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is Block)
            {
                Block block = (parameter as Block);
                Points points = new Points(_panel, ColorBlock.StandartBlock_Black);
                if (block is DeclaringVarsBlock)
                    points = new Points(_panel, ColorBlock.DeclaringVarBlock_Red);
                int leftTopX = 100 * block.LevelNumber + 20;
                int leftTopY = 50 * block.RowNumber + 20;
                points.Add(leftTopX, leftTopY);

                int leftBottomX = 100 * block.LevelNumber + 20;
                int leftBottomY = 50 * block.RowNumber + 40;
                points.Add(leftBottomX, leftBottomY);

                int rightBottomX = 100 * block.LevelNumber + 90;
                int rightBottomY = 50 * block.RowNumber + 40;
                points.Add(rightBottomX, rightBottomY);

                int rightTopX = 100 * block.LevelNumber + 90;
                int rightTopY = 50 * block.RowNumber + 20;
                points.Add(rightTopX, rightTopY);

                points.Add(leftTopX, leftTopY);

                Label label = new Label();
                if (block.Text != null)
                    label.Content = block.Text.Trim();
                else label.Content = "";
                Canvas.SetLeft(label, leftTopX);
                Canvas.SetTop(label, leftTopY);
                _panel.Children.Add(label);

                if (block.LevelAbove != null)
                {
                    points.Add((leftTopX + leftBottomX)/2, (leftTopY + leftBottomY)/2);
                    points.Add((leftTopX + leftBottomX)/2 - 30, (leftTopY + leftBottomY)/2);
                }
                if (block.Prev != null)
                {
                    points.Add((leftTopX + rightTopX) / 2, (leftTopY + rightTopY) / 2);
                    points.Add((leftTopX + rightTopX) / 2, (leftTopY + rightTopY) / 2 - 30);
                }
            }
        }

        public event EventHandler CanExecuteChanged;
    }
}
