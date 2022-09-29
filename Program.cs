using System;
using System.Threading;

namespace StateMachine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var gameobj = new gameObj();

            var stateMachine = new StateMachine<gameObj>(gameobj);
            stateMachine.AddState(new TestState());
            
            Console.WriteLine(stateMachine.GetOwner());
            stateMachine.Change<TestState>();

            while (true)
            {
                stateMachine.Update();
                Thread.Sleep(1000);
            }
        }
    }

    public class gameObj
    {
        public void Empty() => Console.WriteLine("NONE");
    }
}
