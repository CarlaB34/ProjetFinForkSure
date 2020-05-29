using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    //public static bool isDash;
    private int pikehealth = 1;


    private void Update()
    {
        if (pikehealth > 1)
        {
            pikehealth = 1;
        }
        //isDash = PlayerController.dashing;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && PlayerController.dashing)
        {

            Debug.Log("l'enemy prend 1 degat et meurt");
            Destroy(gameObject);
            

        }
    }

}
