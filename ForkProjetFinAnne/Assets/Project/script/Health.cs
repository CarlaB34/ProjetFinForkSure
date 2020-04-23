using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int playerhealth = 2;

    public void Update() // la vie est cap a 2hp
    {
        if(playerhealth > 2)
    {
            playerhealth = 2;
        }
    }
    void OnCollisionEnter(Collision collision) // on perd un point de vie si on touche un pic
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("pike"))
        {
            Debug.Log("vous prenez 1 degat");
            playerhealth -= 1;
            
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("heal")) // on gagne un point de vie quand on rammasse un heal
        {
            Debug.Log("vous avez recupéré un point de vie");
            playerhealth += 1;
        }
        if (playerhealth == 0) // si vie = 0 on meurt
        {
            Debug.Log("vous etes mort");
            Destroy(gameObject);
            
        }
    }
}
