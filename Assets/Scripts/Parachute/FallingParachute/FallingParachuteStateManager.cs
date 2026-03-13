using System;
using StateMachine;
using UnityEngine;

namespace Parachute.FallingParachute
{
    public class FallingParachuteStateManager : MonoBehaviour
    {
        [SerializeField] private BaseState startingState;
        [SerializeField] private WaitingState horizontalMovementState;
        [SerializeField] private WaitingStateIntervals waitingStateIntervals;
        [SerializeField] private BaseState downMovementState;
        private StateBehaviour _stateBehaviour;

        private void Start()
        {
            CreateStateBehaviour();
            CreateStateConditions();
        }

        private void Update()
        {
            _stateBehaviour.OnUpdate();
        }

        private void FixedUpdate()
        {
            _stateBehaviour.OnFixedUpdate();
        }

        private void OnDestroy()
        {
            UnsubscribeEvents();
        }

        private void CreateStateBehaviour()
        {
            _stateBehaviour = new StateBehaviour(startingState.GetType(),
                horizontalMovementState, waitingStateIntervals, downMovementState);
        }

        private void CreateStateConditions()
        {
            horizontalMovementState.onTimerEnd += SwitchToWaitForDownMovementState;
            waitingStateIntervals.onFinishedWaiting += SwitchToDownMovementState;
        }

        private void UnsubscribeEvents()
        {
            horizontalMovementState.onTimerEnd -= SwitchToWaitForDownMovementState;
            waitingStateIntervals.onFinishedWaiting -= SwitchToDownMovementState;
        }

        private void SwitchToWaitForDownMovementState()
        {
            _stateBehaviour.SwitchState(waitingStateIntervals.GetType());
        }
        
        private void SwitchToDownMovementState()
        {
            _stateBehaviour.SwitchState(downMovementState.GetType());
        }
    }
}
