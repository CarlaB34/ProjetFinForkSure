using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelLoader4 : MonoBehaviour
{
    float timeLefts = 3.0f;
    public Slider sliders;

    void Update()
    {
        timeLefts -= Time.deltaTime;
        sliders.value = timeLefts;
        if (timeLefts < 0)
        {
            SceneManager.LoadScene("RoomBoss");
        }
    }

}