using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    private const string BEST_SCORE = "BEST_SCORE";

    private int currentScore = 0;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private void Awake()
    {
        Instance = this;

        UpdateBestScoreUI();
    }

    #region Scoring Functions
    public void IncreaseScore(int scoreToIncrease)
    {
        currentScore += scoreToIncrease;
        scoreText.text = currentScore.ToString();
    }

    public void ResetScore()
    {
        currentScore = 0;
        scoreText.text = currentScore.ToString();
    }
    #endregion

    public void CheckIfBestScore()
    {
        if (currentScore > PlayerPrefs.GetFloat(BEST_SCORE))
        {
            PlayerPrefs.SetFloat(BEST_SCORE, currentScore);
            UpdateBestScoreUI();
        }
    }

    public void UpdateBestScoreUI()
    {
        bestScoreText.text = "BEST : " + PlayerPrefs.GetFloat(BEST_SCORE);
    } 
}
