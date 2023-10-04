﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

using static Graph_2_lab.Models.Auxiliary_Functions_Transform;
using static Graph_2_lab.Models.Drawing;

namespace Graph_2_lab.Models;

public abstract class Transformations : MainWindow
{
    public static void Move(Canvas canvas, TextBox tbMove)
    {
        Int32.TryParse(tbMove.Text, out int count);
        DrawTempPolygon(canvas, count);
    }

    public static void Scaling(Canvas canvas, Line selectedLine, TextBox scale)
    {
        var replace = scale.Text.Contains('.') ? scale.Text.Replace('.', ',') : scale.Text;
        var dscale = Double.Parse(replace);

        if (dscale == 0) return;
        for (var i = 0; i < TempPoints.Count; i++)
        {
            if (TempPoints[i] != new Point(selectedLine.X1, selectedLine.Y1) &&
                TempPoints[i] != new Point(selectedLine.X2, selectedLine.Y2))
                TempPoints[i] = new Point(TempPoints[i].X * dscale, TempPoints[i].Y * dscale);
            //переделать скейлинг
            // можно сравнить координаты точек и линий разметки
            // и в зависимости от расстояния понять где лежит точка и ее сторона
        }

        DrawTempPolygon(canvas);
    }

    public static void Reflection(Canvas canvas, Point dot)
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
    }

    public static void Rotation(Canvas canvas, Point dot, TextBox textBox)
    {
        var selectedVertex = TakeDot(dot);
        if (selectedVertex is { X: -1, Y: -1 }) return;
        Int32.TryParse(textBox.Text, out int angle);
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
    }
}