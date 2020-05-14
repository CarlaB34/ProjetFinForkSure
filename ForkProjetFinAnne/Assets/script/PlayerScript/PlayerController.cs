using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //Movement
    public float speed;

    #region Dash 
    //dash
    public float speedDash = 10;
    public static bool dashing = false;
    //public float coolDown = 0f;
    //protected float startCoolDown = 0.3f;
    //public float coolDown2 = 0f;
    //protected float startCoolDown2 = 0.3f;
    public Slider sliderDash;

    #endregion

    private float moveVelocity;

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

        sliderDash.value = sliderDash.maxValue;
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
        sliderDash.value += Time.deltaTime;

        if (Input.GetKey(KeyCode.A) && sliderDash.value == sliderDash.maxValue)
        {
            
            transform.rotation = Quaternion.Euler(0, -180, 0 * speed);
            dashing = true;
            moveVelocity = -speed;
            speed = 20;

            //remonte la bar
            Dash();

        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            transform.rotation = Quaternion.Euler(0, -180, 0 * speed);
            moveVelocity = -speed;
            //dash

           // dashing = false;
            speedDash = 0;
            speed = 2;
        //    coolDown = startCoolDown;
        }

        //Right movement + dash 
        
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0 * speed);
            moveVelocity = speed;

            ////dash

            dashing = false;
            speedDash = 0;
            speed = 2;
            //coolDown2 = startCoolDown2;
        }

        GetComponent<Rigidbody>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody>().velocity.y);
    }

    private void Dash()
    {
       
        sliderDash.value -= sliderDash.maxValue;
    }
    /*public void Dashing()
    {
        Debug.Log("coucou");
        if (Input.GetKey(KeyCode.A))
        {
           
        }
           

        if (Input.GetKey(KeyCode.E))
        {

            transform.rotation = Quaternion.Euler(0, 0, 0 * speed);
            dashing = true;
           

            moveVelocity = speed;
            speed = 10;

        }
    }*/
    void OnCollisionEnter(Collision collision) // ajouter 1 a la variable Key lorsqu'on touche la clé 
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("clé"))
        {
            Key += 1;

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


