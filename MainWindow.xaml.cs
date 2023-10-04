using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;
using static Graph_2_lab.Models.Buttons;
using static Graph_2_lab.Models.Drawing;

namespace Graph_2_lab;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow
{
    protected static readonly List<Point> Points = new();
    protected static List<Point> TempPoints = new();
    protected static Point SelectedDot = new(-1, -1);

    protected static Line SelectedLine = new Line
    {
        X1 = -1,
        Y1 = -1,
        X2 = -1,
        Y2 = -1
    };

    public MainWindow()
    {
        InitializeComponent();
        MessageBox.Show("Выполнил: Кузьмин Дмитрий\nВариант: 11\nТема: Афинные Преобразования",
            "Лабораторная работа №2");
    }

    #region CANVAS
    private void canvas_Loaded(object sender, RoutedEventArgs e)
    {
        StartDraw(Canvas, Canvas2);
    }
    private void canvas_Loaded_2(object sender, RoutedEventArgs e)
    {
        StartDraw(Canvas, Canvas2);
    }
    private void canvasPolygon_Loaded(object sender, RoutedEventArgs e)
    {

    }
    private void canvasPolygon_Loaded_2(object sender, RoutedEventArgs e)
    {

    }
    #endregion

    private void Canvas_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        MouseLbd(e, CBox, CanvasPolygon, Lxy, LListCord);
    }
    private void BClear_Click(object sender, RoutedEventArgs e)
    {
        Clear(CanvasPolygon, Canvas2Polygon, CBox, LMove, TbMove, LScaling, TbScaling, LReflection, Lxy, LRotation,
            TbRotation, LListCord, LListCord2);
    }
    private void BExecute_Click(object sender, RoutedEventArgs e)
    {
        Execute(CBox, Canvas2Polygon, TbMove, TbScaling, TbRotation, LListCord2);
    }

    #region COMBO BOX

    private void CBItem_Move_Selected(object sender, RoutedEventArgs e)
    {
        LMove.Visibility = Visibility.Visible;
        TbMove.Visibility = Visibility.Visible;
        LScaling.Visibility = Visibility.Hidden;
        TbScaling.Visibility = Visibility.Hidden;
        LReflection.Visibility = Visibility.Hidden;
        Lxy.Visibility = Visibility.Hidden;
        LRotation.Visibility = Visibility.Hidden;
        TbRotation.Visibility = Visibility.Hidden;
    }

    private void CBItem_Scaling_Selected(object sender, RoutedEventArgs e)
    {
        LMove.Visibility = Visibility.Hidden;
        TbMove.Visibility = Visibility.Hidden;
        LScaling.Visibility = Visibility.Visible;
        TbScaling.Visibility = Visibility.Visible;
        LReflection.Visibility = Visibility.Hidden;
        Lxy.Visibility = Visibility.Visible;
        Lxy.Content = "Координаты выбранной стороны: a:NULL b:NULL";
        LRotation.Visibility = Visibility.Hidden;
        TbRotation.Visibility = Visibility.Hidden;
    }

    private void CBItem_Reflection_Selected(object sender, RoutedEventArgs e)
    {
        LMove.Visibility = Visibility.Hidden;
        TbMove.Visibility = Visibility.Hidden;
        LScaling.Visibility = Visibility.Hidden;
        TbScaling.Visibility = Visibility.Hidden;
        LReflection.Visibility = Visibility.Visible;
        Lxy.Visibility = Visibility.Visible;
        Lxy.Content = "Координаты точки: NULL";
        LRotation.Visibility = Visibility.Hidden;
        TbRotation.Visibility = Visibility.Hidden;
    }

    private void CBItem_Rotation_Selected(object sender, RoutedEventArgs e)
    {
        LMove.Visibility = Visibility.Hidden;
        TbMove.Visibility = Visibility.Hidden;
        LScaling.Visibility = Visibility.Hidden;
        TbScaling.Visibility = Visibility.Hidden;
        LReflection.Visibility = Visibility.Hidden;
        Lxy.Visibility = Visibility.Visible;
        Lxy.Content = "Координаты точки: NULL";
        LRotation.Visibility = Visibility.Visible;
        TbRotation.Visibility = Visibility.Visible;
    }

    #endregion
}