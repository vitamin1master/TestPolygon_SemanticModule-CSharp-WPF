using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MyDataBase.Draw
{
    public class SomeDraw
    {
        public static void DrawLine(Canvas panel, Color color, int x1, int y1, int x2, int y2)
        {
            Line line = new Line
            {
                X1 = x1,
                X2 = x2,
                Y1 = y1,
                Y2 = y2,
                Stroke = new SolidColorBrush(color)
            };
            panel.Children.Add(line);
        }

        public static void ConnectThePoints(List<Pair<int,int>> listPoints, Canvas panel, Color color)
        {
            for (int i = 0; i < listPoints.Count - 1; i++)
            {
                DrawLine(panel, color, (int)listPoints[i].First, (int)listPoints[i].Second, (int)listPoints[i + 1].First,
                    (int)listPoints[i + 1].Second);
            }
        }
    }
}
