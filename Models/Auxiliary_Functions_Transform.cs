using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Shapes;

namespace Graph_2_lab.Models;

public abstract class Auxiliary_Functions_Transform : MainWindow
{
    public static Point TakeDot(Point dot)
    {
        if (dot.X == -1 || dot.Y == -1) return new Point(-1, -1);
        foreach (var t in Points.Where(t
                     => (dot.X - 15 <= t.X && t.X <= dot.X + 15) && (dot.Y - 15 <= t.Y && t.Y <= dot.Y + 15)))
        {
            return t;
        }

        return new Point(-1, -1);
    }

    public static void TakeLine(Point dot)
    {
        if (Points.Count > 1)
        {
            List<Line> lines = new();
            for (var i = 1; i < Points.Count; i++)
            {
                lines.Add(new Line
                {
                    X1 = Points[i - 1].X,
                    Y1 = Points[i - 1].Y,
                    X2 = Points[i].X,
                    Y2 = Points[i].Y
                });
            }

            if (Points.Count > 2)
            {
                var closingLine = new Line
                {
                    X1 = Points[^1].X,
                    Y1 = Points[^1].Y,
                    X2 = Points[0].X,
                    Y2 = Points[0].Y
                };
                lines.Add(closingLine);
            }
            
            var ranges = lines.Select(t => CalcRange(t, dot)).ToList();
            SelectedLine = lines[ranges.IndexOf(ranges.Min())];
        }
        else
        {
            SelectedLine = new Line
            {
                X1 = -1,
                Y1 = -1,
                X2 = -1,
                Y2 = -1
            };
        }
    }

    private static double CalcRange(Line line, Point p)
    {
        Func<double, double, double> range = (x, y) => Math.Sqrt(x * x + y * y);
        Func<Point, double> pointRange = point => range(point.X - p.X, point.Y - p.Y);
        return range(pointRange(new Point(line.X1, line.Y1)), pointRange(new Point(line.X2, line.Y2)));
    }
}