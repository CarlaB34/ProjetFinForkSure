using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CreditMenu : MonoBehaviour
{
    // public string Menu;
    public VideoPlayer videoPlayer;

    public float timer = 19f;

    public void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            SceneManager.LoadScene("StartMenu");
        }
    }

}
