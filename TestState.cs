using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine
{
    public class TestState : IBaseState
    {
        public void Entry() 
        {
            Console.WriteLine("EntryState");
        }

        public void Execute() 
        {
            Console.WriteLine("Execution");
        }

        public void Exit() 
        {
            Console.WriteLine("QuitState");
        }
    }
}
