using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dash : MonoBehaviour
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
    bool collide = false;
    public GameObject uiText;
    private Vector3 moveDirection = Vector3.right;

    private MovePlayer movePlayer;
    private void Start()
    {
        activeDash = false;
      //  shield.SetActive(false);
        uiText.SetActive(false);
        sliderDash.gameObject.SetActive(false);

        sliderDash.value = sliderDash.maxValue;

        movePlayer = GetComponent<MovePlayer>();
    }
    public void ResetDash()
    {
        coolDown2 = 0;
        coolDown = 0;
        dashinG = false;
        // shield.SetActive(false);
        activeDash = false;
        uiText.SetActive(false);
    }
    private void ResetDash2()
    {
        
        dashinG = false;
        activeDash = false;
        uiText.SetActive(false);
    }
    private void Update()
    {

        //dash droite
        if (Input.GetKeyDown(KeyCode.E) && collide && sliderDash.value == sliderDash.maxValue)
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
        if (Input.GetKeyDown(KeyCode.A) && collide && sliderDash.value == sliderDash.maxValue)
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

    }

    

    //fait dessendre la bar a moins sa valeur donc -5 dans se cas
    private void Dashing()
    {
        sliderDash.value -= sliderDash.maxValue;
        coolDown = startCoolDown;
        coolDown2 = startCoolDown2;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PPShield")
        {
            Debug.Log("toucher");
            uiText.SetActive(true);
            sliderDash.gameObject.SetActive(true);
            collide = true;
            dashinG = true;
        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "PPShield")
        {
            uiText.SetActive(false);
            sliderDash.gameObject.SetActive(true);
            collide = false;
        }
    }
    public bool ActiveShield
    {
        get { return sliderDash; }
        set { activeDash = value; }
    }
}
