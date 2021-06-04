using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("This is QuitGame!");
        Application.Quit();
    }
    public void RetryGame()
    {
        Debug.Log("This is RetryGame!");
        SceneManager.LoadScene(1);
    }
}
