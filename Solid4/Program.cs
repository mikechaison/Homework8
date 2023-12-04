using System;

interface IItem
{
    void SetPrice(double price);
}

interface IColor
{
    void SetColor(byte color);
}

interface ISize
{
    void SetSize(byte size);
}

interface IDiscount
{
    void ApplyDiscount(String discount);
    
}

interface IPromocode
{
    void ApplyPromocode(String promocode);
}

class Book : IItem, IDiscount
{
    private double price;
    private string discount;
    public void ApplyDiscount(string discount)
    {
        this.discount = discount;
    }

    public void SetPrice(double price)
    {
        this.price = price;
    }
}

class Clothing : IItem, IColor, ISize, IDiscount
{
    private double price;
    private string discount;
    private byte color;
    private byte size;
    public void ApplyDiscount(string discount)
    {
        this.discount = discount;
    }

    public void SetColor(byte color)
    {
        this.color = color;
    }

    public void SetPrice(double price)
    {
        this.price = price;
    }

    public void SetSize(byte size)
    {
        this.size = size;
    }
}

class Program
{
    static void Main(string[] args)
    {
       
        Console.ReadKey();
    }
}