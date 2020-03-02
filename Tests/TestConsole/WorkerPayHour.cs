using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class WorkerPayHour : Worker
    {
        public WorkerPayHour(double pay):base(pay)
        {
            _Pay = pay;
        }

        public override double Pay()
        {
            return _Pay * 20.8 * 8;
        }
    }
}
