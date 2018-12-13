using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectObjects : MonoBehaviour {
    int score = 0;
  
    public void Awake()
    {
      
       SetUpLoopLoad();
    }

    
    public void SetUpLoopLoad()
    {
        int numConnObjects = FindObjectsOfType<ConnectObjects>().Length;
        if (numConnObjects>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
    

    public int GetScore()
    {
        return score;
    }


    public void AddToScore(int score)
    {
        this.score += score;
        if (this.score > HighScoreDisplay.highScore)
        {
            HighScoreDisplay.highScore = this.score;
            
        }
    }
    public void ResetGame()
    {
        Destroy(gameObject);
    }
}
