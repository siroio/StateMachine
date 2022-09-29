using System;
using System.Collections.Generic;
using System.Linq;

namespace StateMachine
{
    public class StateMachine<OwnerType> where OwnerType : class
    {
        private readonly OwnerType Owner;
        private readonly HashSet<BaseState> StateTable;
        public BaseState PrevState { get; private set; }
        public BaseState CurrentState { get; private set; }

        public StateMachine(OwnerType Owner)
        {
            this.Owner = Owner;
            StateTable = new HashSet<BaseState>();
            CurrentState = new NullState();
        }

        public void Update() => CurrentState.Execute();

        public void AddState(params BaseState[] state)
        {
            foreach (var s in state) StateTable.Add(s);
        }

        public void Change<State>()
        {
            foreach (var InState in StateTable)
            {
                if (InState is not State) continue;
                CurrentState.Exit();
                PrevState = CurrentState;
                CurrentState = InState;
                CurrentState.Entry();
                break;
            }
        }

        public BaseState[] GetStateList() => StateTable.ToArray();

        public OwnerType GetOwner() => Owner;
    }
}
