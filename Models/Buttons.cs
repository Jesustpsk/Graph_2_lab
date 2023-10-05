using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using static Graph_2_lab.Models.Auxiliary_Functions_Transform;
using static Graph_2_lab.Models.Drawing;
using static Graph_2_lab.Models.Transformations;
using static Graph_2_lab.Models.AMatrix;

namespace Graph_2_lab.Models;

public abstract class Buttons : MainWindow
{
    public static void MouseLbd(MouseButtonEventArgs e, ComboBox cbox, Canvas canvas, Label xy, TextBox listcord)
    {
        switch (cbox.SelectedIndex)
        {
            case -1:
            {
                listcord.Visibility = Visibility.Visible;
                AddCord(e, listcord, canvas);
                var clickPoint = e.GetPosition(canvas);
                Points.Add(clickPoint);
                DrawPolygon(canvas);
                break;
            }
            case 1:
            {
                TakeLine(e.GetPosition(canvas));
                xy.Content =
                    $"Координаты выбранной стороны: a:{(int)SelectedLine.X1 + "; " + (int)SelectedLine.Y1} " +
                    $"b:{(int)SelectedLine.X2 + "; " + (int)SelectedLine.Y2}";
                break;
            }
            case 2:
            case 3:
            {
                SelectedDot = e.GetPosition(canvas);
                xy.Content = $"Координаты точки: {(int)TakeDot(SelectedDot).X + "; " + (int)TakeDot(SelectedDot).Y}";
                break;
            }
        }
    }

    private static void AddCord(MouseButtonEventArgs e, TextBox listcord, Canvas canvas)
    {
        listcord.Text += "(" + e.GetPosition(canvas) + "), ";
    }

    private static void GiveCord(TextBox listcord, bool temp) 
    {
        if (temp)
        {
            foreach (var tp in TempPoints)
            {
                listcord.Text += "(" + (int)tp.X + ";" + (int)tp.Y + "), ";
            }
        }
        else
        {
            foreach (var p in Points)
            {
                listcord.Text += "(" + (int)p.X + ";" + (int)p.Y + "), ";
            }
        }
    }
    public static void Clear(Canvas canvas1, Canvas canvas2, ComboBox cbox, Label lmove, TextBox tbmove, TextBlock lscaling, 
        TextBox tbscaling, Label lref, Label xy, TextBlock lrot, TextBox tbrot, TextBox listcord, TextBox listcord2, 
        Button applyMain, List<TextBox> lbox, Button apply)
    {
        Points.Clear();
        canvas1.Children.Clear();
        canvas2.Children.Clear();
        cbox.SelectedIndex = -1;

        lmove.Visibility = Visibility.Hidden;
        tbmove.Visibility = Visibility.Hidden;
        lscaling.Visibility = Visibility.Hidden;
        tbscaling.Visibility = Visibility.Hidden;
        lref.Visibility = Visibility.Hidden;
        xy.Visibility = Visibility.Hidden;
        lrot.Visibility = Visibility.Hidden;
        tbrot.Visibility = Visibility.Hidden;
        xy.Content = "";
        listcord.Visibility = Visibility.Hidden;
        listcord.Text = "Координаты вершин: ";
        listcord2.Visibility = Visibility.Hidden;
        listcord2.Text = "Координаты вершин: ";
        applyMain.Visibility = Visibility.Hidden;
        foreach (var l in lbox)
        {
            l.Text = "";
            l.Visibility = Visibility.Hidden;
        }

        apply.Visibility = Visibility.Hidden;
    }

    public static void Execute(ComboBox cbox, Canvas canvas, TextBox tbmove, TextBox tbscaling, TextBox tbrot, 
        TextBox listcord, Button applyMain, List<TextBox> lbox, Button apply)
    {
        if (Points.Count == 0) return;
        TempPoints = Points;
        listcord.Text = "Координаты вершин: ";
        listcord.Visibility = Visibility.Visible;
        applyMain.Visibility = Visibility.Visible;
        apply.Visibility = Visibility.Visible;
        foreach (var l in lbox)
        {
            l.Text = "";
            l.Visibility = Visibility.Visible;
        }
        switch (cbox.SelectedIndex)
        {
            case 0:
                canvas.Children.Clear();
                Move(canvas, tbmove, lbox);
                GiveCord(listcord, true);
                break;
            case 1:
                canvas.Children.Clear();
                Scaling(canvas, SelectedLine, tbscaling, lbox);
                GiveCord(listcord, true);
                break;
            case 2:
                canvas.Children.Clear();
                Reflection(canvas, SelectedDot, lbox);
                GiveCord(listcord, true);
                break;
            case 3:
                canvas.Children.Clear();
                Rotation(canvas, SelectedDot, tbrot, lbox);
                GiveCord(listcord, true);
                break;
        }
    }

    private static Matrix GetMatrix(List<TextBox> lbox)
    {
        var lmatr = new List<String>()
        {
            lbox[0].Text, lbox[1].Text, lbox[4].Text, lbox[2].Text, lbox[3].Text, lbox[5].Text
        };
        var smatr = String.Join(",", lmatr);
        var matrix = Matrix.Parse(smatr);
        return matrix;
    }
    public static void Apply(Canvas canvas, TextBox listcord)
    {
        
    }
    public static void ApplyForMain(Canvas canvas, List<Point> Points, TextBox listcord)
    {
        var path = ConvertToPath(Points);
        canvas.Children.Add(path);
        GiveCord(listcord, false);
    }
}