using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class LevelLoader : MonoBehaviour
{
    float timeLeft = 3.0f;
    public Slider slider;

    void Update()
    {
        timeLeft -= Time.deltaTime;
        slider.value = timeLeft;
        if (timeLeft < 0)
        {
            SceneManager.LoadScene("SceneModé3D");
        }
    }

}


