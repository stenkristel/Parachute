using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace StateMachine
{
    public class StateBehaviour
    {
        private Dictionary<System.Type, BaseState> _statesDictionary = new Dictionary<System.Type, BaseState>();
        private BaseState _currentState;

        public StateBehaviour(System.Type startState, params BaseState[] states)
        {
            foreach (var state in states)
            {
                state.Initialize(this);
                _statesDictionary.Add(state.GetType(), state);
            }

            SwitchState(startState);
        }

        public void OnUpdate()
        {
            _currentState?.OnUpdate();
        }
        
        public void OnFixedUpdate()
        {
            _currentState?.OnFixedUpdate();
        }

        public void SwitchState(System.Type newState)
        {
            _currentState?.OnExit();
            _currentState = _statesDictionary[newState];
            _currentState?.OnEnter();
        }
    }
}
