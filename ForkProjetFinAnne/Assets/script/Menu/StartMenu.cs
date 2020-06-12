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
        //SceneManager.LoadScene("LoadingScene");
        //SceneManager.LoadScene("TestRoomLvl1C");
        SceneManager.LoadScene("Build");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
            SceneManager.LoadScene("StartMenu");
    }
}
