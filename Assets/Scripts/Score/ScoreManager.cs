using System;
using UnityEngine;

namespace Score
{
    public class ScoreManager : MonoBehaviour
    {
        public static ScoreManager Instance { get; private set; }                       //The instance used by other classes to easily access this class.
        
        private int _score;

        public Action<int> OnScoreChanged;

        private void Awake() => AssignInstance();                                       //Assigns the instance before the game starts.
        
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
