/*
 *  This script handles scorekeeping and game over logic.
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject gameplay;
    public GameObject gameOver;
    private int score;

    public void IncrementScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    public int GetScore()
    {
        return score;
    }

    public void GameOver()
    {
        gameplay.SetActive(false);
        gameOver.SetActive(true);
    }
}
