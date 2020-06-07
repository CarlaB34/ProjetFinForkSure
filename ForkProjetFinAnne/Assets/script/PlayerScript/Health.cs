using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
<<<<<<< Updated upstream:ForkProjetFinAnne/Assets/script/PlayerScript/Health.cs
    private int playerhealth = 3;
    ///public static bool isDash;

=======
    private int playerhealth = 2;
    public static bool isDash;
    public GameObject player;
    public Vector3 spawnSpot = new Vector3(-9.47f, 13.35f, 0.41f);
>>>>>>> Stashed changes:ForkProjetFinAnne/Assets/script/Health.cs
    public void Update() // la vie est cap a 2hp
    {
        if (playerhealth > 3)
        {
            playerhealth = 3;
        }
        
       // isDash = PlayerController.dashing;
    }
    void OnCollisionEnter(Collision collision) // on perd un point de vie si on touche un pic
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("pike") && !PlayerController.dashing)
        {
            Debug.Log("vous prenez 1 degat");
            playerhealth -= 1;

        }
        if(collision.gameObject.layer == LayerMask.NameToLayer("IA") && !PlayerController.dashing)
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
<<<<<<< Updated upstream:ForkProjetFinAnne/Assets/script/PlayerScript/Health.cs
            //SceneManager.LoadScene("StartMenu"); 
            SceneManager.LoadScene("Defeat");
=======
            GameObject Player = (GameObject)Instantiate(player, new Vector3(-9.47f, 13.35f, 0.41f), transform.rotation);
            //SceneManager.LoadScene("StartMenu");

>>>>>>> Stashed changes:ForkProjetFinAnne/Assets/script/Health.cs
        }

    }
}
