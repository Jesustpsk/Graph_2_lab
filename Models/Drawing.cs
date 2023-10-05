using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
namespace Graph_2_lab.Models;

public abstract class Drawing : MainWindow
{
    private static void DrawAxesC1(Canvas canvas)
    {
        var centerX = (int)canvas.ActualWidth / 2;
        var centerY = (int)canvas.ActualHeight / 2;
        var radius = Math.Min(centerX, centerY) - 10;

        #region VERTICALAXE

        var verticalAxis = new Line
        {
            Stroke = Brushes.Black,
            X1 = centerX,
            Y1 = centerY - radius,
            X2 = centerX,
            Y2 = centerY + radius,
            StrokeThickness = 1,
        };
        canvas.Children.Add(verticalAxis);

        var verticalArrowLeft = new Line
        {
            Stroke = Brushes.Black,
            X1 = centerX,
            Y1 = 10,
            X2 = centerX - 5,
            Y2 = 20,
            StrokeThickness = 1
        };
        canvas.Children.Add(verticalArrowLeft);

        var verticalArrowRight = new Line
        {
            Stroke = Brushes.Black,
            X1 = centerX,
            Y1 = 10,
            X2 = centerX + 5,
            Y2 = 20,
            StrokeThickness = 1
        };
        canvas.Children.Add(verticalArrowRight);

        #endregion

        #region HORIZONTALAXE

        var horizontalAxis = new Line
        {
            Stroke = Brushes.Black,
            X1 = centerX - radius,
            Y1 = centerY,
            X2 = centerX + radius,
            Y2 = centerY,
            StrokeThickness = 1
        };
        canvas.Children.Add(horizontalAxis);

        var horizontalArrowLeft = new Line
        {
            Stroke = Brushes.Black,
            X1 = centerX * 2 - 10,
            Y1 = centerY,
            X2 = centerX * 2 - 20,
            Y2 = centerY - 5,
            StrokeThickness = 1
        };
        canvas.Children.Add(horizontalArrowLeft);

        var horizontalArrowRight = new Line
        {
            Stroke = Brushes.Black,
            X1 = centerX * 2 - 10,
            Y1 = centerY,
            X2 = centerX * 2 - 20,
            Y2 = centerY + 5,
            StrokeThickness = 1
        };
        canvas.Children.Add(horizontalArrowRight);

        #endregion
    }
    private static void DrawAxesC2(Canvas canvas)
    {
        var centerX = (int)canvas.ActualWidth / 2;
        var centerY = (int)canvas.ActualHeight / 2;
        var radius = Math.Min(centerX, centerY) - 10;

        #region VERTICALAXE

        var verticalAxis = new Line
        {
            Stroke = Brushes.Black,
            X1 = centerX,
            Y1 = centerY - radius,
            X2 = centerX,
            Y2 = centerY + radius,
            StrokeThickness = 1
        };
        canvas.Children.Add(verticalAxis);

        var verticalArrowLeft = new Line
        {
            Stroke = Brushes.Black,
            X1 = centerX,
            Y1 = 10,
            X2 = centerX - 5,
            Y2 = 20,
            StrokeThickness = 1
        };
        canvas.Children.Add(verticalArrowLeft);

        var verticalArrowRight = new Line
        {
            Stroke = Brushes.Black,
            X1 = centerX,
            Y1 = 10,
            X2 = centerX + 5,
            Y2 = 20,
            StrokeThickness = 1
        };
        canvas.Children.Add(verticalArrowRight);

        #endregion

        #region HORIZONTALAXE

        var horizontalAxis = new Line
        {
            Stroke = Brushes.Black,
            X1 = centerX - radius,
            Y1 = centerY,
            X2 = centerX + radius,
            Y2 = centerY,
            StrokeThickness = 1
        };
        canvas.Children.Add(horizontalAxis);

        var horizontalArrowLeft = new Line
        {
            Stroke = Brushes.Black,
            X1 = centerX * 2 - 10,
            Y1 = centerY,
            X2 = centerX * 2 - 20,
            Y2 = centerY - 5,
            StrokeThickness = 1
        };
        canvas.Children.Add(horizontalArrowLeft);

        var horizontalArrowRight = new Line
        {
            Stroke = Brushes.Black,
            X1 = centerX * 2 - 10,
            Y1 = centerY,
            X2 = centerX * 2 - 20,
            Y2 = centerY + 5,
            StrokeThickness = 1
        };
        canvas.Children.Add(horizontalArrowRight);

        #endregion
    }
    private static void DrawGridC1(Canvas canvas)
    {
        #region VERTICALGRID

        for (var i = 10; i < canvas.Width; i += 10)
        {
            var line = new Line()
            {
                Stroke = Brushes.Black,
                X1 = i,
                Y1 = 10,
                X2 = i,
                Y2 = canvas.Height - 10,
                StrokeThickness = 0.2,
                StrokeDashArray = new DoubleCollection() { 4, 4 }
            };
            canvas.Children.Add(line);
        }

        #endregion


        #region HORIZONTALGRID

        for (var i = 10; i < canvas.Height; i += 10)
        {
            var line = new Line()
            {
                Stroke = Brushes.Black,
                X1 = 10,
                Y1 = i,
                X2 = canvas.Width - 10,
                Y2 = i,
                StrokeThickness = 0.2,
                StrokeDashArray = new DoubleCollection() { 4, 4 }
            };
            canvas.Children.Add(line);
        }

        #endregion
    }
    private static void DrawGridC2(Canvas canvas)
    {
        #region VERTICALGRID

        for (var i = 10; i < canvas.Width; i += 10)
        {
            var line = new Line()
            {
                Stroke = Brushes.Black,
                X1 = i,
                Y1 = 10,
                X2 = i,
                Y2 = canvas.Height - 10,
                StrokeThickness = 0.2,
                StrokeDashArray = new DoubleCollection() { 4, 4 }
            };
            canvas.Children.Add(line);
        }

        #endregion


        #region HORIZONTALGRID

        for (var i = 10; i < canvas.Height; i += 10)
        {
            var line = new Line()
            {
                Stroke = Brushes.Black,
                X1 = 10,
                Y1 = i,
                X2 = canvas.Width - 10,
                Y2 = i,
                StrokeThickness = 0.2,
                StrokeDashArray = new DoubleCollection() { 4, 4 }
            };
            canvas.Children.Add(line);
        }

        #endregion
    }
    private static void DrawRuleC1(Canvas canvas)
    {
        var center = new Point(canvas.Width / 2, canvas.Height / 2);

        #region VERTICALRULE

        for (var i = 20; i < canvas.Width - 20; i += 10)
        {
            var line = new Line()
            {
                Stroke = Brushes.Black,
                X1 = i,
                Y1 = center.Y - 5,
                X2 = i,
                Y2 = center.Y + 5,
                StrokeThickness = 0.5
            };
            canvas.Children.Add(line);
        }

        #endregion

        #region HORIZONTALRULE

        for (var i = 30; i < canvas.Height - 10; i += 10)
        {
            var line = new Line()
            {
                Stroke = Brushes.Black,
                X1 = center.X - 5,
                Y1 = i,
                X2 = center.X + 5,
                Y2 = i,
                StrokeThickness = 0.5
            };
            canvas.Children.Add(line);
        }

        #endregion
    }
    private static void DrawRuleC2(Canvas canvas)
    {
        var center = new Point(canvas.Width / 2, canvas.Height / 2);

        #region VERTICALRULE

        for (var i = 20; i < canvas.Width - 20; i += 10)
        {
            var line = new Line()
            {
                Stroke = Brushes.Black,
                X1 = i,
                Y1 = center.Y - 5,
                X2 = i,
                Y2 = center.Y + 5,
                StrokeThickness = 0.5
            };
            canvas.Children.Add(line);
        }

        #endregion

        #region HORIZONTALRULE

        for (var i = 30; i < canvas.Height - 10; i += 10)
        {
            var line = new Line()
            {
                Stroke = Brushes.Black,
                X1 = center.X - 5,
                Y1 = i,
                X2 = center.X + 5,
                Y2 = i,
                StrokeThickness = 0.5
            };
            canvas.Children.Add(line);
        }

        #endregion
    }

