using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreController : MonoBehaviour
{

    public TMP_Text highScoreText;
        
    void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}
