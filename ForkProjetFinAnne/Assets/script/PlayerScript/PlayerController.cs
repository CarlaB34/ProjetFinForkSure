using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{

    //Movement
    public float speed;

    #region Dash 
    //dash
    public float speedDash = 5;
    public static bool dashing = false;
    public bool dashingDebug;

    public float coolDown = 0f;
    protected float startCoolDown = 0.5f;
    public float coolDown2 = 0f;
    protected float startCoolDown2 = 0.5f;

    public Slider sliderDash;
    #endregion

    private float moveVelocity;
    public GameObject playerView;
    public AudioClip ding;
    public AudioSource source;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    private static int Bosshealth;
    public static int Key = 0;
    public int Kill = 0;
    public bool isGrounded;
    Rigidbody rb;
    // Color color;


    //Grounded Vars

    public Vector3 spawnSpot1 = new Vector3(-22.52f, 5.8f, -0.5636545f);
    public Vector3 spawnSpot2 = new Vector3(-5.05f, 8.3f, -0.5636545f);
    public Vector3 spawnSpot3 = new Vector3(2.49f, 10.2f, -0.5636545f);
    public Vector3 spawnSpot4 = new Vector3(44.01f, 2.68f, -0.5636545f);
    public GameObject Key1;
    public GameObject Key2;
    public GameObject Key3;
    public GameObject color;
    private Vector3 moveDirection = Vector3.right;
  
    private void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        Cursor.visible = false;

        //la valeur du slide commencera a chaque parti a sa valeur max
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
        Bosshealth = enemy.IAhealth;


        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && rb.velocity.y <= 0) // jump
        {
            rb.AddForce(jump * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }


        moveVelocity = 0;

        //Left Movement + dash

        
        

         if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
         {
            playerView.transform.rotation = Quaternion.Euler(0, -90, 0 * speed);
            GetComponent<Rigidbody>().AddForce(moveDirection * -speed, ForceMode.Impulse);
            //dash
            //le dash n'est plus actif donc impossible de l'utiliser avec movement simple
            dashing = true;
            isGrounded = false;

        }
    
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            playerView.transform.rotation = Quaternion.Euler(0, 90, 0 * speed);
            GetComponent<Rigidbody>().AddForce(moveDirection * speed, ForceMode.Impulse);
            //dash
            dashing = true;
            isGrounded = false;
        }
        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        
        GetComponent<Rigidbody>().velocity =velocity + new Vector3(moveVelocity, 0);
       

        //dash droite
        if (Input.GetKeyDown(KeyCode.E) && sliderDash.value == sliderDash.maxValue)
        {
            playerView.transform.rotation = Quaternion.Euler(0, 90, 0 * speed);
            dashing = true;
            GetComponent<Rigidbody>().AddForce(moveDirection * speedDash, ForceMode.Impulse);
            Dash();
            
           
        }
        if(dashing ==true)
        {
            coolDown2 -= 1 * Time.deltaTime;

            if (coolDown2 <= 0)
            {
                coolDown2 = 0;
                dashing = false;

            }
        }
       else
       {
            //remonte la bar
            sliderDash.value += Time.deltaTime;
       }
        //dash gauche
        if (Input.GetKeyDown(KeyCode.A) && sliderDash.value == sliderDash.maxValue)
        {
            playerView.transform.rotation = Quaternion.Euler(0, -90, 0 * speed);
            dashing = true;
            GetComponent<Rigidbody>().AddForce(moveDirection * -speedDash, ForceMode.Impulse);
            
            //scrollbar
            Dash();
        }
        if(dashing == true)
        {
            //le dash continu pendant 0.05 sec puis s'arrete, probleme sauter et dash pour tuer un pike = marche 1 fois sur deux
            coolDown -= 1 * Time.deltaTime;

            if (coolDown <= 0)
            {
                coolDown = 0;
                dashing = false;

            }
        }
        else
        {
            //remonte la bar
            sliderDash.value += Time.deltaTime;
        }


        dashingDebug = dashing;

    }

   
    //fait dessendre la bar a moins sa valeur donc -5 dans se cas
    private void Dash()
    {
        sliderDash.value -= sliderDash.maxValue;
        coolDown = startCoolDown;
        coolDown2 = startCoolDown2;
    }

   
    void OnCollisionEnter(Collision collision) // ajouter 1 a la variable Key lorsqu'on touche la clé 
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("clé"))
        {
            source.PlayOneShot(ding);
            Key += 1;

        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("pike"))
        {
            Kill += 1;
            
            if (Kill == 5)
            {
                GameObject Player = (GameObject)Instantiate(Key1, new Vector3(-22.52f, 5.8f, -0.5636545f), transform.rotation);
            }
            if (Kill == 9)
            {
                GameObject Player = (GameObject)Instantiate(Key2, new Vector3(-5.05f, 8.3f, -0.5636545f), transform.rotation);
            }
            if (Kill == 16)
            {
                GameObject Player = (GameObject)Instantiate(Key3, new Vector3(2.49f, 10.2f, -0.5636545f), transform.rotation);
            }
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("door") && Key == 1) // test de layer 
        {
            Debug.Log("touché");
            rb.velocity = Vector3.zero;
           // dashing = false;
            
        }
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("door1") && Key == 3) // test de layer 
        {
            Debug.Log("touché");
            rb.velocity = Vector3.zero;
            //dashing = false;
        }

        //col mur with dash
        
        if (collision.gameObject.name == "DoorWall")// && dashing == true)
        {
            //Debug.Log("arg un mur!");
            rb.velocity = Vector3.zero;
            GetComponent<Rigidbody>().AddForce(Vector3.zero, 0);
            isGrounded = false;
            //dashing = false;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("IA") && Bosshealth == 1)
        {
            GameObject Player = (GameObject)Instantiate(color, new Vector3(4.451f, -0.92f, -2f), transform.rotation);

        }
    }


}



