using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public UnityEngine.UI.Text scoreText;
    public UnityEngine.UI.Button startButton;
    public GameObject Menu;

    public static GameControllerScript instance;

    bool isStarted = false;

    int score = 0;

    public bool getIsStarted()
    {
        return isStarted;
    }
    // Start is called before the first frame update
    public void increaseScore (int increment)
    {
        score += increment;
        scoreText.text = "Score: " + score;
    }

    void Start()
    {
        instance = this;
        AudioSource sound = GetComponent<AudioSource>(); 
        startButton.onClick.AddListener(delegate
        {
            Menu.SetActive(false);
            isStarted = true;
            sound.Play();
        });
    }

}
