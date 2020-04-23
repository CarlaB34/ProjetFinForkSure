using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{//la clé se detruit quand on passe dessus 
   
    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.layer == LayerMask.NameToLayer("Player") )
        {
            Destroy(gameObject);
        }
     
    }
}