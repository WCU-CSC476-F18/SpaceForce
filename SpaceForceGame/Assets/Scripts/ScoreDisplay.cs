using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreDisplay : MonoBehaviour {
    public TextMeshProUGUI yourScoreDisplay;
    ConnectObjects conn;
    


    public void Start()
    {

        yourScoreDisplay = GetComponent<TextMeshProUGUI>();
        
        conn = FindObjectOfType<ConnectObjects>();
        
    }

    public void Update()
    {
        yourScoreDisplay.text ="Score: "+conn.GetScore().ToString();
    }

}
