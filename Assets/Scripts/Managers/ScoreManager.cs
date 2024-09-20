using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int currentScore;
    [SerializeField] int highScore;
    [SerializeField] TextMeshProUGUI currentScoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    [SerializeField] int difficultyTreshold = 10;

    private SpawnManager spawnManager;

    public static ScoreManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()    
    {
        spawnManager = GetComponent<SpawnManager>();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        SetScoreText();
    }

    public void CheckScores()
    {
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            highScore = currentScore;
        }
    }

    private void SetScoreText()
    {
        currentScoreText.text = $"Score: {currentScore.ToString()}";
        highScoreText.text = $"High Score: {highScore.ToString()}";
    }

    public void IncreaseScore(int score)
    {
        currentScore += score;

        if (currentScore % 5 == 0) spawnManager.DecreaseParticleTime();
        if (currentScore >= difficultyTreshold && spawnManager.difficultyLevel <= 7)
        {
            spawnManager.IncreaseEnemySpawnNumber();
            difficultyTreshold += (int)(difficultyTreshold * 1.2f);
        }

        SetScoreText();
    }
}
