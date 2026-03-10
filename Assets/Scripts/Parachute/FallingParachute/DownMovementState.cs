using StateMachine;
using Structs;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Parachute.FallingParachute
{
    public class DownMovementState : BaseState
    {
        [SerializeField] private MinAndMaxFloats randomSpeedYParamaters;
        [SerializeField] private ParachuteBehaviour parachuteBehaviour;

        public override void OnEnter()
        {
            float ySpeed = Random.Range(randomSpeedYParamaters.minValue, randomSpeedYParamaters.maxValue);
            parachuteBehaviour.Speed = new Vector3(0, ySpeed, 0);
        }
    }
}
