using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GOMenuLvl2 : MonoBehaviour
{
    private void Update()
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
        SceneManager.LoadScene("LoadingScene");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
            SceneManager.LoadScene("StartMenu");
    }
}
