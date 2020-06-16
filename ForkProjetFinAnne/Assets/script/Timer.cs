using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    float timeLeft = 3.0f;
    

    void Update()
    {
        timeLeft -= Time.deltaTime;
        
        if (timeLeft < 0)
        {
            SceneManager.LoadScene("Victory");
        }
    }

}
