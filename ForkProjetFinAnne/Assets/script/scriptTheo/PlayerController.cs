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

    private int playerhealth = 2;

   

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


        //Left Movement + dash
        if (Input.GetKey(KeyCode.A))
        {
            
            transform.rotation = Quaternion.Euler(0, -180, 0 * speed);
            moveVelocity = -speed;
            dashing = true;
            speed = 45;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            transform.rotation = Quaternion.Euler(0, -180, 0 * speed);
            moveVelocity = -speed;
            //dash
            
            dashing = false;
            speedDash = 0;
            speed = 3;

        }
        //Right movement + dash 
        if (Input.GetKey(KeyCode.E))
        {
            //attackDash();
            transform.rotation = Quaternion.Euler(0, 0, 0 * speed);
            moveVelocity = speed;
            dashing = true;
            speed = 45;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0 * speed);
            moveVelocity = speed;

            //dash
            
            dashing = false;
            speedDash = 0;
            speed = 3;

        }
    
        GetComponent<Rigidbody>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody>().velocity.y);

       
    }

    private void attackDash()
    {
        

    }


    void OnCollisionEnter(Collision collision) // on perd un point de vie si on touche un pic
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("pike"))
        {
            Debug.Log("vous prenez 1 degat");
            playerhealth -= 1;

        }
    }
}
 