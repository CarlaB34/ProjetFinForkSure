using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    private int speedDash = 10;
    private int speed = 3;
    public bool dashing = false;

    float moveVelocity;

    //public GameObject player;
    //public GameObject enemy;

    //public float lifeP = 2f;
    //public float lifeE = 2f;

    private void Update()
    {

        attackDash();
        //Left Right Movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {


            //dash
            attackDash();
            dashing = false;
            speedDash = 0;
            speed = 3;

        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {

            //dash
            //attackDash();
            dashing = false;
            speedDash = 0;
            speed = 3;

        }
    }

    public void attackDash()
    {
        //attack Dash
        if (Input.GetKey(KeyCode.A))
        {
            //attackDash();
            if (Input.GetKeyDown("q"))
            {
                moveVelocity = -speed;
                dashing = true;
                speed = 45;

            }
            if (Input.GetKeyDown("d"))
            {
                moveVelocity = -speed;
                dashing = true;
                speed = 45;

            }

        }

    }
}
