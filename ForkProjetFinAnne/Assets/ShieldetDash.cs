using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldetDash : MonoBehaviour
{
  
    #region Dash 
    //dash
    //public float speed = 0.2f;
    public float speedDash = 5;
    public static bool dashinG = false;
    public bool dashingDebug;

    public float coolDown = 0f;
    protected float startCoolDown = 0.5f;
    public float coolDown2 = 0f;
    protected float startCoolDown2 = 0.5f;

    public Slider sliderDash;
    #endregion

    public bool activeDash;
    //bool collide = false;
    //public GameObject uiText;
    private Vector3 moveDirection = Vector3.right;

    private MovePlayer movePlayer;

    public GameObject shield;
    public bool activeShield;

    public float coolDownShield = 0f;
    private float startCoolDownShield = 10f;

    public Slider sliderShield;
    private void Start()
    {
        activeDash = false;
        //  shield.SetActive(false);
       
        sliderDash.gameObject.SetActive(true);

        sliderDash.value = sliderDash.maxValue;

        movePlayer = GetComponent<MovePlayer>();

        activeShield = false;
        shield.SetActive(false);
        
        sliderShield.gameObject.SetActive(true);
        //la valeur du slide commencera a chaque parti a sa valeur max
        sliderShield.value = sliderShield.maxValue;
    }
    public void ResetDash()
    {
        coolDown2 = 0;
        coolDown = 0;
        dashinG = false;
        // shield.SetActive(false);
        activeDash = false;
       
    }
     private void ResetDash2()
     {

         dashinG = false;
         activeDash = false;
       
     }
    private void Update()
    {

        //dash droite
        if (Input.GetKeyDown(KeyCode.E) && sliderDash.value == sliderDash.maxValue)
        {
            sliderDash.gameObject.SetActive(true);
            if (!activeDash)
            {
                //shield.SetActive(true);
                activeDash = true;
                movePlayer.playerView.transform.rotation = Quaternion.Euler(0, 90, 0 * movePlayer.speed);
                dashinG = true;
                GetComponent<Rigidbody>().AddForce(moveDirection * speedDash, ForceMode.Impulse);
            }

            Dashing();


        }
        if (activeDash == true && dashinG == true)
        {
            coolDown2 -= 1 * Time.deltaTime;

            if (coolDown2 <= 0)
            {
                ResetDash();
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
            sliderDash.gameObject.SetActive(true);
            if (!activeDash)
            {
                //shield.SetActive(true);
                activeDash = true;
                movePlayer.playerView.transform.rotation = Quaternion.Euler(0, -90, 0 * movePlayer.speed);
                dashinG = true;
                GetComponent<Rigidbody>().AddForce(moveDirection * -speedDash, ForceMode.Impulse);
            }
            //scrollbar
            Dashing();
        }
        if (activeDash == true && dashinG == true)
        {
            //le dash continu pendant 0.05 sec puis s'arrete, probleme sauter et dash pour tuer un pike = marche 1 fois sur deux
            coolDown -= 1 * Time.deltaTime;

            if (coolDown <= 0)
            {
                ResetDash();
            }
        }
        else
        {
            //remonte la bar
            sliderDash.value += Time.deltaTime;
        }


        dashingDebug = dashinG;

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

    }



    //fait dessendre la bar a moins sa valeur donc -5 dans se cas
    private void Dashing()
    {
        sliderDash.value -= sliderDash.maxValue;
        coolDown = startCoolDown;
        coolDown2 = startCoolDown2;
    }
    private void ShieldBar()
    {
        sliderShield.value -= sliderShield.maxValue;
        coolDownShield = startCoolDownShield;
    }
}
