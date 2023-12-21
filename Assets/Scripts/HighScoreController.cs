using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreController : MonoBehaviour
{

    public TMP_Text highScoreText;
    // Start is called before the first frame update
    
    void Start()
    {
        highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
    }
}
