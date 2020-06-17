using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class shieldDAsh : MonoBehaviour
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

    #region shield
    public GameObject shield;
    public bool activeShield;

    public float coolDownShield = 0f;
    private float startCoolDownShield = 10f;

    public Slider sliderShield;



    #endregion

    private float moveVelocity;
    public GameObject playerView;
    public AudioClip ding;
    public AudioSource source;
    public Vector3 jump;
    public float jumpForce = 2.0f;
    public int Bosshealth;
    public static int Key = 0;
    public int Kill = 0;
    public bool isGrounded;
    Rigidbody rb;
    // Color color;


    //Grounded Vars


    public Vector3 spawnSpot4 = new Vector3(19.85f, -3.78f, -0.5636545f);
    public GameObject color;
    private Vector3 moveDirection = Vector3.right;

    private void Start()
    {

        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        Cursor.visible = false;

        //la valeur du slide commencera a chaque parti a sa valeur max
        sliderDash.value = sliderDash.maxValue;

        //activeShield = false;
        //shield.SetActive(false);

        //sliderShield.gameObject.SetActive(true);
        //la valeur du slide commencera a chaque parti a sa valeur max
        sliderShield.value = sliderShield.maxValue;
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


        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            playerView.transform.rotation = Quaternion.Euler(0, 90, 0 * speed);
            GetComponent<Rigidbody>().AddForce(moveDirection * speed, ForceMode.Impulse);
            //dash
            dashing = true;
        }
        Vector3 velocity = GetComponent<Rigidbody>().velocity;

        GetComponent<Rigidbody>().velocity = velocity + new Vector3(moveVelocity, 0);


        //dash droite
        if (Input.GetKeyDown(KeyCode.E) && sliderDash.value == sliderDash.maxValue)
        {
            playerView.transform.rotation = Quaternion.Euler(0, 90, 0 * speed);
            dashing = true;
            GetComponent<Rigidbody>().AddForce(moveDirection * speedDash, ForceMode.Impulse);
            Dash();


        }
        if (dashing == true)
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
        if (dashing == true)
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
        if (Input.GetKeyDown(KeyCode.C) && sliderShield.value == sliderShield.maxValue)
        {
            sliderShield.gameObject.SetActive(true);
            if (!activeShield)
            {
                shield.SetActive(true);
                activeShield = true;

            }
            ShieldBar();
        }
        if (activeShield == true)
        {
            coolDownShield -= 1 * Time.deltaTime;

            if (coolDownShield <= 0)
            {
                coolDownShield = 0;
                shield.SetActive(false);
                activeShield = false;

            }
        }
        else
        {
            sliderShield.value += Time.deltaTime;
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


        //col mur with dash

        if (collision.gameObject.name == "wall")// && dashing == true)
        {
            Debug.Log("arg un mur!");
            rb.velocity = Vector3.zero;
            //dashing = false;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("IA") && Bosshealth == 1)
        {
            GameObject Player = (GameObject)Instantiate(color, new Vector3(19.85f, -3.78f, -0.5636545f), transform.rotation);

        }
        //if (collision.gameObject.tag == "PPShield2")
        //{
        //    Debug.Log("toucher");

        //    sliderShield.gameObject.SetActive(true);
        //    collide = true;
        //}
    }
    //private void OnCollisionExit(Collision col)
    //{
    //    if (col.gameObject.tag == "PPShield2")
    //    {

    //        sliderShield.gameObject.SetActive(true);
    //        collide = false;
    //    }
    //}
    private void ShieldBar()
    {
        sliderShield.value -= sliderShield.maxValue;
        coolDownShield = startCoolDownShield;
    }
    public bool ActiveShield
    {
        get { return activeShield; }
        set { activeShield = value; }
    }
}