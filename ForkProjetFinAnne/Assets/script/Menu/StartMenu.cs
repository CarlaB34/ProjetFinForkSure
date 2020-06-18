using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    void Start()
    {
        Cursor.visible = true;
    }
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Play()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LoadingScene");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
            SceneManager.LoadScene("StartMenu");
    }
    public void Credit()
    {
        SceneManager.LoadScene("testCredit");
    }
}
