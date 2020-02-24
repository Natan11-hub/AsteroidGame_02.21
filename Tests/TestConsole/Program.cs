using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            //var gamer = new Gamer("Gamer 1", new DateTime(1998, 12, 5));

            //Gamer[] gamers = new Gamer[100];
            //for (int i = 0; i < gamers.Length; i++)
            //{
            //    var g = new Gamer(string.Format("Gamer {0}", i + 1), DateTime.Now.Subtract(TimeSpan.FromDays(365 * (i + 18))));
            //    gamers[i] = g;

            //}
            //foreach (var g in gamers)
            //    g.SayYourName();

            //var space_ship = new SpaceShip(new Vector2D(5, 7));

            //var v1 = new Vector2D(1, 8);

            //var space_ship2 = space_ship;
            //space_ship.Position = new Vector2D(150, -210);

            var v1 = new Vector2D(1, 8);
            Console.WriteLine(v1);
            Console.ReadLine();

            //var v2 = v1;

            //v1.X = 7;
            //v1.Y = -14;

            //var v3 = v1 + v2;
            //var v4 = v2 - v1;
            //var v5 = v4 + 8;
            //var v6 = -v5;

            var printer = new Printer();

            printer.Print("Hello world!");

            printer = new PrefixPrinter(">>>>>");

            printer.Print("Hello world!");

            printer = new DateTimeLogPrinter();
            printer.Print("Hello world!");


            Console.ReadLine();
        }
    }
    class Printer
    {
        public Printer()
        {

        }
        public virtual void Print(string str) => Console.WriteLine(str);
    }
    class PrefixPrinter : Printer
    {
        private string _Prefix;

        public PrefixPrinter(string Prefix) => _Prefix = Prefix;

        public override void Print(string str)
        {
            //Console.WriteLine("{0}{1}", _Prefix, str);
            base.Print(_Prefix + str);
        }
    }
    class DateTimeLogPrinter : Printer
    {
        public override void Print(string str)
        {
            Console.Write(DateTime.Now);
            Console.Write(">>");
            base.Print(str);
        }
    }
    class FilePrinter : Printer
    {
        private string _FileName;

        public FilePrinter(string FileName) => _FileName = FileName;

        public override void Print(string str)
        {
            System.IO.File.AppendAllText(_FileName, str);
        }
    }
}
