using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{/*
    public GameObject shield;
    private bool activeShield;
    public Slider sliderShield;

    void Start()
    {
        activeShield = false;
        shield.SetActive(false);

        //la valeur du slide commencera a chaque parti a sa valeur max
        sliderShield.value = sliderShield.maxValue;
    }
    private void Update()
    {
        sliderShield.value += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.T))
        {
            //shield.SetActive(true);
            shield.SetActive(true);
            activeShield = true;
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            //shield.SetActive(false);
            shield.SetActive(false);
            activeShield = false;
            ShieldBar();
        }
           
    }

    private void ShieldBar()
    {
        sliderShield.value -= sliderShield.maxValue;

    }

    public bool ActiveShield
    {

        get { return activeShield; }
        set { activeShield = value; }

    }

}*/
    public GameObject shield;
    private bool activeShield;
    //Timer
    public float timerShield = 5f;


    public Slider sliderShield;


    // Start is called before the first frame update
    void Start()
    {
        activeShield = false;
        shield.SetActive(false);

        //la valeur du slide commencera a chaque parti a sa valeur max
        sliderShield.value = sliderShield.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        sliderShield.value += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.B) && sliderShield.value == sliderShield.maxValue)
        {
            if (!activeShield)
            {
                //timerShield -= 1* Time.deltaTime;
                shield.SetActive(true);
                activeShield = true;

            }
            else
            //if(timerShield <=0 && activeShield)
            {
                //timerShield = 0;
                shield.SetActive(false);
                activeShield = false;
                ShieldBar();
            }
        }

    }

   /* private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PPShield")
        {
            StartCoroutine(ShowAndHideShield(3.0f)); // 3 second
        }

    }
    IEnumerator ShowAndHideShield(float delay)
    {
       // yield return new WaitForSeconds(delay);
        while (enabled)
        {
            Debug.Log("je suis b");
           
            //if (sliderShield.value == sliderShield.maxValue)
            //{
                if (!activeShield)
                {

                    shield.SetActive(true);
                    activeShield = true;
                }
                else
                {
                    shield.SetActive(false);
                    activeShield = false;
                    ShieldBar();
                }
                yield return new WaitForSeconds(delay);
            //}

        }



    }*/
    
    private void ShieldBar()
    {
        sliderShield.value -= sliderShield.maxValue;

    }

    public bool ActiveShield
    {

        get { return activeShield; }
        set { activeShield = value; }

    }
}

/*//Bool
public bool shielAtivated = false;

//GameObject
public GameObject shield;

void Update()
{


    //If shield power up is active
    if (shielAtivated == true)
    {
        shieldTimer -= Time.deltaTime;
        transform.gameObject.tag = "shield";
    }

    if (shieldTimer <= 0.0f)
    {
        transform.gameObject.tag = "Player";
        //DestroyObject(newShield);
    }

    if(col.gameObject.tag == "PPShield")    
        {
            SpawnShield();
            Destroy(GameObject.FindGameObjectWithTag("PPShield"));
        }

    
}*/
