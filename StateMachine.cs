using System;
using System.Collections.Generic;
using System.Linq;

namespace StateMachine
{
    public interface IBaseState
    {
        public void Entry();
        public void Execute();
        public void Exit();
    }

    public class NullState : IBaseState
    {
        public void Entry() { }
        public void Execute() { }
        public void Exit() { }
    }

    public class StateMachine<OwnerType> where OwnerType : class
    {
        private readonly OwnerType Owner;
        private readonly HashSet<IBaseState> StateTable;
        public IBaseState PrevState { get; private set; }
        public IBaseState CurrentState { get; private set; }

        public StateMachine(OwnerType Owner, IBaseState StartState = null)
        {
            this.Owner = Owner;
            StateTable = new HashSet<IBaseState>();
            CurrentState = StartState ?? new NullState();
        }

        public void Update() => CurrentState.Execute();

        public StateMachine<OwnerType> AddState(params IBaseState[] state)
        {
            foreach (var s in state) StateTable.Add(s);
            return this;
        }

        public StateMachine<OwnerType> Change<State>()
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
            return this;
        }

        public IBaseState[] GetStateList() => StateTable.ToArray();

        public OwnerType GetOwner() => Owner;
    }
}
