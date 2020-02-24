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

            var space_ship = new SpaceShip(new Vector2D(5, 7));

            var v1 = new Vector2D(1, 8);

            var space_ship2 = space_ship;
            space_ship.Position = new Vector2D(150, -210);

            Console.ReadLine();
        }
    }
}
