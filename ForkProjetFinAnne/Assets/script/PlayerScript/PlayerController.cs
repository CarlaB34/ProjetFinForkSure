using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    //Movement
    public float speed;
    //dash
    public float speedDash = 10;
    public static bool dashing = false;

    float moveVelocity;
    
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public static int Key = 0;
    public bool isGrounded;
    Rigidbody rb;
    //Grounded Vars
    private Vector3 moveDirection = Vector3.zero;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
    }
    void OnCollisionStay()
    {
        isGrounded = true; // touche le sol 
    }
    void OnCollisionExit()
    {
        isGrounded = false; // ne touche plus le sol 
    }
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && rb.velocity.y <= 0) // jump
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
            speed = 15;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            transform.rotation = Quaternion.Euler(0, -180, 0 * speed);
            moveVelocity = -speed;
            //dash

            dashing = false;
            speedDash = 0;
            speed = 2;

        }
        //Right movement + dash 
        if (Input.GetKey(KeyCode.E))
        {
            //attackDash();
            transform.rotation = Quaternion.Euler(0, 0, 0 * speed);
            moveVelocity = speed;
            dashing = true;
            speed = 15;
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0 * speed);
            moveVelocity = speed;

            //dash

            dashing = false;
            speedDash = 0;
            speed = 2;

        }

        GetComponent<Rigidbody>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody>().velocity.y);


    }
    void OnCollisionEnter(Collision collision) // ajouter 1 a la variable Key lorsqu'on touche la clé 
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("clé"))
        {
            Key += 1;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("door") && Key == 1) // test de layer 
        {
            Debug.Log("touché") ;
            
        }

        //col mur
        if (collision.gameObject.name == "wall")
        {
            rb.velocity = Vector3.zero;
            dashing = false;
        }

    }

    }

        
    
