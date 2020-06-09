using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class IsHealthDash : MonoBehaviour
{
    public int playerhealth = 3;
    ///public static bool isDash;

    
    public void Update() // la vie est cap a 2hp
    {
        if (playerhealth > 3)
        {
            playerhealth = 3;
        }


    }
   public void OnCollisionEnter(Collision collision) // on perd un point de vie si on touche un pic
    {
       
        if (collision.gameObject.layer == LayerMask.NameToLayer("pike") && !Dash.dashinG)
        {
            
                Debug.Log("vous prenez 1 degat");
                playerhealth -= 1;
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("IA") && !Dash.dashinG)
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
            //SceneManager.LoadScene("StartMenu"); 
            SceneManager.LoadScene("Defeat");

        }

    }
}
