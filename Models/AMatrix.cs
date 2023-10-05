using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
namespace Graph_2_lab.Models;

public abstract class AMatrix : MainWindow
{
    public static Matrix MScale(double scale, Line line)
    {
        Point p1, p2;
        var sideIndex = 0;
        for(var i = 0; i < TempPoints.Count; i++)
        {
            if (new Point(line.X1, line.Y1) != TempPoints[i]) continue;
            p2 = TempPoints[i];
            sideIndex = i;
            break;
        }
        p1 = sideIndex == 0 ? TempPoints[^1] : TempPoints[sideIndex - 1];

        var startPoint = new Point(line.X1, line.Y1);
        var endPoint = new Point(line.X2, line.Y2);

        Point center = new((p1.X + p2.X) / 2, (p1.Y + p2.Y) / 2);

        Matrix scaleMatrix = new();
        scaleMatrix.ScaleAt(scale, scale, center.X, center.Y);

        for (var i = 0; i < TempPoints.Count; i++)
        {
            if (Points[i] == startPoint || Points[i] == endPoint)
            {
                continue;
            }
            TempPoints[i] = scaleMatrix.Transform(TempPoints[i]);
        }

        return scaleMatrix;
    } 
    public static Matrix MRotate(double rotationAngle, Point p)
    {
        Matrix matrix = new();
        matrix.RotateAt(rotationAngle, p.X, p.Y);
        for (var i = 0; i < TempPoints.Count; i++)
        {
            TempPoints[i] = matrix.Transform(TempPoints[i]);
        }

        return matrix;
    } 
    public static Matrix MMove(double translateX, double translateY)
    {
        Matrix matrix = new();
        matrix.Translate(translateX, translateY);
        for (var i = 0; i < TempPoints.Count; i++)
        {
            TempPoints[i] = matrix.Transform(TempPoints[i]);
        }

        return matrix;
    } 
    public static Matrix MReflection(Point p)
    {
        Matrix matrix = new();
        matrix.RotateAt(180, p.X, p.Y);
        for (var i = 0; i < TempPoints.Count; i++)
        {
            TempPoints[i] = matrix.Transform(TempPoints[i]);
        }
        return matrix;
    }

    public static void Fillmatrix(List<TextBox> lbox, Matrix matrix)
    {
        var m = matrix.ToString().Split(';');
        lbox[0].Text = m[0];
        lbox[1].Text = m[1];
        lbox[2].Text = m[4];
        lbox[3].Text = m[2];
        lbox[4].Text = m[3];
        lbox[5].Text = m[5];
    }
}