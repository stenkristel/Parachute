using System.Collections;
using Structs;
using UnityEngine;

namespace Parachute
{
    //Made by: Sten Kristel
    /// <summary>
    /// Parachute variant that first only moves horizontally, will then stop for a couple seconds, and then move down very fast
    /// </summary>
    public class FallingChute : ParachuteMovement
    {
        [SerializeField] private MinAndMaxFloats moveHorizontallyDurationParameters;    //The minimum and maximum duration for how long the parachute moves horizontally
        [SerializeField] private float waitForFallingDuration;                          //The duration the parachute stand still before moving down
        [SerializeField] private GameObject[] moveDownSymbols;                          //The symbols that signal the player how long it takes before the parachute moves down
        
        private float _moveHorizontallyDuration;                                        //The duration for how long the parachute moves horizontally

        /// <summary>
        /// Calls base start then set the new _moveHorizontallyDuration and starts the MoveCycle
        /// </summary>
        protected override void Start()
        {
            base.Start();
            SetMoveHorizontallyDuration();
            StartCoroutine(MoveCycle());
        }

        /// <summary>
        /// Creates a random range using moveHorizontallyDurationParameters to set a random time the parachute will move horizontally
        /// </summary>
        private void SetMoveHorizontallyDuration()
        {
            _moveHorizontallyDuration = Random.Range(moveHorizontallyDurationParameters.minValue, moveHorizontallyDurationParameters.maxValue);
        }

        /// <summary>
        /// The move cycle of the parachute: Only move horizontally for a set time > Stop moving and start showing move down symbols in order > Move down
        /// </summary>
        private IEnumerator MoveCycle()
        {
            float waitTime = waitForFallingDuration / moveDownSymbols.Length;
            
            Speed = new Vector3(xSpeed, 0f, 0f);
            yield return new WaitForSeconds(_moveHorizontallyDuration);
            Speed = new Vector3(0f, 0f, 0f);
            foreach (var symbol in moveDownSymbols)
            {
                symbol.SetActive(true);
                yield return new WaitForSeconds(waitTime);
                symbol.SetActive(false);
            }
            Speed = new Vector3(0f, ySpeed, 0f);
        }
    }
}
