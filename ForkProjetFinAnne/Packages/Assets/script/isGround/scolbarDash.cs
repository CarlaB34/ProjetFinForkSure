using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scolbarDash : MonoBehaviour
{

    //il faut que quand on appuie sur a ou e on puisse dash.
    //une fois le dash effectuer pendant 3sec. 
    //il faut faire charger la barre pour qu'une fois rempli on puisse utiliser denouveau le dash.
    //faire une barre de chargement avant/pour pouvoir (d')utiliser le dash.

    //avec ce code, je fait en sorte que quand j'appui sur T la barre se lance (descend) pour arriver a zero.
    //donc l'inverse de ce qu'il nous faut.
    #region test1
    /*private float timeRemaining;
    private float timerMax = 0f;
    public Scrollbar scrollbar;

    void Update()
    {
        scrollbar.size = CalculateScrollbarValue();

        if (Input.GetKeyDown(KeyCode.T))
        {
            timeRemaining = timerMax;
        }
        if (timeRemaining <=0)
        {
            timeRemaining = 0;
        }
        else if(timeRemaining >0)
        {
            timeRemaining -= Time.deltaTime;
        }
    }

    public float CalculateScrollbarValue()
    {
        //return (timeRemaining * timerMax);
       return (timeRemaining / timerMax);
    }*/
    #endregion


    #region test2

    /* private Scrollbar scrollbar;
     float timeAmt = 5f;
     float time;

     private void Start()
     {
         scrollbar = this.GetComponent<Scrollbar>();
         time += timeAmt;
     }

     private void Update()
     {

         if (time > 0)
         {
             time -= Time.deltaTime;
             scrollbar.size = time / timeAmt;
         }
         else if (Input.GetKeyDown(KeyCode.T))
         {

         }
     }*/
    #endregion

    #region test3
    /* [SerializeField]
     private float size;

     [SerializeField]
     private Scrollbar scrollbar;

     public float MaxValue { get; set; }

     public float Value
     {
         set
         {
         //    scrollbar = Map(value, 0, MaxValue, 0, 1);
         }
     }

     private void Start()
     {
         Value = 10;
     }
     void Update()
     {
         HandleBar();
     }
     private void HandleBar()
     {
         if(scrollbar != size.scrollbar)
         scrollbar.size = size;
     }

     private float Map(float value, float inMin, float inMax, float outMin, float outMax)
     {
         return (value - inMin) * (outMax - outMin) / (inMax - inMax) + outMax;
         //(78 - 0) * (1 - 0) /(230 - 0) + 0
         //78 *1 / 230 = 0..339
     }*/
    #endregion

    #region test4_marche a peu pre
    public Scrollbar scrollDash;

    public float myManaDash;
    private float currentManaDash;


    private void Start()
    {
        currentManaDash = myManaDash;
    }
    private void Update()
    {
        if(currentManaDash < myManaDash)
        {
            scrollDash.size = Mathf.MoveTowards(scrollDash.size, 1f, Time.deltaTime * 0.1f);
            currentManaDash = Mathf.MoveTowards(currentManaDash / myManaDash, 1f, Time.deltaTime * 0.1f) * myManaDash;
        }

        if(currentManaDash <0)
        {
            currentManaDash = 0;
        }

       

    }

    public void ReducDash(float dashiiiii)
    {
        currentManaDash -= dashiiiii;
        scrollDash.size -= dashiiiii / myManaDash;
    }
    #endregion

   
}


/*
 *  private float timer;
    public float nextTheDashing;
    float TimerBetweenDash;
    public Scrollbar scrollbar;
 *  public void Dash()
    {
        if (TimerBetweenDash >= nextTheDashing)
        {
            if (!dashing)
            {
                //rb.AddForce(moveDirection * speedDash, ForceMode.Impulse);
                moveVelocity = -speed;
                dashing = true;
                TimerBetweenDash = 0;
                scrollbar.size = 0;
            }
        }
    }

    void ResetDash()
    {
        if (timer >= 0.4f)
        {
            dashing = false;
            timer = 0;
            //rb.velocity = Vector3.zero;
            speedDash = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    TimerBetweenDash += Time.deltaTime;
        scrollbar.size = TimerBetweenDash / nextTheDashing;
 *     

 * 
        */
