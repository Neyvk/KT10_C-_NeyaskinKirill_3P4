using System;
interface IClonable<T> where T : class
{
    T Clone();
}

class Point : IClonable<Point>
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Point Clone()
    {
        return new Point(X, Y);
    }

    public override string ToString()
    {
        return $"по x - {X} по y - {Y}";
    }
}

class Rectangle : IClonable<Rectangle>
{
    public int Width { get; set; }
    public int Height { get; set; }

    public Rectangle(int w, int h)
    {
        Width = w;
        Height = h;
    }

    public Rectangle Clone()
    {
        return new Rectangle(Width, Height);
    }

    public override string ToString()
    {
        return $"ширина - {Width} высота - {Height}";
    }
}

static class Cloner
{
    public static T Copy<T>(T obj) where T : class, IClonable<T>
    {
        return obj.Clone();
    }
}

class Program
{
    static void Main()
    {
        Point p1 = new Point(5, 10);
        Rectangle r1 = new Rectangle(20, 40);

        Point p2 = Cloner.Copy(p1);
        Rectangle r2 = Cloner.Copy(r1);

        Console.WriteLine("Оригиналы:");
        Console.WriteLine(p1);
        Console.WriteLine(r1);

        Console.WriteLine("\nКлоны:");
        Console.WriteLine(p2);
        Console.WriteLine(r2);

        Console.ReadLine();
    }
}
