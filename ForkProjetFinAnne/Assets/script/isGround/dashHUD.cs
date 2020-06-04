using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dashHUD : MonoBehaviour
{

    public float timerShield = 5.0f;
    bool started = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            //StartCoroutine(startTimer(5));
            timerShield -= Time.deltaTime;
            started = true;

        }
        if (timerShield <= 0)
        {
            timerShield = 0;
        }

    }
    // IEnumerator startTimer(float timeLeft)
    //{
    //    while (timeLeft > 0)
    //    {
    //        timeLeft -= Time.deltaTime;
    //        Debug.Log("fin");
    //        yield return null;
    //    }
    //}
}
   /* public Slider sliderDash;
    public PlayerController playerController;
 
   
    // Start is called before the first frame update
    void Start()
    {
        sliderDash.value = sliderDash.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        sliderDash.value += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.A) && sliderDash.value == sliderDash.maxValue)
        {
            Dash();

        }
        
    }

    private void Dash()
    {
        playerController.Dashing();
        sliderDash.value -= sliderDash.maxValue;
    }
}*/
