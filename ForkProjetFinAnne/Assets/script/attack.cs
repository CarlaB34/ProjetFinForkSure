using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attack : MonoBehaviour
{
    private int enemyhealth = 3;
    public GameObject enemy;
    public bool dashing = false;
    void OnCollisionEnter(Collision collision) // on perd un point de vie si on touche un pic
    {
        

        if (collision.gameObject.layer == LayerMask.NameToLayer("pike") && dashing == true)
        {
            Debug.Log("l'enemy = 1 degat");
            enemyhealth -= 1;
            attackDash();

        }
    }
    private void OnCollisionExit(Collision collision)
    {

    }
    private void attackDash()
    {
        if (enemyhealth >= 0)
        {
            Debug.Log("enemy death");
            Destroy(enemy);
        }

    }

}
