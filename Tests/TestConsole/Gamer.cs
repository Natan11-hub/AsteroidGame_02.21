using System;

namespace TestConsole
{
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
