using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public Text scoreText;
    public int score;
   
    void Start()
    {
        score = 0;
    }
   public void UpdateScore()
    {
        scoreText.text = "SKOR: " + score;
    }
}
