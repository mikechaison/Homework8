using System;

/*
Так як при виклику останнього сеттера і ширині, і висоті надано значення 10,
то у відповіді виходить 10*10=100.
Порушений принцип підстановки Лісков.
Помилкове наслідування квадрата від прямокутника
*/

interface IRect
{
    public int Width { get; set; }
    public int Height { get; set; }
    public int GetRectangleArea();
}

class Rectangle: IRect
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }
    public int GetRectangleArea()
    {
        return Width * Height;
    }
}


class Square: Rectangle
{
    public override int Width
    {
        get { return base.Width; }
        set
        {
            base.Height = value;
            base.Width = value;
        }
    }
    public override int Height
    {
        get { return base.Height; }
        set
        {
            base.Height = value;
            base.Width = value;
        }
    }
}

    class Program
    {
        static void Main(string[] args)
        {
            IRect rect = new Rectangle();
            rect.Width = 5;
            rect.Height = 10;

            Console.WriteLine(rect.GetRectangleArea());
        }
    }