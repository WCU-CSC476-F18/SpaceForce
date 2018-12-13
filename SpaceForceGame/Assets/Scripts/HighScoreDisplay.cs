using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreDisplay : MonoBehaviour {
    static public int highScore = 0;
     public TextMeshProUGUI highScoreText;
   




    public void Awake()
    {
        
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore");
        }
       
        PlayerPrefs.SetInt("HighScore", highScore);
       
    }

    public void Update()
    {
        highScoreText.text = "HighScore:" + highScore.ToString();
        if (highScore > PlayerPrefs.GetInt("HighScore"))
        {
            PlayerPrefs.SetInt("HighScore", highScore);
        }
      
    }


}
