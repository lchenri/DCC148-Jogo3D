using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreController : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;
    public static ScoreController instance;

    void Start()
    {
        instance = this;
    }


    public void UpdateScore()
    {
        score++;

        scoreText.text = score.ToString();

        PlayerPrefs.SetInt("Score", score);
    }
}
