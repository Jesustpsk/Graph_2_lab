using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
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
        TempPoints = Points;
        var matrix = TranslateAlongX(count);
        Fillmatrix(lbox, matrix);
        var path = ConvertToPath(ApplyTransformation(TempPoints,matrix, null,null));
        canvas.Children.Add(path);
    }
    
    /*public static void Scaling(Canvas canvas, Line selectedLine, TextBox scale, List<TextBox> lbox)
    {
        var replace = scale.Text.Contains('.') ? scale.Text.Replace('.', ',') : scale.Text;
        var scaleFactor = double.Parse(replace);

        if (scaleFactor == 0) return;
        TempPoints = Points;
        var matrix = ScaleAlongSide(scaleFactor, selectedLine);
        Fillmatrix(lbox, matrix);
        var path = ConvertToPath(ApplyTransformation(TempPoints, matrix, scaleFactor, selectedLine));
        canvas.Children.Add(path);
    }*/
    
    public static void Scaling(Canvas canvas, Line selectedLine, TextBox scale, List<TextBox> lbox)
    {
        var replace = scale.Text.Contains('.') ? scale.Text.Replace('.', ',') : scale.Text;
        var scaleFactor = double.Parse(replace);

        if (scaleFactor == 0) return;
        TempPoints = Points;
        double centerX = 0;
        double centerY = 0;
        foreach (var t in TempPoints)
        {
            centerX += t.X;
            centerY += t.Y;
        }

        centerX /= TempPoints.Count;
        centerY /= TempPoints.Count;
        
        var matrix = ScaleAlongAxis(scaleFactor,new Point(centerX, centerY),new Point(selectedLine.X2 - selectedLine.X1, selectedLine.Y2 - selectedLine.Y1));
        Fillmatrix(lbox, matrix);
        ApplyTransformation(TempPoints, matrix, scaleFactor, selectedLine);
        Move2Center(new Point(centerX, centerY));
        var path = ConvertToPath(TempPoints);
        canvas.Children.Add(path);
    }
    public static void Reflection(Canvas canvas, Point dot, List<TextBox> lbox)
    {
        var selectedVertex = TakeDot(dot);
        if (selectedVertex is { X: -1, Y: -1 }) return;
        TempPoints = Points;
        var matrix = ReflectAboutVertex(dot);
        Fillmatrix(lbox, matrix);
        var path = ConvertToPath(ApplyTransformation(TempPoints,matrix, null, null));
        canvas.Children.Add(path);
    }
    public static void Rotation(Canvas canvas, Point dot, TextBox textBox, List<TextBox> lbox)
    {
        var selectedVertex = TakeDot(dot);
        if (selectedVertex is { X: -1, Y: -1 }) return;
        TryParse(textBox.Text, out var angle);
        TempPoints = Points;
        var matrix = RotateAroundVertex(angle, dot);
        Fillmatrix(lbox, matrix);
        var path = ConvertToPath(ApplyTransformation(TempPoints,matrix,null,null));
        canvas.Children.Add(path);
    }

    public static void Move2Center(Point c1)
    {
        double centerX = 0;
        double centerY = 0;
        foreach (var t in TempPoints)
        {
            centerX += t.X;
            centerY += t.Y;
        }

        centerX /= TempPoints.Count;
        centerY /= TempPoints.Count;
        var xoy = //true x0 > x1 | false x0 < x1
            centerX > c1.X;
        var deltaCX = Math.Abs(centerX - c1.X);
        var deltaCY = Math.Abs(centerY - c1.Y);

        for(var i = 0; i < TempPoints.Count; i++)
        {
            if(xoy)
                TempPoints[i] = new Point(TempPoints[i].X - deltaCX, TempPoints[i].Y + deltaCY);
            else
                TempPoints[i] = new Point(TempPoints[i].X + deltaCX, TempPoints[i].Y - deltaCY);
        }
    }
}