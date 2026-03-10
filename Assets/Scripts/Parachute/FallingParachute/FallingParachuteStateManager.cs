using System;
using StateMachine;
using UnityEngine;

namespace Parachute.FallingParachute
{
    public class FallingParachuteStateManager : MonoBehaviour
    {
        [SerializeField] private BaseState startingState;
        [SerializeField] private RandomTimerState horizontalMovementState;
        [SerializeField] private WaitForDownMovementState waitForDownMovementState;
        [SerializeField] private BaseState downMovementState;
        private  StateBehaviour _stateBehaviour;

        private void Start()
        {
            CreatStateMachine();
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
            DeleatStateConditions();
        }

        private void CreatStateMachine()
        {
            _stateBehaviour = new StateBehaviour(startingState.GetType(), horizontalMovementState, waitForDownMovementState, downMovementState);
        }

        private void CreateStateConditions()
        {
            horizontalMovementState.onTimerEnd += SwitchToWaitForDownMovementState;
            waitForDownMovementState.onFinishedWaiting += SwitchToDownMovementState;
        }

        private void DeleatStateConditions()
        {
            horizontalMovementState.onTimerEnd -= SwitchToWaitForDownMovementState;
            waitForDownMovementState.onFinishedWaiting -= SwitchToDownMovementState;
        }

        private void SwitchToWaitForDownMovementState()
        {
            _stateBehaviour.SwitchState(waitForDownMovementState.GetType());
        }
        
        private void SwitchToDownMovementState()
        {
            _stateBehaviour.SwitchState(downMovementState.GetType());
        }
    }
}
