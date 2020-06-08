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

    public static int Key = 0;
    public bool isGrounded;
    Rigidbody rb;
    // Color color;


    //Grounded Vars
    private Vector3 moveDirection = Vector3.right;
    Dash dash;

    private void Start()
    {
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




        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
        {
            playerView.transform.rotation = Quaternion.Euler(0, -180, 0 * speed);
            GetComponent<Rigidbody>().AddForce(moveDirection * -speed, ForceMode.Impulse);
            //dash
            //le dash n'est plus actif donc impossible de l'utiliser avec movement simple
            Dash.dashing = true;


        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            playerView.transform.rotation = Quaternion.Euler(0, 0, 0 * speed);
            GetComponent<Rigidbody>().AddForce(moveDirection * speed, ForceMode.Impulse);
            //dash
            Dash.dashing = true;
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

        if (collision.gameObject.name == "wall")// && dashing == true)
        {
            Debug.Log("arg un mur!");
            rb.velocity = Vector3.zero;
            //dashing = false;
        }

    }


}
