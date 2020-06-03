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

    public Vector3 jump;
    public float jumpForce = 2.0f;

    public static int Key = 0;
    public bool isGrounded;
    Rigidbody rb;

    //Grounded Vars
    private Vector3 moveDirection = Vector3.right;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);

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
            dashing = true;
            

         }
    
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            playerView.transform.rotation = Quaternion.Euler(0, 0, 0 * speed);
            GetComponent<Rigidbody>().AddForce(moveDirection * speed, ForceMode.Impulse);
            //dash
            dashing = true;
        }
        Vector3 velocity = GetComponent<Rigidbody>().velocity;
        
        GetComponent<Rigidbody>().velocity =velocity + new Vector3(moveVelocity, 0);
       

        //dash droite
        if (Input.GetKeyDown(KeyCode.E) && sliderDash.value == sliderDash.maxValue)
        {
            playerView.transform.rotation = Quaternion.Euler(0, 0, 0 * speed);
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
            playerView.transform.rotation = Quaternion.Euler(0, -180, 0 * speed);
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


/* moveVelocity = 0;

        //Left Movement + dash

        //remonte la bar
        sliderDash.value += Time.deltaTime;

        //appui sur A et quand le slide est au max de sa valeur 
        //fait une petite avancer au premier appui voir meme le deuxieme
        //j'arrive pas a faire aller plus loin, a voir avec la vitesse du speed quand elle passe en dash...
        //peut tuer un ennemi si asser de puissance (normalement), probleme aussi avex la box collider

         if (Input.GetKeyDown(KeyCode.A) && sliderDash.value == sliderDash.maxValue)
         {
             //changement de profil
             transform.rotation = Quaternion.Euler(0, -180, 0 * speed);
             //active le dash et permet les collision avec mur et ennemi
             dashing = true;
             //fait avancer 
             moveVelocity = -speed;
             //sa vitesse d'avancer
             speed = 50;

             //descend la bar quand le dash est effectuer
             //Dash();

         }
         if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Q))
         {
             transform.rotation = Quaternion.Euler(0, -180, 0 * speed);
            
             moveVelocity = -speed;
            //dash

            //le dash n'est plus actif donc impossible de l'utiliser avec movement simple
            dashing = false;
            //n'a plus de vitess
            speedDash = 0;
            //revient a 2
            speed = 2;

        }

        //Right movement + dash ne marche pas car pas encore fait
        
        
        if (Input.GetKey(KeyCode.E))
        {
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
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0 * speed);
            GetComponent<Rigidbody>().AddForce(moveDirection* speed, ForceMode.Impulse);
            //moveVelocity = speed;

            //dash

            dashing = false;
            speedDash = 0;
            speed = 2;
            coolDown2 = startCoolDown2;
        }
        Vector3 velocity = GetComponent<Rigidbody>().velocity;

    //particule
            //AfterImagePool.Instance.GetFromPool();
            //lastImageXpos = transform.position.x;
   GetComponent<Rigidbody>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody>().velocity.y);

    void start
    //bloquer et rendre invisible le cursor, problème avec le menu pause
        Cursor.lockState = CursorLockMode.Locked;

     //dash effect pooling
    private void CheckImageDash()
    {
        if(Math.Abs(transform.position.x - lastImageXpos) > distanceBetweenImage)
        {
            AfterImagePool.Instance.GetFromPool();
            lastImageXpos = transform.position.x;
        }
    }
*/
