using System;
using System.Collections;
using StateMachine;
using UnityEngine;
using UnityEngine.Events;

namespace Parachute.FallingParachute
{
    public class WaitingStateIntervals : BaseState
    {
        [Tooltip("The wait time between each interval")]
        [SerializeField] private float waitTime; 
        [SerializeField] private UnityEvent[] intervals; 
        
        public Action onFinishedWaiting;

        public override void OnEnter()
        {
            StartCoroutine(ShowSymbols());
        }

        private IEnumerator ShowSymbols()
        {
            foreach (var interval in intervals)
            {
                interval?.Invoke();
                yield return new WaitForSeconds(waitTime);
            }
            
            onFinishedWaiting?.Invoke();
        }
    }
}
