using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuController : MonoBehaviour
{
    public Animator transition;
    public void LoadNextScene()
    {
        StartCoroutine(LoadLevel("DemoScene"));
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadHowToPlay() 
    {
        StartCoroutine(LoadLevel("Instructions"));    
    }
    public void LoadCredits()
    {
        StartCoroutine(LoadLevel("Credits"));
    }

    public void LoadMenu()
    {
        StartCoroutine(LoadLevel("StartScene"));
    }

    public void ReloadScene()
    {
        StartCoroutine(LoadLevel("DemoScene"));
    }

    IEnumerator LoadLevel(string levelName)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelName);
    }
}
