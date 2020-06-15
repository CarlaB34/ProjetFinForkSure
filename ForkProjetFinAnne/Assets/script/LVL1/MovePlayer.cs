using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovePlayer : MonoBehaviour
{ //Movement
    public  float speed;

  

    private float moveVelocity;
   // [SerializeField]
    public  GameObject playerView;

    public Vector3 jump;
    public float jumpForce = 2.0f;

    private static int Bosshealth;
    public static int Key = 0;
    public int Kill = 0;
    public bool isGrounded;
    Rigidbody rb;
    // Color color;


    //Grounded Vars
    public Vector3 spawnSpot2 = new Vector3(8.52f, 1.51f, -0.81f);
    public Vector3 spawnSpot3 = new Vector3(19.5f, 3.63f, -0.81f);
    public Vector3 spawnSpot4 = new Vector3(24f, -2.6f, -0.8f);
    public GameObject Key2;
    public GameObject Key3;
    public GameObject color;
    private Vector3 moveDirection = Vector3.right;
    Dash dash;

    private void Start()
    {
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

        //la valeur du slide commencera a chaque parti a sa valeur max
       // dash = GetComponent<Dash>();

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


        Bosshealth = enemy.IAhealth;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            playerView.transform.rotation = Quaternion.Euler(0, -90, 0 * speed);
            GetComponent<Rigidbody>().AddForce(moveDirection * -speed, ForceMode.Impulse);
            //dash
            //le dash n'est plus actif donc impossible de l'utiliser avec movement simple
           /// Dash.dashinG = false;
            dash.ResetDash();

        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            playerView.transform.rotation = Quaternion.Euler(0, 90, 0 * speed);
            GetComponent<Rigidbody>().AddForce(moveDirection * speed, ForceMode.Impulse);
            //dash
            //Dash.dashinG = false;
            dash.ResetDash();
        }
        Vector3 velocity = GetComponent<Rigidbody>().velocity;

        GetComponent<Rigidbody>().velocity = velocity + new Vector3(moveVelocity, 0);


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

            if (Kill == 2)
            {
                GameObject Player = (GameObject)Instantiate(Key2, new Vector3(8.52f, 1.51f, -0.81f), transform.rotation);
            }
            
            if (Kill == 3)
            {
                GameObject Player = (GameObject)Instantiate(Key3, new Vector3(19.5f, 3.63f, -0.81f), transform.rotation);
            }
           
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("door") && Key == 1) // test de layer 
        {
            Debug.Log("touché");
            rb.velocity = Vector3.zero;
            // dashing = false;

        }

        if (collision.gameObject.name == "door1" && Key == 3) // test de layer 
        {
            Debug.Log("touché");
            rb.velocity = Vector3.zero;
            //dashing = false;
        }

        //col mur with dash

        if (collision.gameObject.layer == LayerMask.NameToLayer("wall"))// && dashing == true)
        {
           // Debug.Log("arg un mur!");
            rb.velocity = Vector3.zero;
           // Dash.dashinG = false;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("IA") && Bosshealth == 1)
        {
            GameObject Player = (GameObject)Instantiate(color, new Vector3(24f, -2.6f, -0.8f), transform.rotation);

        }
    }


}
