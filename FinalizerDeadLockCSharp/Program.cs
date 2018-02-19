using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalizerDeadLockCSharp
{
    class Program
    {
        ~Program()
        {
            System.Threading.Monitor.Enter(this);
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            System.Threading.Monitor.Enter(program);
            program = null;
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();
        }
    }
}