    public static void StartDraw(Canvas canvas1, Canvas canvas2)
    {
        DrawAxesC1(canvas1);
        DrawAxesC2(canvas2);
        DrawGridC1(canvas1);
        DrawGridC2(canvas2);
        DrawRuleC1(canvas1);
        DrawRuleC2(canvas2);
    }

    public static void DrawPolygon(Canvas canvas)
    {
        canvas.Children.Clear(); // Очищаем канвас

        if (Points.Count > 1)
        {
            for (var i = 1; i < Points.Count; i++)
            {
                var line = new Line
                {
                    Stroke = Brushes.Red,
                    X1 = Points[i - 1].X,
                    Y1 = Points[i - 1].Y,
                    X2 = Points[i].X,
                    Y2 = Points[i].Y
                };
                canvas.Children.Add(line);
            }

            if (Points.Count > 2)
            {
                var closingLine = new Line
                {
                    Stroke = Brushes.Red,
                    X1 = Points[^1].X,
                    Y1 = Points[^1].Y,
                    X2 = Points[0].X,
                    Y2 = Points[0].Y
                };
                canvas.Children.Add(closingLine);
            }
        }
    }
    public static void DrawTempPolygon(Canvas canvas)
    {
        canvas.Children.Clear(); // Очищаем канвас

        if (TempPoints.Count > 1)
        {
            for (var i = 1; i < TempPoints.Count; i++)
            {
                var line = new Line
                {
                    Stroke = Brushes.Blue,
                    X1 = TempPoints[i - 1].X,
                    Y1 = TempPoints[i - 1].Y,
                    X2 = TempPoints[i].X,
                    Y2 = TempPoints[i].Y
                };
                canvas.Children.Add(line);
            }

            if (TempPoints.Count > 2)
            {
                var closingLine = new Line
                {
                    Stroke = Brushes.Blue,
                    X1 = TempPoints[^1].X,
                    Y1 = TempPoints[^1].Y,
                    X2 = TempPoints[0].X,
                    Y2 = TempPoints[0].Y
                };
                canvas.Children.Add(closingLine);
            }
        }
    }
    public static void DrawTempPolygon(Canvas canvas, int offsetX)
    {
        canvas.Children.Clear(); // Очищаем канвас

        if (TempPoints.Count > 1)
        {
            for (var i = 1; i < TempPoints.Count; i++)
            {
                var line = new Line
                {
                    Stroke = Brushes.Blue,
                    X1 = TempPoints[i - 1].X + offsetX,
                    Y1 = TempPoints[i - 1].Y,
                    X2 = TempPoints[i].X + offsetX,
                    Y2 = TempPoints[i].Y
                };
                canvas.Children.Add(line);
            }

            if (TempPoints.Count > 2)
            {
                var closingLine = new Line
                {
                    Stroke = Brushes.Blue,
                    X1 = TempPoints[^1].X + offsetX,
                    Y1 = TempPoints[^1].Y,
                    X2 = TempPoints[0].X + offsetX,
                    Y2 = TempPoints[0].Y
                };
                canvas.Children.Add(closingLine);
            }
        }
    }
    

    public static Path ConvertToPath(List<Point> points)
    {
        Path path = new()
        {
            Stroke = Brushes.Blue,
            StrokeThickness = 1
        };
        PathGeometry pathGeometry = new();
        PathFigure pathFigure = new()
        {
            StartPoint = points[0]
        };
        List<LineSegment> lineSegments = new();
        for (var i = 1; i < points.Count; i++)
        {
            LineSegment lineSegment = new(points[i], true);
            lineSegments.Add(lineSegment);
        }
        LineSegment closeSegment = new(points[0], true);
        lineSegments.Add(closeSegment);
        pathFigure.Segments = new PathSegmentCollection(lineSegments);
        pathGeometry.Figures.Add(pathFigure);
        path.Data = pathGeometry;

        return path;
    }
}