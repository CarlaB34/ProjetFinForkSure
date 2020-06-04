using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    private int playerhealth = 3;
    ///public static bool isDash;
    private Shield shield;
    

    private void Start()
    {
        shield = GetComponent<Shield>();
    }
    public void Update() // la vie est cap a 2hp
    {
        if (playerhealth > 3)
        {
            playerhealth = 3;
        }


    }
    void OnCollisionEnter(Collision collision) // on perd un point de vie si on touche un pic
    {
        // if(!shield.ActiveShield)
        //{
        if (collision.gameObject.layer == LayerMask.NameToLayer("pike") && !PlayerController.dashing)
        {
            Debug.Log("bouclier desactiver");
            //bouclier(boolean) activer ne prend pas de degat
            if (!shield.ActiveShield)
            {
                Debug.Log("vous prenez 1 degat");
                playerhealth -= 1;
            }
            //desactive le bouclier, il disparait et on prend des degat
            shield.shield.SetActive(false);
            shield.ActiveShield = false;

        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("IA") && !PlayerController.dashing)
        {
            Debug.Log("vous prenez 1 degat");
            playerhealth -= 1;
        }
        // }

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
