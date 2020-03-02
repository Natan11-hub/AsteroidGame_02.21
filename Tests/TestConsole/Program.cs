using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    static class Program
    {
        static void Main(string[] args)
        {
            Worker[] work = {
                new WorkerPayHour(70), new WorkerPayHour(50),
                new WorkerPayMonth(30000), new WorkerPayMonth(40000) };
            Worker.Sort(work);

            foreach (Worker worker in work)
            {
                Console.WriteLine($"Рабочие получают следующие зп: {worker._Pay}");
                Console.ReadLine();
            }
        }
    }
}