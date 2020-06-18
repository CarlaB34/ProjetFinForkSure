using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Health : MonoBehaviour
{
    public int playerhealth = 3;
    ///public static bool isDash;
    private Shield shield;
    public static int mort = 0;
    public GameObject vie1;
    public GameObject vie2;
    public GameObject vie3;
    public GameObject vie4;
    public GameObject vie5;
    public GameObject vie6;
    public GameObject vie7;
    public int Hit = 0;
    public GameObject bulle;

    public Vector3 spawnSpot1 = new Vector3(-58.79473f, 0.6680796f, -0.1889172f);
    public Vector3 spawnSpot2 = new Vector3(-63.41473f, 6.64808f, -0.1889172f);
    public Vector3 spawnSpot3 = new Vector3(-53.88474f, 8.69808f, -0.1889172f);
    public Vector3 spawnSpot4 = new Vector3(-34.85f, 3.49f, -0.1889172f);
    public Vector3 spawnSpot5 = new Vector3(-31.52473f, -1.35192f, -0.1889172f);
    public Vector3 spawnSpot6 = new Vector3(-19.42474f, 3.45808f, -0.1889172f);
    public Vector3 spawnSpot7 = new Vector3(-6.78f, 3.46f, -0.1889172f);


    public Image[] sprite;

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
    public void OnCollisionEnter(Collision collision) // on perd un point de vie si on touche un pic
    {
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("pike") && !PlayerController.dashing)
        {
            Debug.Log("bouclier desactiver");
            //bouclier(boolean) activer ne prend pas de degat
            if (!shield.ActiveShield)
            {
                Debug.Log("vous prenez 1 degat");
                Hit += 1;
                Heal();
                 UpdateLife(-1);

            }
            //desactive le bouclier, il disparait et on prend des degat
            shield.shield.SetActive(false);
            shield.ActiveShield = false;

        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("IA") && !PlayerController.dashing)
        {
            Debug.Log("bouclier desactiver");
            //bouclier(boolean) activer ne prend pas de degat
            if (!shield.ActiveShield)
            {
                Debug.Log("vous prenez 1 degat");
                Hit += 1;
                Heal();
                UpdateLife(-1);

            }
            //desactive le bouclier, il disparait et on prend des degat
            shield.shield.SetActive(false);
            shield.ActiveShield = false;

        }
       

        if (collision.gameObject.layer == LayerMask.NameToLayer("heal")) // on gagne un point de vie quand on rammasse un heal
        {
            Debug.Log("vous avez recupéré un point de vie");
            UpdateLife(1); 
        }
        if (playerhealth == 0) // si vie = 0 on meurt
        {
            Debug.Log("vous etes mort");
            mort = 1;
            Destroy(gameObject);
            //SceneManager.LoadScene("StartMenu"); 
            SceneManager.LoadScene("Defeat");

        }

    }

    private void UpdateLife(int addAmount) //ajoute une valeur a playerHealth
    {
        playerhealth += addAmount;
        UpdateLifeUI();
    }
    private void UpdateLifeUI()
    {
        for (int i = 0; i < sprite.Length; i++)
        {
            bool isSpriteAcitve = i < playerhealth;
            sprite[i].gameObject.SetActive(isSpriteAcitve);
        }
    }
    void Heal()
    {
        if (Hit == 1)
        {
            bulle.SetActive(true);
            GameObject Player = (GameObject)Instantiate(vie1, new Vector3(-16.14f, 3.08f, -0.5636545f), transform.rotation);
        }
        if (Hit == 2)
        {
            GameObject Player = (GameObject)Instantiate(vie2, new Vector3(-21.04f, 9.25f, -0.5636545f), transform.rotation);
        }
        if (Hit == 3)
        {
            GameObject Player = (GameObject)Instantiate(vie3, new Vector3(-12.33f, 11.7f, -0.5636545f), transform.rotation);
        }
        if (Hit == 4)
        {
            GameObject Player = (GameObject)Instantiate(vie4, new Vector3(0.95f, 4.87f, -0.5636545f), transform.rotation);
        }
        if (Hit == 5)
        {
            GameObject Player = (GameObject)Instantiate(vie5, new Vector3(7.81f, 6.31f, -0.5636545f), transform.rotation);
        }
        if (Hit == 6)
        {
            GameObject Player = (GameObject)Instantiate(vie6, new Vector3(9.6f, 1.57f, -0.5636545f), transform.rotation);
        }
        if (Hit == 7)
        {
            GameObject Player = (GameObject)Instantiate(vie7, new Vector3(23.67f, 5.65f, -0.5636545f), transform.rotation);
        }
    }
}
