using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyDataBase.Draw
{
    public enum ColorBlock
    {
        StandartBlock_Black = 1,
        DeclaringVarBlock_Red = 2,
    }
    public class Points
    {
        private List<Pair<int,int>> _listPoints;
        private Canvas _panel;
        private Color _color;
        public Points(Canvas panel, ColorBlock color)
        {
            _panel = panel;
            _listPoints = new List<Pair<int,int>>();

            _color = new Color();
            if(color==ColorBlock.StandartBlock_Black)
                _color = Color.FromArgb(255, 0, 0, 0);
            if (color == ColorBlock.DeclaringVarBlock_Red)
                _color = Color.FromArgb(255, 255, 0, 0);
        }

        public void Add(int x, int y)
        {
            _listPoints.Add(new Pair<int,int>(x, y));
            SomeDraw.ConnectThePoints(_listPoints, _panel, _color);
        }
    }
}
