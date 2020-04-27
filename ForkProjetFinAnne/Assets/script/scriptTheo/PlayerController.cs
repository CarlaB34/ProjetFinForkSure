using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour
{

    //Movement

    public float speed;

    public float speedDash = 10;
    public bool dashing = false;

  
    float moveVelocity;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    public bool isGrounded;
    Rigidbody rb;
    //Grounded Vars
    private Vector3 moveDirection = Vector3.zero;
    private GameObject cube;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    void OnCollisionStay()
    {
        isGrounded = true;
    }
    void OnCollisionExit()
    {
        isGrounded = false;
    }
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && rb.velocity.y <= 0)
        {

            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }


        moveVelocity = 0;

        if (Input.GetKey(KeyCode.A)) //attack
        {
            moveVelocity = speed;
            dashing = true;
            speed = 45;
            //  attackDash();
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))//Left Right Movement
        {
            transform.rotation = Quaternion.Euler(0, -180, 0 * speed);
            moveVelocity = -speed;


            dashing = false;
            speedDash = 0;
            speed = 3;

        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0 * speed);
            moveVelocity = speed;
            dashing = false;
            speedDash = 0;
            speed = 3;
           
        }
        

        GetComponent<Rigidbody>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody>().velocity.y);

       
    }

    private void attackDash()
    {
     
        /*speed += speedDash;
        dashing = true;
        if(speed >=55)
        {
            speedDash = 0;
            dashing = false;
           
        }*/

    }

    /*void OnCollisionEnter(Collision collision) // on perd un point de vie si on touche un pic
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("pike"))
        {
            Debug.Log("vous prenez 1 degat");
            playerhealth -= 1;

        }
    }*/
}
 