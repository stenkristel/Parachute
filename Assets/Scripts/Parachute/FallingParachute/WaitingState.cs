using System;
using System.Collections;
using StateMachine;
using Structs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Parachute.FallingParachute
{
    public class WaitingState : BaseState
    {
        [SerializeField] private MinAndMaxFloats waitDuration;

        public Action onTimerEnd;

        public override void OnEnter()
        {
            StartCoroutine(Timer(Random.Range(waitDuration.minValue, waitDuration.maxValue)));
        }

        private IEnumerator Timer(float time)
        {
            yield return new WaitForSeconds(time);
            onTimerEnd?.Invoke();
        }
    }
}
