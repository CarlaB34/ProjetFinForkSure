using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("TestRoomLvl1");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
      //  GameIsPaused = false;
        SceneManager.LoadScene("StartMenu");
    }
}
