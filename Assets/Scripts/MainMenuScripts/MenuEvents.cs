using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuEvents : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SoundOn()
    {
        //Todo Sound on and off button
    }

    public void OpenTutorial()
    {
        SceneManager.LoadScene(2);
    }

    public void OpenCredits()
    {
        SceneManager.LoadScene(3);
    }
}
