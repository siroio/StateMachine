using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateMachine
{
    public class NullState : BaseState
    {
        public override void Entry() {}

        public override void Execute() {}

        public override void Exit() {}
    }
}
