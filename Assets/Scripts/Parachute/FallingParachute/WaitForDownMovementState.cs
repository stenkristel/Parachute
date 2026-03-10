using System;
using System.Collections;
using StateMachine;
using UnityEngine;

namespace Parachute.FallingParachute
{
    public class WaitForDownMovementState : BaseState
    {
        public Action onFinishedWaiting;
        [SerializeField] ParachuteBehaviour parachuteBehaviour;
        [SerializeField] private float waitForFallingDuration; 
        [SerializeField] private GameObject[] moveDownSymbols; 

        public override void OnEnter()
        {
            parachuteBehaviour.Speed = Vector3.zero;
            StartCoroutine(ShowSymbols());
        }

        private IEnumerator ShowSymbols()
        {
            float waitTime = waitForFallingDuration / moveDownSymbols.Length;
            
            foreach (var symbol in moveDownSymbols)
            {
                symbol.SetActive(true);
                yield return new WaitForSeconds(waitTime);
                symbol.SetActive(false);
            }
            
            onFinishedWaiting?.Invoke();
        }
    }
}
