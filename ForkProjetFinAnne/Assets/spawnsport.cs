using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnsport : MonoBehaviour
{
    public GameObject Bulle;
    float timeLeft = 5.0f;

 
    void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Bulle.SetActive(true);
        }
    }
        void Update()
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                Bulle.SetActive(false);
            }
        }


    
}