using System;
using UnityEngine;

namespace GameOver
{
    //Made by: Sten Kristel
    /// <summary>
    /// Singleton used for keeping track of how many parachutes the player has missed,
    /// and making them lose the game when a threshold has been reached.
    /// Only one DefeatManager is allowed to exist in a scene and can be accessed without reference.
    /// </summary>
    public class GameOverManager : MonoBehaviour
    {
        public static GameOverManager Instance { get; private set; }                      //The instance used by other classes to easily access this class.
        
        [Tooltip("The player is defeated when they have missed this many parachutes")]
        [SerializeField] private int parachutesMissedLoseThreshold;                     //The player is defeated when they have missed this many parachutes
        
        private int _parachutesMissed;                                                  //The amount of parachutes the player has missed.
        
        public Action<int> OnParachuteMissed;                                           //Event that gets called when the player misses a parachute and gives the amount of parachutes missed with it
        public Action OnGameOver;                                                       //Event that gets called when the player has missed to many parachutes and the game is over
        
        private void Awake() => AssignInstance();                                        //Assigns the instance before the game starts.

        
        /// <summary>
        /// When the bottom borer is hit, it adds 1 to parachutesMissed and checks if it reaches the loseThreshold,
        /// if it does; invoke the defeat event
        /// </summary>
        public void ParachuteMiss()
        {
            _parachutesMissed++;
            OnParachuteMissed?.Invoke(_parachutesMissed);
            if (_parachutesMissed == parachutesMissedLoseThreshold)
            {
                OnGameOver?.Invoke();
            } 
        }
        
        /// <summary>
        /// Checks if instance has been assigned with a different instance than this, if so; Destroy this instance
        /// If not; assigns instance with itself
        /// </summary>
        private void AssignInstance()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            Instance = this;
        }
    }
}
