using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    //Movement
    public float speed;
    
    float moveVelocity;
    
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public static int Key = 0;
    public bool isGrounded;
    Rigidbody rb;
    //Grounded Vars

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

        //Left Right Movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            moveVelocity = -speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
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


    
    }

    }

        
    
