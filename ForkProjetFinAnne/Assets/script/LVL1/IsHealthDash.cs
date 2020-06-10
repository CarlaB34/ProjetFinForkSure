using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class IsHealthDash : MonoBehaviour
{
    public int playerhealthLV1 = 3;
    ///public static bool isDash;
    public Image[] sprite;
    public void Update() // la vie est cap a 2hp
    {
        if (playerhealthLV1 > 3)
        {
            playerhealthLV1 = 3;
        }

        
    }
   public void OnCollisionEnter(Collision collision) // on perd un point de vie si on touche un pic
    {
       
        if (collision.gameObject.layer == LayerMask.NameToLayer("pike") && !Dash.dashinG)
        {
            
                Debug.Log("vous prenez 1 degat");
            UpdateLife(-1);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("IA") && !Dash.dashinG)
        {
            Debug.Log("vous prenez 1 degat");
            UpdateLife(-1);
        }
    

        if (collision.gameObject.layer == LayerMask.NameToLayer("heal")) // on gagne un point de vie quand on rammasse un heal
        {
            Debug.Log("vous avez recupéré un point de vie");
            UpdateLife(1);
        }
        if (playerhealthLV1 == 0) // si vie = 0 on meurt
        {
           
            Debug.Log("vous etes mort");
            
                Destroy(gameObject);
            //SceneManager.LoadScene("StartMenu"); 
         SceneManager.LoadScene("Defeat");

        }

    }


    private void UpdateLife(int addAmount) //ajoute une valeur a playerHealth
    {
        playerhealthLV1 += addAmount;
        UpdateLifeUI();
    }
    private void UpdateLifeUI()
    {
        for (int i = 0; i < sprite.Length; i++)
        {
            bool isSpriteAcitve = i < playerhealthLV1;
            sprite[i].gameObject.SetActive(isSpriteAcitve);
        }
    }
}

