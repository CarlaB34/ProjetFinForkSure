using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //Movement
    public float speed;

    #region Dash 
    //dash
    public float speedDash = 100;
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

        //remonte la bar
        sliderDash.value += Time.deltaTime;

        //appui sur A et quand le slide est au max de sa valeur 
        //fait une petite avancer, j'arrive pas a faire aller plus loin, a voir avec la vitesse du speed quand elle passe en dash...
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
            speed = 100;

            //descend la bar quand le dash est effectuer
            Dash();

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
        //pas encore au point
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

    //fait dessendre la bar a moins sa valeur donc -5 dans se cas
    private void Dash()
    {
        sliderDash.value -= sliderDash.maxValue;
    }

    //ne peut pas utiliser car on appel 2 fois la touche a ou le e pour passer dans la fonction et faire avancer le dash
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

        //col mur with dash, probleme traverse le mur peut etre trop de puissance donc ajoue de && dashing == true
        //col ne marche pas avec les element de la scene aussi, dash se teleporte?...
        if (collision.gameObject.name == "wall" && dashing == true)
        {
            Debug.Log("arg un mur!");
            rb.velocity = Vector3.zero;
            dashing = false;
        }

    }

    
}


