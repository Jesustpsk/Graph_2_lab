using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static Graph_2_lab.Models.Auxiliary_Functions_Transform;
using static Graph_2_lab.Models.Drawing;
using static Graph_2_lab.Models.Transformations;
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

    private static void GiveCord(TextBox listcord)
    {
        foreach (var tp in TempPoints)
        {
            listcord.Text += "(" + (int)tp.X + ";" + (int)tp.Y + "), ";
        }
    }
    public static void Clear(Canvas canvas1, Canvas canvas2, ComboBox cbox, Label lmove, TextBox tbmove, TextBlock lscaling, TextBox tbscaling, Label lref, Label xy, TextBlock lrot, TextBox tbrot, TextBox listcord, TextBox listcord2)
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
    }

    public static void Execute(ComboBox cbox, Canvas canvas, TextBox tbmove, TextBox tbscaling, TextBox tbrot, TextBox listcord)
    {
        if (Points.Count == 0) return;
        TempPoints = Points;
        listcord.Text = "Координаты вершин: ";
        listcord.Visibility = Visibility.Visible;
        switch (cbox.SelectedIndex)
        {
            case 0:
                Move(canvas, tbmove);
                GiveCord(listcord);
                break;
            case 1:
                Scaling(canvas, SelectedLine, tbscaling);
                GiveCord(listcord);
                break;
            case 2:
                Reflection(canvas, SelectedDot);
                GiveCord(listcord);
                break;
            case 3:
                Rotation(canvas, SelectedDot, tbrot);
                GiveCord(listcord);
                break;
        }
    }
}