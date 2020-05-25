using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    //Movement
    public float speed;
    //dash
    public float speedDash = 10;
    public static bool dashing = false;
    public float coolDown = 0f;
    private float startCoolDown = 0.3f;
    public float coolDown2 = 0f;
    private float startCoolDown2 = 0.3f;
   

    float moveVelocity;
    // dash dash;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public static int Key = 0;
    public  int Kill = 0;
    public bool isGrounded;
    Rigidbody rb;
    //Grounded Vars
    private Vector3 moveDirection = Vector3.zero;
    public Vector3 spawnSpot = new Vector3(-9.47f, 13.35f,0.41f);
    public Vector3 spawnSpot2 = new Vector3(-2.4f, 13.35f, 0.18f);
    public Vector3 spawnSpot3 = new Vector3(3.327f, 14.2f, 0.281f);
    public GameObject Key1;
    public GameObject Key2;
    public GameObject Key3;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        coolDown = startCoolDown;
        coolDown2 = startCoolDown2;
    }
    #region OnCollision
    void OnCollisionStay()
    {
        isGrounded = true; // touche le sol 
    }
    void OnCollisionExit()
    {
        isGrounded = false; // ne touche plus le sol 
    }
    #endregion
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
            dashing = true;
            coolDown -= 1 * Time.deltaTime;
            coolDown2 = 0;
            moveVelocity = -speed;  
            speed = 10;

            if(coolDown <= 0)
            {
                coolDown = 0;
                dashing = false;
                speed = 0;
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            transform.rotation = Quaternion.Euler(0, -180, 0 * speed);
            moveVelocity = -speed;
            //dash

            dashing = false;
            speedDash = 0;
            speed = 2;
            coolDown = startCoolDown;
        }


        #region right move
        //Right movement + dash 
        if (Input.GetKey(KeyCode.E))
        {

            transform.rotation = Quaternion.Euler(0, 0, 0 * speed);
            dashing = true;
            coolDown2 -= 1 * Time.deltaTime;
            coolDown = 0;
           
            moveVelocity = speed;
            speed = 10;

            if (coolDown2 <= 0)
            {
                coolDown2 = 0;
                dashing = false;
                speed = 0;
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0 * speed);
            moveVelocity = speed;

            //dash

            dashing = false;
            speedDash = 0;
            speed = 2;
            coolDown2 = startCoolDown2;
        }
        #endregion
      
        GetComponent<Rigidbody>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody>().velocity.y);


    }
    
   
    void OnCollisionEnter(Collision collision) // ajouter 1 a la variable Key lorsqu'on touche la clé 
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("clé"))
        {
            Key += 1;

        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("pike"))
        {
            Kill += 1;
            if (Kill == 1)
            {
                GameObject Player = (GameObject)Instantiate(Key1, new Vector3(-9.47f, 13.35f,0.41f), transform.rotation);
            }
            if (Kill == 3)
            {
                GameObject Player = (GameObject)Instantiate(Key1, new Vector3(-2.4f, 13.35f, 0.18f), transform.rotation);
            }
            if (Kill == 4)
            {
                GameObject Player = (GameObject)Instantiate(Key1, new Vector3(3.327f, 14.2f, 0.281f), transform.rotation);
            }
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("door") && Key == 1) // test de layer 
        {
            Debug.Log("touché");

        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("door1") && Key == 3) // test de layer 
        {
            Debug.Log("touché");

        }

        //col mur with dash
        if (collision.gameObject.name == "wall")
        {
            rb.velocity = Vector3.zero;
            dashing = false;
        }

    }

    
}



