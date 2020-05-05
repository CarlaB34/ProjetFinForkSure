/*using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class dash : MonoBehaviour
{
    [SerializeField]  float speed, delay, delayPress;
  //  [SerializeField] GameObject particle;
    [HideInInspector] public bool startDelay;

    Rigidbody rb;
    int rightPress, leftPress;
    float timePassed, timePassedPress;
    bool startTimer;
    private float moveVelocity;
    private void Start()
    {
        rightPress = 0;
        leftPress = 0;

        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Dash"))
        {
            leftPress++;
            rightPress++;
            startTimer = true;
        }
        /*else if (Input.GetButtonDown("Dash") && Input.GetKey(KeyCode.E))
        {
            leftPress++;
            startTimer = true;
        }*/

        /*if (startTimer)
        {
            timePassedPress += Time.deltaTime;
            if(timePassedPress >= delayPress)
            {
                startTimer = false;
                leftPress = 0;
                rightPress = 0;
                timePassedPress = 0;
            }
        }

        if(leftPress >= 2 || rightPress >=2)
        {
            startDelay = true;
           // Instantiate(particle, transform, false);
        }
    }

    private void FixedUpdate()
    {
        if(startDelay)
        {
            timePassed += Time.deltaTime;

            if(timePassed <= delay)
            {
                if(rightPress >= 2)
                {
                    rb.velocity = new Vector3(speed, rb.velocity.y);
                    moveVelocity = speed;
                    rightPress = 0;
                }
                else if(leftPress >= 2)
                {
                    rb.velocity -= new Vector3(speed, rb.velocity.y);
                    moveVelocity = -speed;
                    leftPress = 0;
                }
            }
            else
            {
                timePassed = 0;
                startDelay = false;
                rightPress = 0;
                leftPress = 0;
            }
        }
    }

}*/