using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
  
    public GameObject shield;
    public bool activeShield;

    public float coolDownShield = 0f;
    private float startCoolDownShield = 10f;

    public Slider sliderShield;
    bool collide = false;

    public GameObject uiText;

    void Start()
    {
        activeShield = false;
        shield.SetActive(false);
        uiText.SetActive(false);
        sliderShield.gameObject.SetActive(false);
        //la valeur du slide commencera a chaque parti a sa valeur max
         sliderShield.value = sliderShield.maxValue;
    }

    void Update()
    { 
        if ( Input.GetKeyDown(KeyCode.C)  && collide && sliderShield.value == sliderShield.maxValue)
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

            if(coolDownShield <= 0)
            {
                coolDownShield = 0;
                shield.SetActive(false);
                activeShield = false;
                uiText.SetActive(false);
            }
        }
        else
        {
            sliderShield.value += Time.deltaTime;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PPShield")
        {
            Debug.Log("toucher");
            uiText.SetActive(true);
            sliderShield.gameObject.SetActive(true);
            collide = true;
        }
    }

    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "PPShield")
        {
            uiText.SetActive(false);
            sliderShield.gameObject.SetActive(true);
            collide = false;
        }
    }
    
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


