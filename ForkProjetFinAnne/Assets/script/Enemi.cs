/*using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Enemi : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        //distance to player
        float distToPlayer = Vector3.Distance(transform.position, player.position);
        //print("distToPlayer" + distToPlayer);

        if(distToPlayer < agroRange)
        {
            //code to chase player
            ChasePlayer();
        }
        else
        {
            //stop chasing player
            StopChasingPlayer();
        }
    }
    private void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            //enemy is to the left side of the player, so move right
            rb.velocity = new Vector3(moveSpeed, 0, 0);
            //transform.localScale = new Vector3(1, 1);
        }
        else
        {
            //enemy is to the left side of the player, so move left
            rb.velocity = new Vector3(-moveSpeed, 0, 0);
           // transform.localScale = new Vector3(-1, 1);
        }
    }

    private void StopChasingPlayer()
    {
        rb.velocity = new Vector3(0, 0, 0);
    }
}*/
