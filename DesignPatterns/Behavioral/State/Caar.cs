using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral.State
{
    public class Caar
    {
        public enum State
        {
            Stopped,
            Started,
            Running
        }

        public enum Action
        {
            Stop,
            Start,
            Accelerate
        }

        private State _state = State.Stopped;
        public State CurrentState { get { return _state; } }

        public void TakeAction(Action action)
        {
            _state = (_state, action) switch
            {
                (State.Stopped, Action.Start) => State.Started,
                (State.Started, Action.Accelerate) => State.Running,
                (State.Started, Action.Stop) => State.Stopped,
                (State.Running, Action.Stop) => State.Stopped,
                _ => _state
            };
        }
    }
}
