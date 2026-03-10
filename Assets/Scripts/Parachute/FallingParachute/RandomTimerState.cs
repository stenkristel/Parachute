using System;
using System.Collections;
using StateMachine;
using Structs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Parachute.FallingParachute
{
    public class RandomTimerState : BaseState
    {
        [SerializeField] private MinAndMaxFloats timerDuration;

        public Action onTimerEnd;

        public override void OnEnter()
        {
            StartCoroutine(Timer(Random.Range(timerDuration.minValue, timerDuration.maxValue)));
        }

        private IEnumerator Timer(float time)
        {
            yield return new WaitForSeconds(time);
            onTimerEnd?.Invoke();
        }
    }
}
