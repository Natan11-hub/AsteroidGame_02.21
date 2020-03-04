using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public delegate double Fun(double x);
    static class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Таблица функции Sin:");
            Table(Math.Sqrt, -2, 2);
            Console.WriteLine("Таблица функции Simple:");
            Table(Simple, 0, 3);
            Console.ReadLine();
        }
        public static void Table(Fun f, double x, double b)
        {
            Console.WriteLine("----- X ----- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, f?.Invoke(x)); // Прежде чем вызвать функцию, обязательно проверяем на существование ссылки на объект
                x += 1;
            }
            Console.WriteLine("---------------------");
        }
        public static double Simple(double x)
        {
            return x * x;
        }
    }
}