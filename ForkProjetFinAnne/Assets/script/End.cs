using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class End : MonoBehaviour
{
    float timeLeft = 3.0f;

    void Update()
    {
      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer== LayerMask.NameToLayer("Player"))
        {
            //Timer();
            SceneManager.LoadScene("Lvl1Win");
        }
    }
   
    //void Timer()
    //{
    //    timeLeft -= Time.deltaTime;
    //    if (timeLeft < 0)
    //    {
    //        SceneManager.LoadScene("Lvl1Win");
    //    }
    //}
}
