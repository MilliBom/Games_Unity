using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    private int score;
    public Text scoreTxt;
    private void Update()
    {
        scoreTxt.text = "Score: " + score.ToString();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Enemy"))
        {
            score++;
            //Debug.Log(score);
        }
    }
}
