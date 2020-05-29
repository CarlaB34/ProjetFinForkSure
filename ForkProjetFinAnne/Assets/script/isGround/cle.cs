using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cle : MonoBehaviour
{
    
    //la clé se detruit quand on passe dessus 
    void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Debug.Log("recup clé and destroy");
            Destroy(gameObject);
        }
    }  
}
