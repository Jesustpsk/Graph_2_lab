using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using static System.Int32;
using static Graph_2_lab.Models.Auxiliary_Functions_Transform;
using static Graph_2_lab.Models.Drawing;
using static Graph_2_lab.Models.AMatrix;
namespace Graph_2_lab.Models;

public abstract class Transformations : MainWindow
{
    public static void Move(Canvas canvas, TextBox tbMove,List<TextBox> lbox)
    {
        TryParse(tbMove.Text, out var count);
        //DrawTempPolygon(canvas, count);
        TempPoints = Points;
        Fillmatrix(lbox, MMove(count, 0));
        var path = ConvertToPath(TempPoints);
        canvas.Children.Add(path);
    }
    
    /*public static void Scaling(Canvas canvas, Line selectedLine, TextBox scale)
    {
        var replace = scale.Text.Contains('.') ? scale.Text.Replace('.', ',') : scale.Text;
        var scaleFactor = double.Parse(replace);

        if (scaleFactor == 0) return;
        var startPoint = new Point(selectedLine.X1, selectedLine.Y1);
        var endPoint = new Point(selectedLine.X2, selectedLine.Y2);

        for (var i = 0; i < Points.Count; i++)
        {
            if (Points[i] == startPoint || Points[i] == endPoint)
            {
                continue;
            }
            var scaledPoint = new Point(
                startPoint.X + (Points[i].X - startPoint.X) * scaleFactor,
                startPoint.Y + (Points[i].Y - startPoint.Y) * scaleFactor
            );
            TempPoints[i] = scaledPoint;
        }
        DrawTempPolygon(canvas);
    }*/
    public static void Scaling(Canvas canvas, Line selectedLine, TextBox scale, List<TextBox> lbox)
    {
        var replace = scale.Text.Contains('.') ? scale.Text.Replace('.', ',') : scale.Text;
        var scaleFactor = double.Parse(replace);

        if (scaleFactor == 0) return;
        TempPoints = Points;
        Fillmatrix(lbox, MScale(scaleFactor, selectedLine));
        var path = ConvertToPath(TempPoints);
        canvas.Children.Add(path);
    }
    /*public static void Reflection(Canvas canvas, Point dot)
    {
        var selectedVertex = TakeDot(dot);
        if (selectedVertex is { X: -1, Y: -1 }) return;
        for (var i = 0; i < TempPoints.Count; i++)
        {
            var originalPoint = TempPoints[i];

            // Разница между выбранной вершиной и текущей точкой
            var deltaX = selectedVertex.X - originalPoint.X;
            var deltaY = selectedVertex.Y - originalPoint.Y;

            // Отражаем текущую точку относительно выбранной вершины
            var reflectedPoint = new Point(selectedVertex.X + deltaX, selectedVertex.Y + deltaY);
            TempPoints[i] = reflectedPoint;
        }

        DrawTempPolygon(canvas);
    }*/
    public static void Reflection(Canvas canvas, Point dot, List<TextBox> lbox)
    {
        var selectedVertex = TakeDot(dot);
        if (selectedVertex is { X: -1, Y: -1 }) return;
        TempPoints = Points;
        Fillmatrix(lbox, MReflection(dot));
        var path = ConvertToPath(TempPoints);
        canvas.Children.Add(path);
    }
    /*public static void Rotation(Canvas canvas, Point dot, TextBox textBox)
    {
        var selectedVertex = TakeDot(dot);
        if (selectedVertex is { X: -1, Y: -1 }) return;
        TryParse(textBox.Text, out var angle);
        var angleRadian = angle * Math.PI / 180;
        for (var j = 0; j < TempPoints.Count; j++)
        {
            var x = ((TempPoints[j].X - selectedVertex.X) * Math.Cos(angleRadian) -
                (TempPoints[j].Y - selectedVertex.Y) * Math.Sin(angleRadian) + selectedVertex.X);
            var y = ((TempPoints[j].X - selectedVertex.X) * Math.Sin(angleRadian) +
                     (TempPoints[j].Y - selectedVertex.Y) * Math.Cos(angleRadian) + selectedVertex.Y);
            TempPoints[j] = new Point(x, y);
        }

        DrawTempPolygon(canvas);
    }*/
    public static void Rotation(Canvas canvas, Point dot, TextBox textBox, List<TextBox> lbox)
    {
        var selectedVertex = TakeDot(dot);
        if (selectedVertex is { X: -1, Y: -1 }) return;
        TryParse(textBox.Text, out var angle);
        TempPoints = Points;
        Fillmatrix(lbox, MRotate(angle, dot));
        var path = ConvertToPath(TempPoints);
        canvas.Children.Add(path);
        
    }
}