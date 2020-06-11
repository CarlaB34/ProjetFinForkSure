using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    #region idee move left and right
    /*//avance de gauche a droite
    public float delta = 1.5f;  // Amount to move left and right from the start point
    public float speed = 2.0f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        Vector3 v = startPos;
        v.x += delta * Mathf.Sin(Time.time * speed);
        transform.position = v;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "wall")
        {

        }
    }*/
    #endregion

    [SerializeField]
    Transform player;

    //distance de suivie du player
    [SerializeField]
    float agroRange;

    [SerializeField]
    float moveSpeed;

    /// <summary>The objects initial position.</summary>
    private Vector3 startPosition;
    /// <summary>The objects updated position for the next frame.</summary>
    private Vector3 newPosition;
    //distance ou l'enemi detect la pressence du player
    [SerializeField] private int maxDistance = 2;

    //jump
    public float jumpHeight;
    float jumpSpeed;
    Vector3 velocity;
    private float canJump = 0f;


    Rigidbody rb;
   public static int IAhealth = 5;

    private void Start()
    {
        //comportement quand chase pas
        startPosition = transform.position;
        newPosition = transform.position;

        rb = GetComponent<Rigidbody>();

        jumpSpeed = Mathf.Sqrt(-2 * Physics.gravity.y * jumpHeight) + 0.1f;

    }

    private void Update()
    {

        //distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);



        if (distToPlayer < agroRange)
        {
            //code to chase player
            ChasePlayer();
        }
        else
        {
            //stop chasing player and move
            StopChasingPlayer();
        }


        

    }

    private void ChasePlayer()
    {
        if (transform.position.x < player.position.x)
        {
            //enemy is to the left side of the player, so move right
            //avance seulement vers le player
            //rb.velocity = new Vector2(moveSpeed, 0);
            //saute quand le palyer est dans l'agro
            if (Time.time > canJump)
            {
              //  Debug.Log("le temps s'ecoule");
                //saute vers le player mais pas dessu, a la saute moutton
                rb.velocity = new Vector2(moveSpeed, 0);
                velocity = rb.velocity;
                velocity.y = jumpSpeed;
                rb.velocity = velocity;
                canJump = Time.time + 1.5f;    // whatever time a jump takes //la durée d'un saut
            }

        }
        else
        {

            //enemy is to the right side of the player, so move left
            //avance seulement vers le player
            //rb.velocity = new Vector2(-moveSpeed, 0);

            //saute quand le palyer est dans l'agro
            if (Time.time > canJump)
            {
               // Debug.Log("le temps s'ecoule");
                rb.velocity = new Vector2(-moveSpeed, 0);
                velocity = rb.velocity;
                velocity.y = jumpSpeed;
                rb.velocity = velocity;
                canJump = Time.time + 1.5f;    // whatever time a jump takes
            }
        }
    }

    private void StopChasingPlayer()
    {
        //rb.velocity = new Vector2(0, 0);
        newPosition.x = startPosition.x + (maxDistance * Mathf.Sin(Time.time * moveSpeed));
        transform.position = newPosition;
    }

    //quand player plus dans la range, tp a la start postion et pas la nouvelle de la ou il est

    #region collision obstacle + col player - 1 vie
    //l'enemi saute par dessus l'obstacle, applique une force en hauter pour eviter un petit obstable
    void OnCollisionEnter(Collision col)
    {

       //Debug.Log("l'IA saute");
        switch (col.gameObject.tag)
        {
            case "wall":
                //rb.AddForce(Vector3.up * 700f);
                rb.AddForce(Vector3.up * 7f);
                break;
        }

        if (col.gameObject.layer == LayerMask.NameToLayer("Player") && Dash.dashinG)
        {

           // Debug.Log("l'IA prend 1 degat");
            IAhealth -= 1;
        }
        if (IAhealth == 0) // si vie = 0 on meurt
        {
            ///  Debug.Log("IA est morte");
            Destroy(gameObject);
            //SceneManager.LoadScene("Victory");
        }
    }

    //l'enemi ne saute plus apres avoir franchi l'obstable, applique la meme force vers le bas
    private void OnCollisionExit(Collision col)
    {
       // Debug.Log("l'IA Saute plus");
        switch (col.gameObject.tag)
        {
            case "ground":
                rb.AddForce(Vector3.down * 7f);
                // moveSpeed = 2;
                break;
        }
    }

    #endregion


}

