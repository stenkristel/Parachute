using System;
using UnityEngine;

namespace Score
{
    //Made by: Sten Kristel
    /// <summary>
    ///  Singleton used for keeping track of how many parachutes the player has caught,
    /// Only one ScoreManager is allowed to exist in a scene and can be accessed without reference.
    /// </summary>
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }                       //The instance used by other classes to easily access this class.
        
        private int _score;                                                             //How many parachutes the player has cuaght
        
        public int Score { get => _score; private set => _score = value; }              //Getter/Setter for _score
        
        public Action<int> OnScoreChanged;                                              //<int: the new score> Gets called when the score is changed                                

        private void Awake() => AssignInstance();                                       //Assigns the instance before the game starts.
        
        /// <summary>
        /// Add points to the score
        /// </summary>
        /// <param name="score">The amount to add to the score</param>
        public void AddScore(int score)
        {
            _score += score;
            OnScoreChanged?.Invoke(_score);
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
