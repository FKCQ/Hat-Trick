using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    public Text scoreText;
    public GameControl gameControl;
    public int ballValue = 1;

    public int score;

    private void Start()
    {
        score = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Ball")
        {
            score += ballValue;
            UpdateScoreText();
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bomb")
        {
            score -= ballValue * 2;
            UpdateScoreText();
            if(score < 0)
            {
                gameControl.GetComponent<GameControl>().GameOver();
            }
        }
        
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score:\n" + score;
    }
}
