using System;

class Number
{
    public int RealPart { get; }

    public Number(int realPart)
    {
        RealPart = realPart;
    }

    public virtual void Print()
    {
        Console.WriteLine($"Number = {RealPart}");
    }
}

class ComplexNumber : Number
{
    public int ImaginaryPart { get; }

    public ComplexNumber(int realPart, int imaginaryPart) : base(realPart)
    {
        ImaginaryPart = imaginaryPart;
    }

    public static ComplexNumber Add(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.RealPart + b.RealPart, a.ImaginaryPart + b.ImaginaryPart);
    }

    public static ComplexNumber Subtract(ComplexNumber a, ComplexNumber b)
    {
        return new ComplexNumber(a.RealPart - b.RealPart, a.ImaginaryPart - b.ImaginaryPart);
    }

    public static ComplexNumber Multiply(ComplexNumber a, ComplexNumber b)
    {
        int realPart = (a.RealPart * b.RealPart) - (a.ImaginaryPart * b.ImaginaryPart);
        int imaginaryPart = (a.RealPart * b.ImaginaryPart) + (a.ImaginaryPart * b.RealPart);
        return new ComplexNumber(realPart, imaginaryPart);
    }

    public static ComplexNumber Divide(ComplexNumber a, ComplexNumber b)
    {
        if (b.RealPart == 0 && b.ImaginaryPart == 0)
        {
            throw new DivideByZeroException("Division by zero is not allowed.");
        }

        int realPart = (a.RealPart * b.RealPart + a.ImaginaryPart * b.ImaginaryPart) / (b.RealPart * b.RealPart + b.ImaginaryPart * b.ImaginaryPart);
        int imaginaryPart = (a.ImaginaryPart * b.RealPart - a.RealPart * b.ImaginaryPart) / (b.RealPart * b.RealPart + b.ImaginaryPart * b.ImaginaryPart);

        return new ComplexNumber(realPart, imaginaryPart);
    }

    public override void Print()
    {
        Console.WriteLine($"Number = {RealPart} + {ImaginaryPart}i");
    }
}

class Program
{
    static void Main()
    {
        ComplexNumber number1 = new ComplexNumber(10, 5);
        ComplexNumber number2 = new ComplexNumber(3, 2);

        ComplexNumber sum = ComplexNumber.Add(number1, number2);
        ComplexNumber difference = ComplexNumber.Subtract(number1, number2); 
        ComplexNumber product = ComplexNumber.Multiply(number1, number2);
        ComplexNumber quotient = ComplexNumber.Divide(number1, number2);

        number1.Print();
        number2.Print();
        sum.Print();
        difference.Print();
        product.Print();
        quotient.Print();
    }
}