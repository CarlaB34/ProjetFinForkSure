using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyHealth : MonoBehaviour
{
    public static bool isDash;
    private int enemyhealth = 1;

    private void Update()
    {
        if (enemyhealth > 1)
        {
            enemyhealth = 1;
        }
        isDash = PlayerController.dashing;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") && isDash == true)
        {

            Debug.Log("l'enemy = 1 degat");
            Destroy(gameObject);
            

        }
    }

}
