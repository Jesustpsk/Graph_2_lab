﻿using System;
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
    public static double[,] TranslateAlongX(double deltaX)
    {
        double[,] translationMatrix = new double[3, 3];
        
        translationMatrix[0, 0] = 1;
        translationMatrix[1, 1] = 1;
        translationMatrix[2, 2] = 1;
        
        translationMatrix[0, 2] = deltaX;
        
        return translationMatrix;
    }
    public static double[,] ScaleAlongSide(double scaleFactor, Line selectedLine)
    {
        double[,] scaleMatrix = new double[3, 3];
        var sideEnd = new Point(selectedLine.X2, selectedLine.Y2);
        var sideStart = new Point(selectedLine.X1, selectedLine.Y1);
        double dx = sideEnd.X - sideStart.X;
        double dy = sideEnd.Y - sideStart.Y;
        double sideLength = Math.Sqrt(dx * dx + dy * dy);

        double scaleX = scaleFactor * (dx / sideLength);
        double scaleY = scaleFactor * (dy / sideLength);
        scaleMatrix[0, 0] = scaleX;
        scaleMatrix[1, 1] = scaleY;
        scaleMatrix[2, 2] = 1;

        return scaleMatrix;
    }
    public static double[,] ReflectAboutVertex(Point vertex)
    {
        double[,] reflectMatrix = new double[3, 3];
        
        reflectMatrix[0, 0] = -1;
        reflectMatrix[1, 1] = -1;
        reflectMatrix[2, 2] = 1;
        
        reflectMatrix[0, 2] = 2 * vertex.X;
        reflectMatrix[1, 2] = 2 * vertex.Y;
        
        return reflectMatrix;
    }
    public static double[,] RotateAroundVertex(double angleInDegrees, Point vertex)
    {
        double angleInRadians = angleInDegrees * Math.PI / 180.0;
        double cosTheta = Math.Cos(angleInRadians);
        double sinTheta = Math.Sin(angleInRadians);

        double[,] rotationMatrix = new double[3, 3];
        
        rotationMatrix[0, 0] = cosTheta;
        rotationMatrix[0, 1] = -sinTheta;
        rotationMatrix[1, 0] = sinTheta;
        rotationMatrix[1, 1] = cosTheta;
        rotationMatrix[2, 2] = 1;

        rotationMatrix[0, 2] = vertex.X - cosTheta * vertex.X + sinTheta * vertex.Y;
        rotationMatrix[1, 2] = vertex.Y - sinTheta * vertex.X - cosTheta * vertex.Y;

        return rotationMatrix;
    }

    public static List<Point> ApplyTransformation(List<Point> figure, double[,] transformationMatrix)
    {
        List<Point> transformedFigure = new List<Point>();

        foreach (var point in figure)
        {
            // Преобразование точки с использованием матрицы преобразования
            double x = point.X * transformationMatrix[0, 0] + point.Y * transformationMatrix[0, 1] + transformationMatrix[0, 2];
            double y = point.X * transformationMatrix[1, 0] + point.Y * transformationMatrix[1, 1] + transformationMatrix[1, 2];

            transformedFigure.Add(new Point(x, y));
        }

        TempPoints = transformedFigure;
        return transformedFigure;
    }
    
    public static List<Point> ApplyTransformation(List<Point> figure, double[,] transformationMatrix, double scale, Line side)
    {
        List<Point> transformedFigure = new List<Point>();

        foreach (var point in figure)
        {
            // Преобразование точки с использованием матрицы преобразования
            double x = point.X * transformationMatrix[0, 0] + point.Y * transformationMatrix[0, 1] + transformationMatrix[0, 2];
            double y = point.X * transformationMatrix[1, 0] + point.Y * transformationMatrix[1, 1] + transformationMatrix[1, 2];

            x += (1 - scale) * side.X1;
            y += (1 - scale) * side.Y1;
            transformedFigure.Add(new Point(x, y));
        }

        TempPoints = transformedFigure;
        return transformedFigure;
    }
    public static void Fillmatrix(List<TextBox> lbox, double[,] matrix)
    {
        lbox[0].Text = matrix[0,0] + "";
        lbox[1].Text = matrix[0,1] + "";
        lbox[2].Text = matrix[0,2] + "";
        lbox[3].Text = matrix[1,0] + "";
        lbox[4].Text = matrix[1,1] + "";
        lbox[5].Text = matrix[1,2] + "";
        lbox[6].Text = matrix[2,0] + "";
        lbox[7].Text = matrix[2,1] + "";
        lbox[8].Text = matrix[2,2] + "";
    }
}

