using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    public GameObject Bulle;
    float timeLeft = 5.0f;
    private void Start()
    {
        Bulle.SetActive(true);
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