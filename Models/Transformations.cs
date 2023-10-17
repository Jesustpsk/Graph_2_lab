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
        TempPoints = Points;
        var matrix = TranslateAlongX(count);
        Fillmatrix(lbox, matrix);
        var path = ConvertToPath(ApplyTransformation(TempPoints,matrix));
        canvas.Children.Add(path);
    }
    
    public static void Scaling(Canvas canvas, Line selectedLine, TextBox scale, List<TextBox> lbox)
    {
        var replace = scale.Text.Contains('.') ? scale.Text.Replace('.', ',') : scale.Text;
        var scaleFactor = double.Parse(replace);

        if (scaleFactor == 0) return;
        TempPoints = Points;
        var matrix = ScaleAlongSide(scaleFactor, selectedLine);
        Fillmatrix(lbox, matrix);
        var path = ConvertToPath(ApplyTransformation(TempPoints, matrix, scaleFactor, selectedLine));
        canvas.Children.Add(path);
    }
    public static void Reflection(Canvas canvas, Point dot, List<TextBox> lbox)
    {
        var selectedVertex = TakeDot(dot);
        if (selectedVertex is { X: -1, Y: -1 }) return;
        TempPoints = Points;
        var matrix = ReflectAboutVertex(dot);
        Fillmatrix(lbox, matrix);
        var path = ConvertToPath(ApplyTransformation(TempPoints,matrix));
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
        var path = ConvertToPath(ApplyTransformation(TempPoints,matrix));
        canvas.Children.Add(path);
    }
}