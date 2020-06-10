using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Lvl1Win : MonoBehaviour
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
        Time.timeScale = 1f;
        SceneManager.LoadScene("Lvl2");
    }
}
