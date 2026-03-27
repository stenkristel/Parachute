using StateMachine;
using Structs;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace Parachute.FallingParachute
{
    public class DownMovementState : BaseState
    {
        [SerializeField] private MinAndMaxFloats randomSpeedYParamaters;
        [FormerlySerializedAs("parachuteBehaviour")] [SerializeField] private ParachuteMovement parachuteMovement;

        public override void OnEnter()
        {
            float ySpeed = Random.Range(randomSpeedYParamaters.minValue, randomSpeedYParamaters.maxValue);
            parachuteMovement.Speed = new Vector3(0, ySpeed, 0);
        }
    }
}
