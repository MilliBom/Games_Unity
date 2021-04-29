using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOverUI : MonoBehaviour
{
    //quit game button
    public void Quit()
    {
        Debug.Log("This is quit!");
        Application.Quit();
    }
    //retry game button
    public void Retry()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }   
}
