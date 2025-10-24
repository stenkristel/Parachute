using System;
using Score;
using UnityEngine;
using TMPro;

public class UIScoreTracker : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;

    private void Start() => ScoreManager.Instance.OnScoreChanged += UpdateScore;

    private void OnDestroy() => ScoreManager.Instance.OnScoreChanged -= UpdateScore;

    private void UpdateScore(int newScore)
    {
        scoreText.text = newScore.ToString();
    }
}
