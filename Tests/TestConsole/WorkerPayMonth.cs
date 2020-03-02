using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
    public class WorkerPayMonth : Worker
    {
        public WorkerPayMonth(double pay) : base(pay)
        {
            _Pay = pay;
        }

        public override double Pay()
        {
            return _Pay;
        }
    }
}
