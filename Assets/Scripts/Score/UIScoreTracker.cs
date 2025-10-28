using TMPro;
using UnityEngine;

namespace Score
{
    //Made by: Sten Kristel
    /// <summary>
    /// Updates TMP_Text whenever the score is changed 
    /// </summary>
    public class UIScoreTracker : MonoBehaviour
    {
        [SerializeField] private TMP_Text scoreText;    //The UI text asset that should be changed

        private void Start() => ScoreManager.Instance.OnScoreChanged += UpdateScore;        //Assigns event to update score

        private void OnDestroy() => ScoreManager.Instance.OnScoreChanged -= UpdateScore;    //Unassigns event on destroy

        /// <summary>
        /// Changes the scoreText
        /// </summary>
        /// <param name="newScore">The new text</param>
        private void UpdateScore(int newScore)
        {
            scoreText.text = newScore.ToString();
        }
    }
}
