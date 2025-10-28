using System;
using Score;
using UnityEngine;
using TMPro;


namespace GameOver
{
    //Made by: Sten Kristel
    /// <summary>
    /// Turns game over UI on when the player is game over and updaters the score on the UI
    /// </summary>
    public class GameOverUIBehaviour : MonoBehaviour
    {
        [SerializeField] private GameObject visuals;        //The visuals of the game over UI
        [SerializeField] private TMP_Text scoreText;        //The score text that represents the final score
        private void Start() => AssignEvents();             //Assigns events on start

        /// <summary>
        /// Assigns Events on defeat, to enable the visuals and update the final score
        /// </summary>
        private void AssignEvents()
        {
            GameOverManager.Instance.OnDefeat += EnableVisuals;
            GameOverManager.Instance.OnDefeat += UpdateScoreUI;
        }

        /// <summary>
        /// Updates the final score
        /// </summary>
        private void UpdateScoreUI()
        {
            scoreText.text = ScoreManager.Instance.Score.ToString();
        }

        /// <summary>
        /// Enables the visuals
        /// </summary>
        private void EnableVisuals()
        {
            visuals.SetActive(true);
        }
    }
}
