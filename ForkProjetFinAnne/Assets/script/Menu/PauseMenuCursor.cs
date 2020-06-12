﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuCursor : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame

    void Start()
    {
        //Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Pause();


        }

        //if (Input.GetKeyDown(KeyCode.Escape))
        //{

        //    if (GameIsPaused)
        //    {
        //        Cursor.visible = false;
        //        Resume();

        //    }
        //    else
        //    {
        //        Cursor.visible = true;
        //        Pause();
        //    }

        //}
    }

   public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    void Pause ()
    {
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;

        Cursor.lockState = CursorLockMode.None;
        
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("LoadingScene2");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
