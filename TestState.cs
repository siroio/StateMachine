using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine
{
    public class TestState : BaseState
    {
        public override void Entry()
        {
            Console.WriteLine("EntryState");
        }

        public override void Execute()
        {
            Console.WriteLine("Execution");
        }

        public override void Exit() 
        {
            Console.WriteLine("QuitState");
        }
    }
}
