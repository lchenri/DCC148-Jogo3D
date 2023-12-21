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
    private float lastPosZ = 0;

    void Start()
    {
        instance = this;
    }


    public void UpdateScore(float posZ)
    {
        if (posZ > lastPosZ)
        {
            lastPosZ = posZ;
            score++;
            scoreText.text = score.ToString();
            
            if (score > PlayerPrefs.GetInt("HighScore"))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
        }
    }
}
