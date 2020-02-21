﻿using System;
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
            var gamer = new Gamer();
            gamer.Name = "Игрок 1";
            gamer.DayOfBirth = new DateTime(1978, 12, 26);

            Gamer[] gamers = new Gamer[100];
            for(int i = 0; i < gamers.Length; i++)
            {
                var g = new Gamer();
                g.Name = $"Gamer {i + 1}";
                g.DayOfBirth = DateTime.Now;
                gamers[i] = g;
            }
            Console.ReadLine();
        }
    }
    class Gamer
    {
        public string Name;
        public DateTime DayOfBirth;
    }
}
