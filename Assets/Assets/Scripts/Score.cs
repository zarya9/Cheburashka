using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text bestScoreText;
    public float gameSpeed = 1f;
    private int score = 0;
    private int bestScore = 0;
    private float spawnRate;

    public OrangeSpawner orangeSpawner;

    void Start()
    {
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        UpdateScoreText();
        UpdateBestScoreText();
    }

    public void AddScore(int points)
    {
        score += points;
        UpdateScoreText();
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            UpdateBestScoreText();
        }
        if (score == 5)
        {
            orangeSpawner.SetSpawnRate(1.5f);
            //orangeSpawner.SetOrangeSpeed(2.5f);
        }

        if (score == 15)
        {
            orangeSpawner.SetSpawnRate(1f);
            //orangeSpawner.SetOrangeSpeed(3f);
        }

        if (score == 35)
        {
            orangeSpawner.SetSpawnRate(0.5f);
            //orangeSpawner.SetOrangeSpeed(3.5f);
        }
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "—чет: " + score;
        }
    }

    private void UpdateBestScoreText()
    {
        if (bestScoreText != null)
        {
            bestScoreText.text = "Ћучший " + bestScore;
        }
    }

    private void UpdateGameSpeed()
    {
        Time.timeScale = gameSpeed;
    }
    public float GetSpawnRate()
    {
        return spawnRate;
    }
}