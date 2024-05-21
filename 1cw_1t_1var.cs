using System;

namespace ComplexNumberOperations
{
    struct Number
    {
        public int RealPart { get; }

        public Number(int realPart)
        {
            RealPart = realPart;
        }

        public static Number Add(Number a, Number b)
        {
            return new Number(a.RealPart + b.RealPart);
        }

        public static Number Subtract(Number a, Number b)
        {
            return new Number(a.RealPart - b.RealPart);
        }

        public static Number Multiply(Number a, Number b)
        {
            return new Number(a.RealPart * b.RealPart);
        }

        public static Number Divide(Number a, Number b)
        {
            if (b.RealPart == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return new Number(a.RealPart / b.RealPart);
        }

        public void Display()
        {
            Console.WriteLine($"Number = {RealPart}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Number number1 = new Number(10);
            Number number2 = new Number(5);

            Number sum = Number.Add(number1, number2);
            Number difference = Number.Subtract(number1, number2);
            Number product = Number.Multiply(number1, number2);
            Number quotient = Number.Divide(number1, number2);

            number1.Display();
            number2.Display();
            sum.Display();
            difference.Display();
            product.Display();
            quotient.Display();
        }
    }
} 

