using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    using System;

    class Program
    {
        delegate T ArithmeticOperation<T>(T a, T b);

        static void Main()
        {
            Console.Write("Введіть перше число: ");
            if (!double.TryParse(Console.ReadLine(), out double num1))
            {
                Console.WriteLine("Некоректне число");
                return;
            }

            Console.Write("Введіть оператор (+, -, *, /): ");
            string operation = Console.ReadLine();

            Console.Write("Введіть друге число: ");
            if (!double.TryParse(Console.ReadLine(), out double num2))
            {
                Console.WriteLine("Некоректне число");
                return;
            }

            ArithmeticOperation<double> operationDelegate = operation switch
            {
                "+" => Add,
                "-" => Subtract,
                "*" => Multiply,
                "/" => Divide,
                _ => null
            };

            if (operationDelegate != null)
            {
                try
                {
                    double result = operationDelegate(num1, num2);
                    Console.WriteLine($"Результат: {result}");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Ділення на нуль неможливе.");
                }
            }
            else
            {
                Console.WriteLine("Некоректний оператор.");
            }
        }

        static double Add(double a, double b) => a + b;
        static double Subtract(double a, double b) => a - b;
        static double Multiply(double a, double b) => a * b;
        static double Divide(double a, double b) => b != 0 ? a / b : throw new DivideByZeroException();
    }

}
