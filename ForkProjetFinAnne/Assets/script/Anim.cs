using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    private Animator anim;
    private static int mort = Health.mort;
    private static int mort2 = IsHealthDash.mort;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.Q))
        {
            anim.SetBool("marche", true);
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.Q))
        {
            anim.SetBool("marche", false);
        }
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
            //anim.SetTrigger("Saut");
        //}
       /* if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyUp(KeyCode.A))
        {
            anim.SetTrigger("Dash");
        }
        if (mort2 == 1)
        {           
            anim.SetTrigger("Mort");
        }*/

    }
}
