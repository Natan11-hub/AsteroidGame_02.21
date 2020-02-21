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
            var gamer = new Gamer("Gamer 1", new DateTime(1998, 12, 5));

            Gamer[] gamers = new Gamer[100];
            for(int i = 0; i < gamers.Length; i++)
            {
                var g = new Gamer(string.Format("Gamer {0}", i + 1), DateTime.Now.Subtract(TimeSpan.FromDays(365 * (i + 18))));
                gamers[i] = g;

            }
            foreach (var g in gamers)
                g.SayYourName();

            Console.ReadLine();
        }
    }
    class Gamer
    {
        private string _Name;
        private DateTime _DayOfBirth;

        public Gamer(string Name, DateTime DayOfBirth)
        {
            _Name = Name;
            _DayOfBirth = DayOfBirth;
        }
        public void SayYourName()
        {
            Console.WriteLine($"My name is {_Name} - {_DayOfBirth}");
        }
    }
}
