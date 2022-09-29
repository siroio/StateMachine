using System;
using System.Threading;

namespace StateMachine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var gameobj = new gameObj();
            var stateMachine = new StateMachine<gameObj>(gameobj)
                .AddState(new TestState());

            Console.WriteLine(stateMachine.GetOwner());
            Console.WriteLine(stateMachine.GetOwner().Empty());
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
        public string Empty() => "NONE";
    }
}
