using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine
{
    public abstract class BaseState
    {
        public abstract void Entry();
        public abstract void Execute();
        public abstract void Exit();
    }
}
