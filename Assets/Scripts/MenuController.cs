using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadHowToPlay() 
    {
        SceneManager.LoadScene("Instructions");    
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
