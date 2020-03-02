using System;

namespace TestConsole
{
    public abstract class Worker : IComparable
    {
        public double _Pay { get; set; }

        public Worker(double pay)
        {
            _Pay = pay;
        }

        public int CompareTo(object obj)
        {
            if(obj is Worker)
            {
                var other_workers = (Worker)obj;
                if (_Pay > other_workers._Pay)
                    return +1;
                else if (_Pay.Equals(other_workers._Pay))
                    return 0;
                else
                    return -1;
            }
            throw new ArgumentNullException(nameof(obj), "Такого рабочего нет!");
        }
        public static void Sort(object[] workers)
        {
            Array.Sort(workers);
        }

        public abstract double Pay();
    }
}
